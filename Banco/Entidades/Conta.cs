using System;
using System.Collections.Generic;
using System.Text;


namespace Entidades
{
    abstract class Conta
    {
        public string Nome { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo { get; protected set; }
        public int Tipo { get; protected set; }
        

        protected Conta() { }
        protected Conta(int numeroConta, string nome, double saldo)
        {
            Nome = nome;
            NumeroConta = numeroConta;
            Tipo = 0;
            Saldo = saldo;
        }
        
        
    }
}
