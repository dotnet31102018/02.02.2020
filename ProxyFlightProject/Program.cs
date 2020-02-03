using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerProxy custgomerProxy = new CustomerProxy();
            custgomerProxy.PurchaseTicket(new Ticket());

            AirlineProxy airlineProxy = new AirlineProxy();
            airlineProxy.CreateFlight(new Flight());
        }
    }
}
