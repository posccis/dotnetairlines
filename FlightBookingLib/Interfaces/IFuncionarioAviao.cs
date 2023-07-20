using FlightBookingLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Lib.Interfaces
{
    public interface IFuncionarioAviao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string TempoDeVoo { get; set; }
        public DateTime DataDeNascimeto { get; set; }

        public ICollection<Voo> Voos { get; set; }

    }
}
