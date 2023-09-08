using FlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Interfaces
{
    public interface IAviao
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string QuantidadeAssentos { get; set; }
        public string Ano { get; set; }

        public ICollection<Voo> Voos { get; set; }
    }
}
