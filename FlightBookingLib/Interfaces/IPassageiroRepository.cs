using FlightBooking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Repository.Interfaces
{
    public interface IPassageiroRepository<T> where T : IPassageiro
    {
        void InserirPassageiro(T passageiro);
        Task<T> ObterPassageiroPorId(int id);
        Task<T> ObterPassageiroPorCPF(string cpf);
        Task<T> ObterPassageiroPorRG(string rg);
        Task<T> ObterPassageiroPorPassaporte(string passaporte);
        void AlterarPassageiro(T passageiro);
        void RemoverPassageiro(T passageiro);
        Task<List<T>> RetornarTodosPassageiros();
    }
}
