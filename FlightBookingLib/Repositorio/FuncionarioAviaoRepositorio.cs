using FlightBooking.Lib.Contexto;
using FlightBooking.Lib.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Lib.Repositorio
{
    public class FuncionarioAviaoRepositorio : IFuncionarioAviaoRepository<IFuncionarioAviao>
    {
        private FlightBookingContext _ctxt;
        private IConfiguration _config;
        public FuncionarioAviaoRepositorio(IConfiguration config)
        {
            _config = config;
            _ctxt = new FlightBookingContext(_config);
        }
        public void AlterarFuncionario(IFuncionarioAviao funcionario)
        {
            throw new NotImplementedException();
        }

        public void AlterarTempoDeVoo(string cpf)
        {
            throw new NotImplementedException();
        }

        public void CadastrarFuncionario(IFuncionarioAviao funcionario)
        {
            throw new NotImplementedException();
        }

        public IFuncionarioAviao ObterDadosFuncionarioPorCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public IFuncionarioAviao ObterDadosFuncionarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoverFuncionario(IFuncionarioAviao funcionario)
        {
            throw new NotImplementedException();
        }

        public ICollection<IFuncionarioAviao> RetornarTodosFuncionarios()
        {
            throw new NotImplementedException();
        }

        public ICollection<IFuncionarioAviao> RetornarTodosOsCopilotos()
        {
            throw new NotImplementedException();
        }

        public ICollection<IFuncionarioAviao> RetornarTodosOsPilotos()
        {
            throw new NotImplementedException();
        }
    }
}
