using OfficeOpenXml;

using System.Data;

namespace ExcelToDbConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string fileName = args[0];
            string directory = Environment.CurrentDirectory;
            ReadExcel(string.Join('\\', directory, fileName));
            PrintData();
        }

        private static void PrintData()
        {
            int loop = 0;
            bool isHead = true;
            foreach (var rowCollection in table.Rows)
            {
                if (table.Columns.Count == loop)
                {
                    Console.WriteLine();
                    loop = 0;
                    if (isHead)
                    {
                        isHead = false;
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            Console.Write("--------------------");
                        }
                        Console.WriteLine();
                    }
                }

                var row = (DataRow)rowCollection;

                foreach (var columnCollection in table.Columns)
                {
                    var column = (DataColumn)columnCollection;
                    Console.Write("{0,20}", row[column]);
                    loop++;
                }

                
            }
        }

        private static void ReadExcel(string fileName)
        {
            Console.WriteLine("FileName : " + fileName);
            
            if (!File.Exists(fileName))
                throw new FileNotFoundException();

            var file = new FileInfo(fileName);
            using var package = new ExcelPackage(file);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var currentSheet = package.Workbook.Worksheets;
            var workSheet = currentSheet.First();
            var colCount = workSheet.Dimension.End.Column;
            var rowCount = workSheet.Dimension.End.Row;

            DataRow firstRow = table.NewRow();
            for (int i = 1; i <= colCount; i++)
            {
                //Console.Write($"\t{workSheet.Cells[1, i].Value?.ToString()}");
                table.Columns.Add(new DataColumn {
                    ColumnName = workSheet.Cells[1, i].Value?.ToString(),
                    DataType = typeof(string)
                });
                firstRow[i - 1] = workSheet.Cells[1, i].Value?.ToString();
            }
            table.Rows.Add(firstRow);

            if (rowCount == 1) return;
            for (int i = 2; i <= rowCount; i++)
            {
                DataRow row = table.NewRow();
                for (int j = 1; j <= colCount; j++)
                {
                    row[j-1] = workSheet.Cells[i, j].Value?.ToString();
                }
                table.Rows.Add(row);
            }
        }

        public static DataTable table = new DataTable();
    }
}