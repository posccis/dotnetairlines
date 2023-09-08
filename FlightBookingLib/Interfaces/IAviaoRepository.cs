using FlightBooking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Repository.Interfaces
{
    public interface IAviaoRepository<T> where T : IAviao
    {
        void InserirAviao(T aviao);
        Task<T> ObterAviaoPorId(int id);
        Task<T> ObterAviaoPorModelo(string modelo);
        Task<T> ObterAviaoPorMarca(string marca);
        void AlterarAviao(T aviao);
        void RemoverAviao(T aviao);
        Task<List<T>> RetornarTodosAvoes();
    }
}
