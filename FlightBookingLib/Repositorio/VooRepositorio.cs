using FlightBooking.Domain.Models;
using FlightBooking.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Repository.Repositorio
{
    public class VooRepositorio : IVooRepository<Voo>
    {
        public void AlterarVoo(Voo Voo)
        {
            throw new NotImplementedException();
        }

        public void InserirVoo(Voo Voo)
        {
            throw new NotImplementedException();
        }

        public List<Voo> ObterTodosOsVoos()
        {
            throw new NotImplementedException();
        }

        public Voo ObterVooPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public void RemoverVoo(Voo Voo)
        {
            throw new NotImplementedException();
        }
    }
}
