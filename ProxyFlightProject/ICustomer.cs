using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithProxy
{
    public interface ICustomer
    {
        void PurchaseTicket(Ticket t);
        void CancelTicket(Ticket t);
    }
}
