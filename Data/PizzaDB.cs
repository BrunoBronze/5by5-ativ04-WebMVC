using System.Collections.Generic;
using System.Data.SqlClient;
using Model;
using Util;

namespace Data
{
    public class PizzaDB : IPizza
    {
        private ConnectionDB _conn;

        public bool Insert(Pizza pizza)
        {
            bool status = false;
            string sql = string.Format(Pizza.insert, pizza.ToString());

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public List<Pizza> Select()
        {
            var returnData = _conn.ExecQueryReturn(Pizza.select);
            return TransformSQLReaderToList(returnData);
        }

        private List<Pizza> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var list = new List<Pizza>();

            while (returnData.Read())
            {
                var item = new Pizza()
                {
                    Id = int.Parse(returnData["Id"].ToString()),
                };

                list.Add(item);
            }
            return list;
        }

        public bool Remover(int id)
        {
            bool status = false;
            string sql = string.Format(Pizza.remove, id.ToString());

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }
    }
}
