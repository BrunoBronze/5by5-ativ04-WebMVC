using Model;
using System.Collections.Generic;

namespace Proxy
{
    public interface IMonitore
    {
        void SaveLog(string msg);

        List<Log> Select();
    }
}
