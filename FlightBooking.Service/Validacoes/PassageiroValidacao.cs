using FlightBooking.Domain.Models;
using FlightBooking.Service.Exceptions;
using System;
using System.Collections.Generic;
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
            if (string.IsNullOrEmpty(passageiro.CPF)) throw new PassageiroValidacaoException(3, "O CPF do passageiro está vazio! É necessário informar um CPF.");
        }
    }
}
