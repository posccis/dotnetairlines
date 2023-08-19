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

        public async void AlterarFuncionario(Tripulante tripulante)
        {
            try
            {
                _ctxt.Tripulantes.Update(tripulante);
                await _ctxt.SaveChangesAsync();
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
                else if (sqlException != null && sqlException.Number == 515)
                {
                    throw new FlightBookingRepositoryException($"Provavelmente você esqueceu de inserir {coluna}! Confirme seus dados e tente novamente.");
                }
                else if (sqlException != null && sqlException.Number == 208)
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
                _ctxt.Dispose();
            }
        }

        public async void InserirFuncionario(Tripulante tripulante)
        {
            try
            {
                _ctxt.Tripulantes.Add(tripulante);
                await _ctxt.SaveChangesAsync();
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
                _ctxt.Dispose();
            }
        }

        public Tripulante ObterFuncionarioPorCPF(string cpf)
        {
            try
            {
                var tripulante = _ctxt.Tripulantes.FirstOrDefault(tri => tri.CPF == cpf);
                return tripulante;
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
                else if (sqlException != null && sqlException.Number == 515)
                {
                    throw new FlightBookingRepositoryException($"Provavelmente você esqueceu de inserir {coluna}! Confirme seus dados e tente novamente.");
                }
                else if (sqlException != null && sqlException.Number == 208)
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
                _ctxt.Dispose();
            }
        }

        public Tripulante ObterFuncionarioPorId(int id)
        {
            try
            {
                var tripulante = _ctxt.Tripulantes.FirstOrDefault(tri => tri.Id == id);
                return tripulante;
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
                else if (sqlException != null && sqlException.Number == 515)
                {
                    throw new FlightBookingRepositoryException($"Provavelmente você esqueceu de inserir {coluna}! Confirme seus dados e tente novamente.");
                }
                else if (sqlException != null && sqlException.Number == 208)
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
                _ctxt.Dispose();
            }
        }

        public async void RemoverFuncionario(Tripulante tripulante)
        {
            try
            {
                _ctxt.Tripulantes.Remove(tripulante);
                await _ctxt.SaveChangesAsync();
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
                else if (sqlException != null && sqlException.Number == 515)
                {
                    throw new FlightBookingRepositoryException($"Provavelmente você esqueceu de inserir {coluna}! Confirme seus dados e tente novamente.");
                }
                else if (sqlException != null && sqlException.Number == 208)
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
                _ctxt.Dispose();
            }
        }

        public List<Tripulante> RetornarTodosFuncionarios()
        {
            try
            {
                var tripulantes = _ctxt.Tripulantes.ToList();
                return tripulantes;
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
                else if (sqlException != null && sqlException.Number == 515)
                {
                    throw new FlightBookingRepositoryException($"Provavelmente você esqueceu de inserir {coluna}! Confirme seus dados e tente novamente.");
                }
                else if (sqlException != null && sqlException.Number == 208)
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
                _ctxt.Dispose();
            }
        }



    }
}
