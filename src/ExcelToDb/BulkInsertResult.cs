using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDb
{
    public class BulkInsertResult
    {
        public BulkInsertResultCode Code { get; set; }
        public string Message { get; set; } = "";
    }
}
