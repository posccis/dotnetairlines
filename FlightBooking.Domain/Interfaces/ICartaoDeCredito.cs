using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Interfaces
{
    public interface ICartaoDeCredito
    {
        public int Id { get; set; }
        public int IdTripulante { get; set; }
        public string Numero { get; set; }
        public string NomeTitular { get; set; }
        public string Vencimento { get; set; }
        public string CodSeguranca { get; set; }
        public string Bandeira { get; set; }
    }
}
