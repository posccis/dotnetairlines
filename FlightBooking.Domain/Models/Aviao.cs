﻿using FlightBooking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Models
{
    [Table("Avioes")]
    public class Aviao : IAviao
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string QuantidadeAssentos { get; set; }
        public string Ano { get; set; }

        public ICollection<Voo> Voos { get; set; } 

    }
}
