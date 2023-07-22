using Estudo_API_tesseract.Exceptions;
using FlightBooking.Domain.Models;
using FlightBooking.Lib.Contexto;
using FlightBooking.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FlightBooking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Repository.Repositorio
{
    public class TripulacaoRepositorio : IFuncionarioAviaoRepository<Tripulante>
    {
        private FlightBookingContext _ctxt;
        private IConfiguration _config;
        public TripulacaoRepositorio(IConfiguration config)
        {
            _config = config;
            _ctxt = new FlightBookingContext(_config);
        }

        public void AlterarFuncionario(Tripulante tripulante)
        {
            throw new NotImplementedException();
        }

        public void AlterarTempoDeVoo(string cpf)
        {
            throw new NotImplementedException();
        }

        public void InserirFuncionario(Tripulante tripulante)
        {
            try
            {
                _ctxt.Tripulantes.Add(tripulante);
            }
            catch (DbUpdateException dbe)
            {

                var sqlException = dbe.GetBaseException() as SqlException;
                int posicaoInicio = sqlException.Message.IndexOf("'") + 1;
                int posicaoFim = sqlException.Message.IndexOf("'", posicaoInicio);
                var coluna = sqlException.Message.Substring(posicaoInicio, posicaoFim - posicaoInicio);
                if (sqlException != null && sqlException.Number == 2601)
                {
                    throw new FlightBookingRepositoryException($"Provavelmente você está tentando inserir um {coluna} que já está em uso! Confirme seus dados e tente novamente.");
                }
                else if(sqlException != null && sqlException.Number == 515)
                {
                    throw new FlightBookingRepositoryException($"Provavelmente você esqueceu de inserir {coluna}! Confirme seus dados e tente novamente.");
                }
                else if(sqlException != null && sqlException.Number == 208)
                {
                    throw new FlightBookingRepositoryException("Aparentemente a tabela a qual você está tentando inserir os dados não existe! Confirme o nome da tabela e tente novamente.");
                }

                throw new FlightBookingRepositoryException(dbe.Message);
            }
            catch (Exception ex)
            {
                throw new FlightBookingRepositoryException(ex.Message);

            }
            finally
            {
                _ctxt.SaveChangesAsync();
            }
        }

        public Tripulante ObterFuncionarioPorCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public Tripulante ObterFuncionarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoverFuncionario(Tripulante tripulante)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tripulante> RetornarTodosFuncionarios()
        {
            throw new NotImplementedException();
        }

        public ICollection<Tripulante> RetornarTodosOsCopilotos()
        {
            throw new NotImplementedException();
        }

        public ICollection<Tripulante> RetornarTodosOsPilotos()
        {
            throw new NotImplementedException();
        }
    }
}
