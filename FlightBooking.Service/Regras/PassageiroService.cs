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
        public async Task<List<Passageiro>> RetornaTodosPassageiros(Passageiro passageiro) 
        {
            List<Passageiro> passageiros = null;
            try
            {
                passageiros = await _passRepo.RetornarTodosPassageiros();
                passVal.ValidarRetornoTodosPassageiros(passageiros);
                return passageiros;


            }
            catch (FlightBookingRepositoryException repoEx)
            {

                throw new PassageiroServiceException("Erro ao tentar obter todos os passageiros! Mais detalhes:" + repoEx.Message);
            }
            catch(PassageiroValidacaoException passEx) 
            {
                if (passEx.Codigo == 6) throw new PassageiroServiceException("Não foi localizado nenhum passageiro! Tente novamente ou entre em contato com o suporte." + passEx.Message);
                
                else throw new PassageiroServiceException("Houve um erro ao tentar obter a lista de passageiros. Tente novamente mais tarde ou entre em contato com o suporte. Mais detalhes: "+passEx.Message); 
            }
        }

        public async Task<Passageiro> RetornaPassageiroPorId(int id)
        {
            Passageiro pass = null;
            try
            {
                pass = await _passRepo.ObterPassageiroPorId(id);
                passVal.ValidarPassageiroRetornado(pass);
                return pass;
            }
            catch (FlightBookingRepositoryException repoEx)
            {

                throw new PassageiroServiceException("Erro ao obter passageiro! Mais detalhes:" + repoEx.Message);
            }
            catch (PassageiroValidacaoException passEx)
            {
                if (passEx.Codigo == 7) throw new PassageiroServiceException("Não foi localizado nenhum passageiro! Cerfique-se de que todos os dados estão corretos e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 8) throw new PassageiroServiceException("O passageiro encontrado não possui um nome cadastrado! Certifique-se de que há um nome e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 9) throw new PassageiroServiceException("O passageiro encontrado não possui um CPF cadastrado! Certifique-se de que há um CPF e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 10) throw new PassageiroServiceException("O passageiro encontrado não possui uma data de nascimento válida! Certifique-se de que há uma data de nascimento válida e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 11) throw new PassageiroServiceException("O passageiro não possui algo selecionado no campo genêro! Certifique-se de que algo foi selecionado e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 12) throw new PassageiroServiceException("O passageiro não poossui um RG cadastrado! Certifique-se de que há um RG cadastrado e tente novamente." + passEx.Message);
                else throw new PassageiroServiceException("Erro ao obter passageiro! Consulte o supote.\nMais detalhes: " + passEx.Message);
            }
        }
        public async Task<Passageiro> RetornaPassageiroPorCPF(string cpf)
        {
            Passageiro pass = null;
            try
            {
                pass = await _passRepo.ObterPassageiroPorCPF(cpf);
                passVal.ValidarPassageiroRetornado(pass);
                return pass;
            }
            catch (FlightBookingRepositoryException repoEx)
            {

                throw new PassageiroServiceException("Erro ao obter passageiro! Mais detalhes:" + repoEx.Message);
            }
            catch (PassageiroValidacaoException passEx)
            {
                if (passEx.Codigo == 7) throw new PassageiroServiceException("Não foi localizado nenhum passageiro! Cerfique-se de que todos os dados estão corretos e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 8) throw new PassageiroServiceException("O passageiro encontrado não possui um nome cadastrado! Certifique-se de que há um nome e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 9) throw new PassageiroServiceException("O passageiro encontrado não possui um CPF cadastrado! Certifique-se de que há um CPF e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 10) throw new PassageiroServiceException("O passageiro encontrado não possui uma data de nascimento válida! Certifique-se de que há uma data de nascimento válida e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 11) throw new PassageiroServiceException("O passageiro não possui algo selecionado no campo genêro! Certifique-se de que algo foi selecionado e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 12) throw new PassageiroServiceException("O passageiro não poossui um RG cadastrado! Certifique-se de que há um RG cadastrado e tente novamente." + passEx.Message);
                else throw new PassageiroServiceException("Erro ao obter passageiro! Consulte o supote.\nMais detalhes: " + passEx.Message);
            }
        }
        public async Task<Passageiro> RetornaPassageiroPorRG(string rg)
        {
            Passageiro pass = null;
            try
            {
                pass = await _passRepo.ObterPassageiroPorRG(rg);
                passVal.ValidarPassageiroRetornado(pass);
                return pass;
            }
            catch (FlightBookingRepositoryException repoEx)
            {

                throw new PassageiroServiceException("Erro ao obter passageiro! Mais detalhes:" + repoEx.Message);
            }
            catch (PassageiroValidacaoException passEx)
            {
                if (passEx.Codigo == 7) throw new PassageiroServiceException("Não foi localizado nenhum passageiro! Cerfique-se de que todos os dados estão corretos e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 8) throw new PassageiroServiceException("O passageiro encontrado não possui um nome cadastrado! Certifique-se de que há um nome e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 9) throw new PassageiroServiceException("O passageiro encontrado não possui um CPF cadastrado! Certifique-se de que há um CPF e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 10) throw new PassageiroServiceException("O passageiro encontrado não possui uma data de nascimento válida! Certifique-se de que há uma data de nascimento válida e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 11) throw new PassageiroServiceException("O passageiro não possui algo selecionado no campo genêro! Certifique-se de que algo foi selecionado e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 12) throw new PassageiroServiceException("O passageiro não poossui um RG cadastrado! Certifique-se de que há um RG cadastrado e tente novamente." + passEx.Message);
                else throw new PassageiroServiceException("Erro ao obter passageiro! Consulte o supote.\nMais detalhes: " + passEx.Message);
            }
        }
        public async Task<Passageiro> RetornaPassageiroPorPassaporte(string passaporte)
        {
            Passageiro pass = null;
            try
            {
                pass = await _passRepo.ObterPassageiroPorPassaporte(passaporte);
                passVal.ValidarPassageiroRetornado(pass);
                return pass;
            }
            catch (FlightBookingRepositoryException repoEx)
            {

                throw new PassageiroServiceException("Erro ao obter passageiro! Mais detalhes:" + repoEx.Message);
            }
            catch (PassageiroValidacaoException passEx)
            {
                if (passEx.Codigo == 7) throw new PassageiroServiceException("Não foi localizado nenhum passageiro! Cerfique-se de que todos os dados estão corretos e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 8) throw new PassageiroServiceException("O passageiro encontrado não possui um nome cadastrado! Certifique-se de que há um nome e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 9) throw new PassageiroServiceException("O passageiro encontrado não possui um CPF cadastrado! Certifique-se de que há um CPF e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 10) throw new PassageiroServiceException("O passageiro encontrado não possui uma data de nascimento válida! Certifique-se de que há uma data de nascimento válida e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 11) throw new PassageiroServiceException("O passageiro não possui algo selecionado no campo genêro! Certifique-se de que algo foi selecionado e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 12) throw new PassageiroServiceException("O passageiro não poossui um RG cadastrado! Certifique-se de que há um RG cadastrado e tente novamente." + passEx.Message);
                else throw new PassageiroServiceException("Erro ao obter passageiro! Consulte o supote.\nMais detalhes: " + passEx.Message);
            }
        }
        public async Task RemoverPassageiro(int id)
        {
            Passageiro pass = null;
            try
            {
                pass = await _passRepo.ObterPassageiroPorId(id);
                passVal.ValidarPassageiroRetornado(pass);
                _passRepo.RemoverPassageiro(pass);
            }
            catch (FlightBookingRepositoryException repoEx)
            {

                throw new PassageiroServiceException("Erro ao tentar remover passageiro! Mais detalhes:" + repoEx.Message);
            }
            catch (PassageiroValidacaoException passEx)
            {
                if (passEx.Codigo == 7) throw new PassageiroServiceException("Não foi localizado nenhum passageiro! Cerfique-se de que todos os dados estão corretos e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 8) throw new PassageiroServiceException("O passageiro encontrado não possui um nome cadastrado! Certifique-se de que há um nome e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 9) throw new PassageiroServiceException("O passageiro encontrado não possui um CPF cadastrado! Certifique-se de que há um CPF e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 10) throw new PassageiroServiceException("O passageiro encontrado não possui uma data de nascimento válida! Certifique-se de que há uma data de nascimento válida e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 11) throw new PassageiroServiceException("O passageiro não possui algo selecionado no campo genêro! Certifique-se de que algo foi selecionado e tente novamente." + passEx.Message);
                else if (passEx.Codigo == 12) throw new PassageiroServiceException("O passageiro não poossui um RG cadastrado! Certifique-se de que há um RG cadastrado e tente novamente." + passEx.Message);
                else throw new PassageiroServiceException("Erro ao obter passageiro! Consulte o supote.\nMais detalhes: " + passEx.Message);
            }
        }

        public async Task AtualizaPassageiro(Passageiro passageiro) 
        {
            try
            {
                passVal.ValidarPassageiroInsercao(passageiro);
                _passRepo.AlterarPassageiro(passageiro);

            }
            catch (FlightBookingRepositoryException repoEx)
            {

                throw new PassageiroServiceException("Erro ao atualizar passageiro! Mais detalhes:" + repoEx.Message);
            }
            catch (PassageiroValidacaoException passEx)
            {
                if (passEx.Codigo == 0) throw new PassageiroServiceException("Tente novamente a atualização e certifique-se de que preencheu os campos antes de enviar!" + passEx.Message);
                else if (passEx.Codigo == 1) throw new PassageiroServiceException("O nome do passageiro é um campo obrigatório! Preencha e envie novamente." + passEx.Message);
                else if (passEx.Codigo == 2) throw new PassageiroServiceException("O CPF do passageiro é um campo obrigatório! Preencha e envie novamente." + passEx.Message);
                else if (passEx.Codigo == 3) throw new PassageiroServiceException("A data de nascimento informada não é válida! Corrija e envie novamente." + passEx.Message);
                else if (passEx.Codigo == 4) throw new PassageiroServiceException("O campo gênero não foi preenchido! Escolha uma das opções e envie novamnete." + passEx.Message);
                else if (passEx.Codigo == 5) throw new PassageiroServiceException("O RG do passageiro é um campo obrigatório! Preencha e envie novamente." + passEx.Message);
            }
        }
    }
}
