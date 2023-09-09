using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
    }
}
