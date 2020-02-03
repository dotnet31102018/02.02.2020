using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithProxy
{
    public class Facade : IAirline, ICustomer
    {
        private CustomerOperations customerOperations = new CustomerOperations();
        private AirlineOperations airlineOperations = new AirlineOperations();

        public void CancelTicket(Ticket t)
        {
            customerOperations.CancelTicket(t);
        }

        public void CreateFlight(Flight f)
        {
            airlineOperations.CreateFlight(f);
        }

        public void PurchaseTicket(Ticket t)
        {
            customerOperations.PurchaseTicket(t);
        }

        public void UpdateFlight(Flight f, int flightId)
        {
            airlineOperations.UpdateFlight(f, flightId);
        }
    }
}
