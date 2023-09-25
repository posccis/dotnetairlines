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
            if (passageiros == null || passageiros.Count <= 0) throw new PassageiroValidacaoException(6, "A lista de passageiros foi retornada vazia! Tente novamente mais tarde.");
        }
        public void ValidarPassageiroRetornado(Passageiro passageiro)
        {
            if (passageiro == null) throw new PassageiroValidacaoException(7, "O objeto do passageiro foi retornado nulo!");
            if (string.IsNullOrEmpty(passageiro.Nome)) throw new PassageiroValidacaoException(8, "O passageiro foi retornado com o nome vazio!");
            if (string.IsNullOrEmpty(passageiro.CPF)) throw new PassageiroValidacaoException(9, "O passageiro foi retornado com o CPF vazio!");
            if (!DateTime.TryParse(passageiro.DataNascimento, out var temp)) throw new PassageiroValidacaoException(10, "O passageiro foi retornado com uma data de nascimento vazia ou invalida!");
            if (String.IsNullOrEmpty(passageiro.Genero)) throw new PassageiroValidacaoException(11, "O passageiro foi retornado sem um valor no campo genero!");
            if (String.IsNullOrEmpty(passageiro.RG)) throw new PassageiroValidacaoException(12, "O passageiro foi retornado sem um RG!");
        }
    }
}
