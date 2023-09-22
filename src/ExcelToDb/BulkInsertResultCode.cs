using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDb
{
    public enum BulkInsertResultCode
    {
        SUCCESS,
        EXISTING_TABLE,
        ERROR_CREATE_TABLE,
        ERROR_INSERT,
        ERROR_EXCEPTION
    }
}
