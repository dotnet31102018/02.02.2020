using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            RealATM atm = new RealATM();
            GetProxy(new ATMProxy());

            atm.InsertCard();
            atm.EjectCard();
            atm.Desposit(1000);
            atm.Withdraw(20000);
        }

        static void GetProxy(IMonitorService proxy)
        {
            Console.WriteLine(proxy.GetStatus());
            Console.WriteLine(proxy.GetTotalCash());
        }
    }
}
