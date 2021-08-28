using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    sealed class ContaJuridica : Conta
    {
        public long Cnpj { get; set; }

        public ContaJuridica(string nome, int numeroConta, double saldo, long cnpj) : base(nome, numeroConta, saldo)
        {
            Cnpj = cnpj;
            Tipo = 2;
        }
            

    }
}
