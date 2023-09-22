using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDb
{
    public class DbContext
    {
        private static SqlConnection connection = new SqlConnection();

        public void Connect(string server, string database, bool isIntegratedSecuraity, string id, string password)
        {
            string connectionString = $"Server={server};database={database};Connection Timeout=30;";
            if (isIntegratedSecuraity)
            {
                connectionString += "Integrated Security=true;";
            }
            else
            {
                connectionString += $"User ID={id};Password={password};";
            }

            Disconnect();

            connection.ConnectionString = connectionString;
        }

        public BulkInsertResult InsertToDb(DataTable table)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"select count(table_name) as cnt from INFORMATION_SCHEMA.TABLES where table_name='{table.TableName}'";

            try
            {
                connection.Open();
                int result = (int)cmd.ExecuteScalar();
                if (result == 1) {
                    return new BulkInsertResult { 
                        Code = BulkInsertResultCode.EXISTING_TABLE, 
                        Message = BulkInsertResultCode.EXISTING_TABLE.ToString() 
                    };
                }

                CreateTable(table);
                BulkInsert(table);
            }
            catch (Exception ex)
            {
                return new BulkInsertResult {
                    Code = BulkInsertResultCode.ERROR_EXCEPTION,
                    Message = ex.Message
                };
            }
            finally
            {
                Disconnect();
            }
            return new BulkInsertResult {
                Code = BulkInsertResultCode.SUCCESS,
                Message = BulkInsertResultCode.SUCCESS.ToString()
            };
        }

        private void BulkInsert(DataTable table)
        {
            using var bulkCopy = new SqlBulkCopy(connection);
            bulkCopy.DestinationTableName = table.TableName;
            try
            {
                bulkCopy.WriteToServer(table, DataRowState.Added);
            }
            catch
            {
                throw;
            }
        }

        private void CreateTable(DataTable table)
        {
            if (connection.State != ConnectionState.Open)
                return;

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = GetCreateTableSql(table);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Inspects a DataTable and return a SQL string that can be used to CREATE a TABLE in SQL Server.
        /// </summary>
        /// <param name="table">System.Data.DataTable object to be inspected for building the SQL CREATE TABLE statement.</param>
        /// <returns>String of SQL</returns>
        private string GetCreateTableSql(DataTable table)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder alterSql = new StringBuilder();

            sql.AppendFormat("CREATE TABLE [{0}] (", table.TableName);

            for (int i = 0; i < table.Columns.Count; i++)
            {
                bool isNumeric = false;
                bool usesColumnDefault = true;

                sql.AppendFormat("\n\t[{0}]", table.Columns[i].ColumnName);

                switch (table.Columns[i].DataType.ToString().ToUpper())
                {
                    case "SYSTEM.INT16":
                        sql.Append(" smallint");
                        isNumeric = true;
                        break;
                    case "SYSTEM.INT32":
                        sql.Append(" int");
                        isNumeric = true;
                        break;
                    case "SYSTEM.INT64":
                        sql.Append(" bigint");
                        isNumeric = true;
                        break;
                    case "SYSTEM.DATETIME":
                        sql.Append(" datetime");
                        usesColumnDefault = false;
                        break;
                    case "SYSTEM.STRING":
                        //sql.AppendFormat(" nvarchar({0})", table.Columns[i].MaxLength);
                        sql.AppendFormat(" nvarchar(max)");
                        break;
                    case "SYSTEM.SINGLE":
                        sql.Append(" single");
                        isNumeric = true;
                        break;
                    case "SYSTEM.DOUBLE":
                        sql.Append(" double");
                        isNumeric = true;
                        break;
                    case "SYSTEM.DECIMAL":
                        sql.AppendFormat(" decimal(18, 6)");
                        isNumeric = true;
                        break;
                    default:
                        sql.AppendFormat(" nvarchar({0})", table.Columns[i].MaxLength);
                        break;
                }

                if (table.Columns[i].AutoIncrement)
                {
                    sql.AppendFormat(" IDENTITY({0},{1})",
                        table.Columns[i].AutoIncrementSeed,
                        table.Columns[i].AutoIncrementStep);
                }
                else
                {
                    // DataColumns will add a blank DefaultValue for any AutoIncrement column. 
                    // We only want to create an ALTER statement for those columns that are not set to AutoIncrement. 
                    if (table.Columns[i].DefaultValue != null)
                    {
                        if (usesColumnDefault)
                        {
                            if (isNumeric)
                            {
                                alterSql.AppendFormat("\nALTER TABLE {0} ADD CONSTRAINT [DF_{0}_{1}]  DEFAULT ({2}) FOR [{1}];",
                                    table.TableName,
                                    table.Columns[i].ColumnName,
                                    table.Columns[i].DefaultValue);
                            }
                            else
                            {
                                alterSql.AppendFormat("\nALTER TABLE {0} ADD CONSTRAINT [DF_{0}_{1}]  DEFAULT ('{2}') FOR [{1}];",
                                    table.TableName,
                                    table.Columns[i].ColumnName,
                                    table.Columns[i].DefaultValue);
                            }
                        }
                        else
                        {
                            // Default values on Date columns, e.g., "DateTime.Now" will not translate to SQL.
                            // This inspects the caption for a simple XML string to see if there is a SQL compliant default value, e.g., "GETDATE()".
                            try
                            {
                                System.Xml.XmlDocument xml = new System.Xml.XmlDocument();

                                xml.LoadXml(table.Columns[i].Caption);

                                alterSql.AppendFormat("\nALTER TABLE {0} ADD CONSTRAINT [DF_{0}_{1}]  DEFAULT ({2}) FOR [{1}];",
                                    table.TableName,
                                    table.Columns[i].ColumnName,
                                    xml.GetElementsByTagName("defaultValue")[0].InnerText);
                            }
                            catch
                            {
                                // Handle
                            }
                        }
                    }
                }

                if (!table.Columns[i].AllowDBNull)
                {
                    sql.Append(" NOT NULL");
                }

                sql.Append(",");
            }

            if (table.PrimaryKey.Length > 0)
            {
                StringBuilder primaryKeySql = new StringBuilder();

                primaryKeySql.AppendFormat("\n\tCONSTRAINT PK_{0} PRIMARY KEY (", table.TableName);

                for (int i = 0; i < table.PrimaryKey.Length; i++)
                {
                    primaryKeySql.AppendFormat("{0},", table.PrimaryKey[i].ColumnName);
                }

                primaryKeySql.Remove(primaryKeySql.Length - 1, 1);
                primaryKeySql.Append(")");

                sql.Append(primaryKeySql);
            }
            else
            {
                sql.Remove(sql.Length - 1, 1);
            }

            sql.AppendFormat("\n);\n{0}", alterSql.ToString());

            return sql.ToString();
        }

        public bool ConnectionTest()
        {
            int result = 0;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select 1";

            try
            {
                connection.Open();
                result = (int)cmd.ExecuteScalar();
            }
            catch{}
            finally
            {
                Disconnect();
            }
            return result == 1;
        }

        public void Disconnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
