using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IATM
    {

        void Desposit(int amount);
	
	    bool Withdraw(int amount);
	
	    void InsertCard();
	
	    void EjectCard();

	
    }
}
