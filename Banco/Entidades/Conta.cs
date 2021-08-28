using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    abstract class Conta
    {
        public string Nome { get; set; }
        public int NumeroConta { get; set; }
        public static double Saldo { get; protected set; }
        public int Tipo { get; protected set; }

        public Conta(string nome, int numeroConta, double saldo)
        {
            Nome = nome;
            NumeroConta = numeroConta;
            Saldo = saldo;
            Tipo = 0;
        }
    }
}
