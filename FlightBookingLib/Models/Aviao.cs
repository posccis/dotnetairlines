using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingLib.Models
{
    [Table("Avioes")]
    public class Aviao
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string QuantidadeAssentos { get; set; }
        public string Ano { get; set; }

        public ICollection<Voo> Voos { get; set; } 

    }
}
