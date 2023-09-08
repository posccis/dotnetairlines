using Estudo_API_tesseract.Exceptions;
using FlightBooking.Domain.Interfaces;
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
    public class AviaoRepositorio : IAviaoRepository<Aviao>
    {
        private FlightBookingContext _ctxt;
        private IConfiguration _config;
        public AviaoRepositorio(IConfiguration config)
        {
            _config = config;
            _ctxt = new FlightBookingContext(_config);
        }
        public async void AlterarAviao(Aviao aviao)
        {
            try
            {
                _ctxt.Avioes.Update(aviao);
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

        public async void InserirAviao(Aviao aviao)
        {
            try
            {
                _ctxt.Avioes.Add(aviao);
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

        public async Task<Aviao> ObterAviaoPorId(int id)
        {
            try
            {
                var aviao = await _ctxt.Avioes.FirstOrDefaultAsync(av => av.Id == id);
                return aviao;
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

        public async Task<Aviao> ObterAviaoPorMarca(string marca)
        {
            try
            {
                var aviao = await _ctxt.Avioes.FirstOrDefaultAsync(av => av.Marca == marca);
                return aviao;
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

        public async Task<Aviao> ObterAviaoPorModelo(string modelo)
        {
            try
            {
                var aviao = await _ctxt.Avioes.FirstOrDefaultAsync(av => av.Modelo == modelo);
                return aviao;
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

        public async void RemoverAviao(Aviao aviao)
        {
            try
            {
                _ctxt.Avioes.Remove(aviao);
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

        public async Task<List<Aviao>> RetornarTodosAvoes()
        {
            try
            {
                var avioes = await _ctxt.Avioes.ToListAsync();
                return avioes;
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
