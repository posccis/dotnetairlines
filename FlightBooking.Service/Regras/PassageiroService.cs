using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Estudo_API_tesseract.Exceptions;
using FlightBooking.Domain.Models;
using FlightBooking.Repository.Repositorio;
using FlightBooking.Service.Exceptions;
using FlightBooking.Service.Validacoes;
using Microsoft.Extensions.Configuration;

namespace FlightBooking.Service.Regras
{
    public class PassageiroService
    {
        private IConfiguration _config;
        private PassageiroRepositorio _passRepo;
        public PassageiroValidacao passVal;
        public PassageiroService() 
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _passRepo = new PassageiroRepositorio(_config);
            passVal = new PassageiroValidacao();
        }

        public async Task CadastrarPassageiro(Passageiro passageiro) 
        {
            try
            {
                passVal.ValidarPassageiroInsercao(passageiro);
                _passRepo.InserirPassageiro(passageiro);

            }
            catch (FlightBookingRepositoryException repoEx)
            {

                throw new PassageiroServiceException("Erro ao cadastrar passageiro! Mais detalhes:" + repoEx.Message);
            }
            catch(PassageiroValidacaoException passEx) 
            {
                if (passEx.Codigo == 0) throw new PassageiroServiceException("Tente novamente a inserção e certifique de que preencheu os campos antes de enviar!" + passEx.Message);
                else if (passEx.Codigo == 1) throw new PassageiroServiceException("O nome do passageiro é um campo obrigatório! Preencha e envie novamente." + passEx.Message);
                else if (passEx.Codigo == 2) throw new PassageiroServiceException("O CPF do passageiro é um campo obrigatório! Preencha e envie novamente." + passEx.Message);
                else if (passEx.Codigo == 3) throw new PassageiroServiceException("A data de nascimento informada não é válida! Corrija e envie novamente." + passEx.Message);
                else if (passEx.Codigo == 4) throw new PassageiroServiceException("O campo gênero não foi preenchido! Escolha uma das opções e envie novamnete." + passEx.Message);
                else if (passEx.Codigo == 5) throw new PassageiroServiceException("O RG do passageiro é um campo obrigatório! Preencha e envie novamente." + passEx.Message);
            }
        }
        public async Task RetornaTodosPassageiros(Passageiro passageiro) 
        {
            try
            {
                await _passRepo.RetornarTodosPassageiros();
                passVal.ValidarPassageiroInsercao(passageiro);


            }
            catch (FlightBookingRepositoryException repoEx)
            {

                throw new PassageiroServiceException("Erro ao cadastrar passageiro! Mais detalhes:" + repoEx.Message);
            }
            catch(PassageiroValidacaoException passEx) 
            {
                if (passEx.Codigo == 0) throw new PassageiroServiceException("Tente novamente a inserção e certifique de que preencheu os campos antes de enviar!" + passEx.Message);
                else if (passEx.Codigo == 1) throw new PassageiroServiceException("O nome do passageiro é um campo obrigatório! Preencha e envie novamente." + passEx.Message);
                else if (passEx.Codigo == 2) throw new PassageiroServiceException("O CPF do passageiro é um campo obrigatório! Preencha e envie novamente." + passEx.Message);
                else if (passEx.Codigo == 3) throw new PassageiroServiceException("A data de nascimento informada não é válida! Corrija e envie novamente." + passEx.Message);
                else if (passEx.Codigo == 4) throw new PassageiroServiceException("O campo gênero não foi preenchido! Escolha uma das opções e envie novamnete." + passEx.Message);
                else if (passEx.Codigo == 5) throw new PassageiroServiceException("O RG do passageiro é um campo obrigatório! Preencha e envie novamente." + passEx.Message);
            }
        }
    }
}
