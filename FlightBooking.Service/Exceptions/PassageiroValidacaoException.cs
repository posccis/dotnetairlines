using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Service.Exceptions
{
    public class PassageiroValidacaoException : Exception
    {
        public int Codigo { get; set; }
        public PassageiroValidacaoException(int codigo, string message) : base(message)
        {
            Codigo = codigo;
        }
    }
}
