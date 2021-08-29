using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    sealed class ContaJuridica : Conta
    {
        public string Cnpj { get; set; }

        public ContaJuridica(int numeroConta, string nome, string cnpj, double saldo) : base(numeroConta, nome, saldo)
        {
            Cnpj = cnpj;
            Tipo = 2;
            Saldo = saldo;
        }
        public override string ToString()
        {
            return $"{NumeroConta},{Nome},{Cnpj},{Saldo},{Tipo}";
        }

    }
}
