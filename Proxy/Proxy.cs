using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Model;

namespace Proxy
{
    public class Proxy : IMonitore
    {
        private LogDB _logDB;
        public Proxy(LogDB logDB)
        {
            _logDB = logDB;
        }

        public void SaveLog(string msg)
        {
            _logDB.Insert(msg);
        }

        public List<Log> Select()
        {
            return _logDB.Select();
        }
    }
}
