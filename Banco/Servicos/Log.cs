using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Entidades;
using System.Globalization;
using System.Threading;

namespace Servicos
{
    class Log : Conta
    {

        private static string arquivo = @"C:\bancojw.txt";

        public static void Saque(int numeroConta, double valor)
        {
            int pos = 1;
            bool ero = false;
            StreamReader sr = new StreamReader(arquivo);
            int qtlinha = File.ReadAllLines(arquivo).Length;
            string[] dado = new string[qtlinha];
            while (!(sr.EndOfStream))
            {
                bool teste = false;
                string[] temp = sr.ReadLine().Split(",");
                int numero = int.Parse(temp[0]);
                string nome = temp[1];
                string doc = temp[2];
                double saldo = double.Parse(temp[3].Replace(".", ","));
                int tipo = int.Parse(temp[4]);

                if (numero == numeroConta)
                {
                    saldo -= valor;
                    dado[0] = $"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}";
                    ero = true;
                }
                else
                {
                    dado[pos] = $"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}";
                    pos++;
                }
            }
            Console.WriteLine("Aguarde a cédulas sairem...");
            Thread.Sleep(500);
            Console.WriteLine("--------------------------");
            sr.Close();
            File.WriteAllLines(arquivo, dado);

            if (ero == false)
            {
                Console.WriteLine("Conta não encontrada, tente novamente.");
                Console.WriteLine("----------------------");
            }
        }
        public static void Deposito(int numeroConta, double valor)
        {
            int pos = 1;
            bool ero = false;
            StreamReader sr = new StreamReader(arquivo);
            int qtlinha = File.ReadAllLines(arquivo).Length;
            string[] dado = new string[qtlinha];
            while (!(sr.EndOfStream))
            {
                bool teste = false;
                string[] temp = sr.ReadLine().Split(",");
                int numero = int.Parse(temp[0]);
                string nome = temp[1];
                string doc = temp[2];
                double saldo = double.Parse(temp[3].Replace(".", ","));
                int tipo = int.Parse(temp[4]);

                if (numero == numeroConta)
                {
                    saldo += valor;
                    dado[0] = $"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}";
                    ero = true;
                }
                else
                {
                    dado[pos] = $"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}";
                    pos++;
                }
            }
            Console.WriteLine("Aguarde o comprovante sair...");
            Thread.Sleep(500);
            Console.WriteLine("--------------------------");
            sr.Close();
            File.WriteAllLines(arquivo, dado);

            if (ero == false)
            {
                Console.WriteLine("Conta não encontrada, tente novamente.");
                Console.WriteLine("----------------------");
            }

        }


        public static void AbrirConta(ContaCorrente[] dados)
        {
            StreamWriter sw = File.AppendText(arquivo);
            foreach (ContaCorrente obj in dados)
            {
                int numero = obj.NumeroConta;
                string nome = obj.Nome;
                string doc = obj.Cpf;
                double saldo = obj.Saldo;
                int tipo = obj.Tipo;

                sw.WriteLine($"{numero},{nome},{doc},{saldo},{tipo}");
                sw.Close();
                break;
            }
            Console.WriteLine("aguarde um instante.");
            Thread.Sleep(500);
            Console.WriteLine("Tudo pronto.\n----------------------");
        }
        public static void AbrirConta(ContaJuridica[] dados)
        {
            StreamWriter sw = File.AppendText(arquivo);
            foreach (ContaJuridica obj in dados)
            {
                int numero = obj.NumeroConta;
                string nome = obj.Nome;
                string doc = obj.Cnpj;
                double saldo = obj.Saldo;
                int tipo = obj.Tipo;
                sw.WriteLine($"{numero},{nome},{doc},{saldo},{tipo}");
                sw.Close();
                break;
            }
            Console.WriteLine("aguarde um instante.");
            Thread.Sleep(500);
            Console.WriteLine("Tudo pronto.\n----------------------");
        }


        public static void ExcluirConta(int numeroConta)
        {
            int pos = 0;
            bool ero = false;
            StreamReader sr = new StreamReader(arquivo);
            int qtlinha = File.ReadAllLines(arquivo).Length;
            string[] dado = new string[qtlinha-1];
            while (!(sr.EndOfStream))
            {
                
                string[] temp = sr.ReadLine().Split(",");
                int numero = int.Parse(temp[0]);
                string nome = temp[1];
                string doc = temp[2];
                double saldo = double.Parse(temp[3].Replace(".", ","));
                int tipo = int.Parse(temp[4]);

                if (numero == numeroConta)
                {
                    ero = true;
                }
                else
                {
                    dado[pos] = $"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}";
                    pos++;
                }
            }
            Console.WriteLine("Aguarde...\nConta localizada");
            Thread.Sleep(500);
            Console.WriteLine("--------------------------");
            sr.Close();
            File.WriteAllLines(arquivo, dado);

            if (ero == false)
            {
                Console.WriteLine("Conta não encontrada, tente novamente.");
                Console.WriteLine("----------------------");
            }
        }

    }


}
