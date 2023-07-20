using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Lib.Interfaces
{
    public interface IFuncionarioAviaoRepository<T> where T : IFuncionarioAviao
    {
        void CadastrarFuncionario( T funcionario);
        T ObterDadosFuncionarioPorId(int id);
        T ObterDadosFuncionarioPorCPF(string cpf);
        void AlterarFuncionario(T funcionario);
        void AlterarTempoDeVoo(string cpf);
        void RemoverFuncionario(T funcionario);
        ICollection<T> RetornarTodosFuncionarios();
        ICollection<T> RetornarTodosOsPilotos();
        ICollection<T> RetornarTodosOsCopilotos();
    }
}
