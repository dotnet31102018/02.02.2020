using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithProxy
{
    public class CustomerProxy : ICustomer
    {
        public void CancelTicket(Ticket t)
        {
            Facade f = new Facade();
            f.CancelTicket(t);
        }

        public void PurchaseTicket(Ticket t)
        {
            Facade f = new Facade();
            f.PurchaseTicket(t);
        }
    }
}
