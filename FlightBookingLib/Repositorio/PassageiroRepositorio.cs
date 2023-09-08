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
    public class PassageiroRepositorio : IPassageiroRepository<Passageiro>
    {
        private FlightBookingContext _ctxt;
        private IConfiguration _config;

        public PassageiroRepositorio(IConfiguration config)
        {
            _config = config;
            _ctxt = new FlightBookingContext(_config);
        }

        public async void AlterarPassageiro(Passageiro passageiro)
        {
            try
            {
                _ctxt.Passageiros.Update(passageiro);
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

        public async void InserirPassageiro(Passageiro passageiro)
        {
            try
            {
                _ctxt.Passageiros.Add(passageiro);
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

        public async Task<Passageiro> ObterPassageiroPorCPF(string cpf)
        {
            try
            {
                var passageiro = await _ctxt.Passageiros.FirstOrDefaultAsync(pass => pass.CPF == cpf);
                return passageiro;
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
        public async Task<Passageiro> ObterPassageiroPorRG(string rg)
        {
            try
            {
                var passageiro = await _ctxt.Passageiros.FirstOrDefaultAsync(pass => pass.RG == rg);
                return passageiro;
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
        public async Task<Passageiro> ObterPassageiroPorPassaporte(string passaporte)
        {
            try
            {
                var passageiro = await _ctxt.Passageiros.FirstOrDefaultAsync(pass => pass.Passaporte == passaporte);
                return passageiro;
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

        public async Task<Passageiro> ObterPassageiroPorId(int id)
        {
            try
            {
                var passageiro = await _ctxt.Passageiros.FirstOrDefaultAsync(pass => pass.Id == id);
                return passageiro;
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

        public async void RemoverPassageiro(Passageiro passageiro)
        {
            try
            {
                _ctxt.Passageiros.Remove(passageiro);
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

        public async Task<List<Passageiro>> RetornarTodosPassageiros()
        {
            try
            {
                var passageiros = await _ctxt.Passageiros.ToListAsync();
                return passageiros;
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
