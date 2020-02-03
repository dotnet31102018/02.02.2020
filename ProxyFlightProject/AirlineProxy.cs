using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithProxy
{
    public class AirlineProxy : IAirline
    {
        public void CreateFlight(Flight f)
        {
            Facade fac = new Facade();
            fac.CreateFlight(f);
        }

        public void UpdateFlight(Flight f, int flightId)
        {
            Facade fac = new Facade();
            fac.UpdateFlight(f, flightId);
        }
    }
}
