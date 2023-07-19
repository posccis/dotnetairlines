using FlightBookingLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Lib.Contexto
{
    public class FlightBookingContext : DbContext
    {

        //protected IConfiguration _config;
        //protected string _strCnx;


        //public FlightBookingContext(IConfiguration config)
        //{

        //    _config = new ConfigurationManager().AddJsonFile("appsettings.json").Build();
            
        //    _strCnx = _config.GetConnectionString("FlightBookingStr");
        //}

        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Tripulante> Tripulantes { get; set; }
        public DbSet<Voo> Voos { get; set; }
        public DbSet<CartaoDeCredito> CartoesDeCredito { get; set; }
        public DbSet<Aviao> Avioes { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Copiloto> Copiloto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost;Database=FlightBooking;User Id=sa;Password=JK64victorjk;trusted_connection=true;encrypt=false;");


    }
}
