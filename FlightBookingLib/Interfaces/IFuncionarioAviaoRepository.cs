using FlightBooking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Repository.Interfaces
{
    public interface IFuncionarioAviaoRepository<T> where T : IFuncionarioAviao
    {
        void InserirFuncionario( T funcionario);
        T ObterFuncionarioPorId(int id);
        T ObterFuncionarioPorCPF(string cpf);
        void AlterarFuncionario(T funcionario);
        void RemoverFuncionario(T funcionario);
        List<T> RetornarTodosFuncionarios();

    }
}
