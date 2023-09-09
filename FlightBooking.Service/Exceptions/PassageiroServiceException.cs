using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Service.Exceptions
{
    public class PassageiroServiceException : Exception
    {
        public PassageiroServiceException( string message) : base(message)
        {
            
        }
    }
}
