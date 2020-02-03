using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithProxy
{
    public interface IAirline
    {
        void CreateFlight(Flight f);
        void UpdateFlight(Flight f, int flightId);
    }
}
