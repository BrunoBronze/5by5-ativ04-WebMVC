using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Util;

namespace Data
{
    public class LogDB
    {
        private ConnectionDB _conn;

        public bool Insert(string msg)
        {
            bool status = false;
            string sql = string.Format(Meal.insert, msg);

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }

            return status;
        }

        public List<Log> Select()
        {
            var returnData = _conn.ExecQueryReturn(Meal.select);
            return TransformSQLReaderToList(returnData);
        }

        private List<Log> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var list = new List<Log>();

            while (returnData.Read())
            {
                var item = new Log()
                {
                    Description = returnData["Description"].ToString(),
                    DateInformation = DateTime.ParseExact(returnData["Value"].ToString(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"))
                };

                list.Add(item);
            }
            return list;
        }
    }
}
