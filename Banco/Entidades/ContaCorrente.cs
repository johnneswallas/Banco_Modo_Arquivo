using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    sealed class ContaCorrente : Conta
    {
        public string Cpf { get; set; }
        

        public ContaCorrente(int numeroConta, string nome, string cpf, double saldo) :base(numeroConta, nome, saldo)
        {
            Cpf = cpf;
            Tipo = 1;
            Saldo = saldo;
        }

        public override string ToString()
        {
            return $"{NumeroConta},{Nome},{Cpf},{Saldo},{Tipo}";
        }

    }
}
