﻿using FlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Interfaces
{
    public interface IVoo
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public Piloto Piloto { get; set; }
        public Copiloto Copiloto { get; set; }
        public Aviao Aviao { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public string Duracao { get; set; }
        public int QuantAssentosPrimeiraClasse { get; set; }
        public int QuantAssentosClasseEconomica { get; set; }
        public float ValorPrimeiraClasse { get; set; }
        public float ValorClasseEconomica { get; set; }
        public bool Internacional { get; set; }
    }
}
