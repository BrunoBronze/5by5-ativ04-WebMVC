using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;
using Util;

namespace Data
{
    public class MealDB : IMeal
    {
        private ConnectionDB _conn;

        public bool Insert(Meal meal)
        {
            bool status = false;
            string sql = string.Format(Meal.insert, meal.ToString());

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }

            return status;
        }

        public List<Meal> Select()
        {
            using (_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(Meal.select);
                return TransformSQLReaderToList(returnData);
            }
        }
        
        private List<Meal> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var list = new List<Meal>();

            while (returnData.Read())
            {
                var item = new Meal()
                {
                    Id = int.Parse(returnData["Id"].ToString()),
                    Description = returnData["Description"].ToString(),
                    Value = decimal.Parse(returnData["Value"].ToString())
                };

                list.Add(item);
            }
            return list;
        }

        public bool Remover(int id)
        {
            bool status = false;
            string sql = string.Format(Meal.delete, id);

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public decimal FullValue(int Id)
        {
            string sql = string.Format(Meal.selectTotal, Id);
            using (_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(sql);
                return decimal.Parse(returnData["Value"].ToString());
            }
        }

        public bool Update(Meal meal)
        {
            bool status = false;
            string sql = string.Format(Meal.update, meal.Description, meal.Value, meal.Id);

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public Meal SelectById(int id)
        {
            string sql = string.Format(Meal.selectById, id);

            using (_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformSQLReaderToList(returnData)[0];
            }
        }

        public bool Delete(int id)
        {
            bool status = false;
            string sql = string.Format(Meal.delete, id);

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }
    }
}
