using FlightBooking.Domain.Models;
using FlightBooking.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Service.Validacoes
{
    public class PassageiroValidacao
    {
        public PassageiroValidacao() { }

        public void ValidarPassageiroInsercao(Passageiro passageiro) 
        {
            if (passageiro == null) throw new PassageiroValidacaoException(0, "O objeto do passageiro está nulo!");
            if (string.IsNullOrEmpty(passageiro.Nome)) throw new PassageiroValidacaoException(1, "O nome do passageiro está vazio! É necessário informar um nome.");
            if (string.IsNullOrEmpty(passageiro.CPF)) throw new PassageiroValidacaoException(2, "O CPF do passageiro está vazio! É necessário informar um CPF.");
            if (!DateTime.TryParse(passageiro.DataNascimento, out var temp)) throw new PassageiroValidacaoException(3, "Data de nascimento invalida! É necessário informar um data de nascimento válida.");
            if (String.IsNullOrEmpty(passageiro.Genero)) throw new PassageiroValidacaoException(4, "O genêro está vázio! É necessário informar algum valor ao campo.");
            if (String.IsNullOrEmpty(passageiro.RG)) throw new PassageiroValidacaoException(5, "O RG do passageiro está vázio! É necessário informar um RG.");
        }

        public void ValidarRetornoTodosPassageiros(List<Passageiro> passageiros)
        {

        }
    }
}
