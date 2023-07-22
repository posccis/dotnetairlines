using FlightBooking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Models
{
    [Table("Copilotos")]
    public class Copiloto : IFuncionarioAviao
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
