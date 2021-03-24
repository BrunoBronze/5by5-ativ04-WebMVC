using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Log
    {
        public const string select = "SELECT Description, DateInformation FROM TB_REFEICAO";
        public const string insert = "INSERT INTO TB_LOG (Description, DateInformation) VALUES ('{0}', GETDATE())";

        public string Description { get; set; }
        public DateTime DateInformation { get; set; }
    }
}
