using FlightBooking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Repository.Interfaces
{
    public interface ICartaoDeCreditoRepository<T> where T : ICartaoDeCredito
    {
        void InserirCartao(T aviao);
        Task<T> ObterCartaoPorId(int id);
        Task<T> ObterCartaoPorIdPassageiro(int id);
        Task<T> ObterCartaoPorTitular(string id);
        Task<T> ObterCartaoPorNumero(string numero);
        void AlterarCartao(T cartao);
        void RemoverCartao(T aviao);
        Task<List<T>> RetornarTodosCartoes();
    }
}
