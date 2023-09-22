using OfficeOpenXml;

using System.Data;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ExcelToDb
{
    public partial class MainForm : Form
    {
        private const int PREVIEW_LIMIT = 100;

        private DbContext dbContext;
        private DataTable table;
        private Logger logger;
        private bool isLoading = false;
        private bool isConnection = false;

        public MainForm()
        {
            InitializeComponent();
            dbContext = new DbContext();
            table = new DataTable();
            logger = new Logger(txtLog);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = this.Text;
            dialog.Filter = "Excel files (*.xlsx) | *.xlsx; | All files (*.*) | *.*";
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                txtFilePath.Text = dialog.FileName;
            }
        }

        private void btnLoading_Click(object sender, EventArgs e)
        {
            try
            {
                ReadExcel(txtFilePath.Text ?? "");
                PreviewBinding();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                isLoading = false;
            }

            ActiveDbControls();
        }

        private void cbDbIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            txtDbId.Enabled = !cbDbIntegratedSecurity.Checked;
            txtDbPassword.Enabled = !cbDbIntegratedSecurity.Checked;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            dbContext.Connect(txtDbServer.Text, txtDbName.Text, cbDbIntegratedSecurity.Checked, txtDbId.Text, txtDbPassword.Text);
            isConnection = dbContext.ConnectionTest();

            if (isConnection)
                logger.LogInformation("Database connection success");
            else
                logger.LogWarning("Database connection fail");

            MessageBox.Show($"Database Connection {(isConnection ? "OK" : "Fail")}");

            ActiveInsertDataControls();
        }

        private void btnInsertToDb_Click(object sender, EventArgs e)
        {
            string tableName = txtTableName.Text;
            if (string.IsNullOrEmpty(tableName))
            {
                logger.LogInformation("Table name is null or empty");
                MessageBox.Show("TableName is empty");
                return;
            }

            table.TableName = tableName;
            BulkInsertResult result = dbContext.InsertToDb(table);
            switch (result.Code)
            {
                case BulkInsertResultCode.SUCCESS:
                    logger.LogInformation($"BulkInsertResult - {result.Message}");
                    MessageBox.Show("Success");
                    break;
                case BulkInsertResultCode.EXISTING_TABLE:
                    logger.LogWarning($"BulkInsertResult - {result.Message}");
                    break;
                case BulkInsertResultCode.ERROR_CREATE_TABLE:
                case BulkInsertResultCode.ERROR_INSERT:
                case BulkInsertResultCode.ERROR_EXCEPTION:
                    logger.LogError($"BulkInsertResult - {result.Message}");
                    break;
                default:
                    break;
            }
        }

        private void ActiveInsertDataControls()
        {
            if (isConnection)
            {
                txtTableName.Enabled = true;
                btnInsertToDb.Enabled = true;
            }
        }

        private void ActiveDbControls()
        {
            if (isConnection)
                return;

            if (isLoading)
            {
                txtDbServer.Enabled = isLoading;
                txtDbName.Enabled = isLoading;
                cbDbIntegratedSecurity.Enabled = isLoading;
                txtDbId.Enabled = isLoading;
                txtDbPassword.Enabled = isLoading;
                btnConnect.Enabled = isLoading;
            }
        }

        private void PreviewBinding()
        {
            if (gvPreview.DataSource != null)
            {
                gvPreview.DataSource = null;
                gvPreview.Refresh();
            }

            if (table.Rows.Count > PREVIEW_LIMIT)
            {
                DataTable viewTable = table.Clone();
                for (int i = 0; i < PREVIEW_LIMIT; i++)
                {
                    DataRow row = viewTable.NewRow();
                    foreach (DataColumn col in viewTable.Columns)
                    {
                        row[col.ColumnName] = table.Rows[i][col.ColumnName].ToString();
                    }
                    viewTable.Rows.Add(row);
                }
                gvPreview.DataSource = viewTable;
            }
            else
                gvPreview.DataSource = table;

            lblTotal.Text = $"Total : {table.Rows.Count}";

            isLoading = true;
        }

        private void ReadExcel(string fileName)
        {
            logger.LogInformation("file loading start - " + fileName);

            table = new DataTable();

            if (!File.Exists(fileName))
                throw new FileNotFoundException();

            var file = new FileInfo(fileName);
            using var package = new ExcelPackage(file);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var currentSheet = package.Workbook.Worksheets;
            var workSheet = currentSheet.First();
            var colCount = workSheet.Dimension.End.Column;
            var rowCount = workSheet.Dimension.End.Row;

            //DataRow firstRow = table.NewRow();
            //primary key column
            table.Columns.Add(new DataColumn {
                ColumnName = "pid_" + GetRandomLetter(6),
                DataType = typeof(long),
                AutoIncrement = true,
                AllowDBNull = false,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1
            });

            for (int i = 1; i <= colCount; i++)
            {
                //Console.Write($"\t{workSheet.Cells[1, i].Value?.ToString()}");
                table.Columns.Add(new DataColumn {
                    ColumnName = workSheet.Cells[1, i].Value?.ToString(),
                    DataType = typeof(string)
                });
                //firstRow[i - 1] = workSheet.Cells[1, i].Value?.ToString();
            }

            if (rowCount == 1) return;
            for (int i = 2; i <= rowCount; i++)
            {
                DataRow row = table.NewRow();
                for (int j = 1; j <= colCount; j++)
                {
                    row[j] = workSheet.Cells[i, j].Value?.ToString();
                }
                table.Rows.Add(row);
            }

            table.PrimaryKey = new DataColumn[] { table.Columns[0] };

            logger.LogInformation($"file loading end - total : {table.Rows.Count}");
        }

        public string GetRandomLetter(int length)
        {
            string letter = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string createLetter = "";
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                createLetter += letter.Substring(rnd.Next(letter.Length - 1), 1);
            }

            return createLetter;
        }


    }
}