using FlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Interfaces
{
    public interface IPassageiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public bool NecessidadesEspeciais { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Passaporte { get; set; }
        public string DataNascimento { get; set; }
        public string Endereco { get; set; }

        public ICollection<CartaoDeCredito> Cartoes { get; set; }
        public ICollection<Voo> Voos { get; set; }
    }
}
