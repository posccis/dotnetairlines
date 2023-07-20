﻿using FlightBooking.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingLib.Models
{
    [Table("Pilotos")]
    public class Piloto : IFuncionarioAviao
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
