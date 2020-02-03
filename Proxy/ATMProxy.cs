using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ATMProxy : IMonitorService
    {

        public ATMProxy()
        {
        }

        public string GetStatus()
        {
            IMonitorService ATM = new RealATM(); //
            return ATM.GetStatus();
        }

        public int GetTotalCash()
        {
            IMonitorService ATM = new RealATM();
            return ATM.GetTotalCash();
        }
    }
}
