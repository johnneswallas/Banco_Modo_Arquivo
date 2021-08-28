using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    sealed class ContaCorrente : Conta
    {
        public long Cpf { get; set; }

        public ContaCorrente(string nome, int numeroConta, double saldo, long cpf) :base(nome, numeroConta, saldo)
        {
            Cpf = cpf;
            Tipo = 1;
        }

    }
}
