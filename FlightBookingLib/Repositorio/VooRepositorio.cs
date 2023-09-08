using Estudo_API_tesseract.Exceptions;
using FlightBooking.Domain.Models;
using FlightBooking.Lib.Contexto;
using FlightBooking.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Repository.Repositorio
{
    public class VooRepositorio : IVooRepository<Voo>
    {
        private FlightBookingContext _ctxt;
        private IConfiguration _config;
        public VooRepositorio(IConfiguration config)
        {
            _config = config;
            _ctxt = new FlightBookingContext(_config);
        }
        public async void AlterarVoo(Voo voo)
        {
            try
            {
                _ctxt.Voos.Update(voo);
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

        public async void InserirVoo(Voo voo)
        {
            try
            {
                _ctxt.Voos.Add(voo);
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

        public List<Voo> ObterTodosOsVoos()
        {
            try
            {
                var voos = _ctxt.Voos.ToList();
                return voos;
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

        public Voo ObterVooPorId(int id)
        {
            try
            {
                var voo = _ctxt.Voos.FirstOrDefault(voo => voo.Id == id);
                return voo;
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

        public void RemoverVoo(Voo voo)
        {
            try
            {
                _ctxt.Voos.Remove(voo);
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
    }
}
