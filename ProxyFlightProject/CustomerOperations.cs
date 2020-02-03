using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithProxy
{
    public class CustomerOperations : ICustomer
    {
        public void CancelTicket(Ticket t)
        {
            throw new NotImplementedException();
        }

        public void PurchaseTicket(Ticket t)
        {
            throw new NotImplementedException();
        }
    }
}
