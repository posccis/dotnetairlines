using FlightBooking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Repository.Interfaces
{
    public interface IVooRepository<T> where T : IVoo
    {
        void InserirVoo(T voo);
        void AlterarVoo(T voo);
        void RemoverVoo(T voo);
        List<T> ObterTodosOsVoos();
        T ObterVooPorId(int id);
    }
}
