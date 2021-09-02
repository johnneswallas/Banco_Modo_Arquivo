using System;
using System.Collections.Generic;
using System.IO;
using Entidades;
using System.Globalization;
using System.Threading;



namespace Servicos
{
    class Log : Conta
    {

        private static string arquivo = @"C:\bancojw.txt";
        private static ITaxa taxa = new Taxa();

        public static void Saque(int numeroConta, double valor)
        {
            bool ero = false;
            StreamReader sr = new StreamReader(arquivo);
            List<string> dado = new List<string>();
            while (!(sr.EndOfStream))
            {
                string[] temp = sr.ReadLine().Split(",");
                if (temp != null)
                {
                    int numero = int.Parse(temp[0]);
                    string nome = temp[1];
                    string doc = temp[2];
                    double saldo = double.Parse(temp[3].Replace(".", ","));
                    int tipo = int.Parse(temp[4]);

                    if (numero == numeroConta)
                    {
                        double teste = taxa.Saque(valor);
                        saldo -= valor + teste;
                        string dados = $"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}";
                        dado.Add(dados);
                        ero = true;
                    }
                    else
                    {
                        string dadosCliente = $"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}";
                        dado.Add(dadosCliente);
                    }
                }

            }
            sr.Close();
            File.WriteAllLines(arquivo, dado);
            if (ero == false)
            {
                Console.WriteLine("Conta não encontrada, tente novamente.");
                Console.WriteLine("----------------------");
            }
            else
            {
                Console.WriteLine("Aguarde a cédulas sairem...");
                Thread.Sleep(500);
                Console.WriteLine("--------------------------");
            }


        }
        public static void Deposito(int numeroConta, double valor)
        {

            bool ero = false;
            StreamReader sr = new StreamReader(arquivo);

            List<string> dado = new List<string>();

            while (!(sr.EndOfStream))
            {
                string[] temp = sr.ReadLine().Split(",");
                if (temp != null)
                {
                    int numero = int.Parse(temp[0]);
                    string nome = temp[1];
                    string doc = temp[2];
                    double saldo = double.Parse(temp[3].Replace(".", ","));
                    int tipo = int.Parse(temp[4]);
                    string dados = $"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}";

                    if (numero == numeroConta)
                    {
                        saldo += valor;
                        dado.Add(dados);
                        ero = true;
                    }
                    else
                    {
                        dado.Add(dados);
                    }
                }
            }
            sr.Close();
            File.WriteAllLines(arquivo, dado);
            if (ero == false)
            {
                Console.WriteLine("Conta não encontrada, tente novamente.");
                Console.WriteLine("----------------------");
            }
            else
            {
                Console.WriteLine("Aguarde o comprovante sair...");
                Thread.Sleep(500);
                Console.WriteLine("--------------------------");
            }

        }
        public static void Saldo(int numeroConta)
        {
            bool ero = false;
            StreamReader sr = new StreamReader(arquivo);
            while (!(sr.EndOfStream))
            {
                string[] temp = sr.ReadLine().Split(",");
                if (temp != null)
                {
                    int numero = int.Parse(temp[0]);
                    string nome = temp[1];
                    string doc = temp[2];
                    double saldo = double.Parse(temp[3].Replace(".", ","));
                    int tipo = int.Parse(temp[4]);

                    if (numero == numeroConta)
                    {
                        Console.WriteLine($"Número da conta: {numero}\nNome: {nome}\nDocumento: {doc}\nSaldo: {saldo}\nTipo: {tipo}");
                        ero = true;
                        break;
                    }

                }
            }
            if(ero == false)
            {
                Console.WriteLine("Conta não encontrada, tente novamente.");
                Console.WriteLine("----------------------");
            }
        }

        public static void AbrirConta(List<ContaCorrente> dados)
        {
            StreamWriter sw = File.AppendText(arquivo);
            foreach (ContaCorrente obj in dados)
            {
                int numero = obj.NumeroConta;
                string nome = obj.Nome;
                string doc = obj.Cpf;
                double saldo = obj.Saldo;
                int tipo = obj.Tipo;

                sw.WriteLine($"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}");
                sw.Close();
                Console.WriteLine($"Número da conta: {numero}\nNome: {nome}\nDocumento: {doc}\nSaldo: {saldo}\nTipo: {tipo}");
                break;
            }
            Console.WriteLine("aguarde um instante.");
            Thread.Sleep(500);
            Console.WriteLine("Tudo pronto.\n----------------------");
        }
        public static void AbrirConta(List<ContaJuridica> dados)
        {
            StreamWriter sw = File.AppendText(arquivo);
            foreach (ContaJuridica obj in dados)
            {
                int numero = obj.NumeroConta;
                string nome = obj.Nome;
                string doc = obj.Cnpj;
                double saldo = obj.Saldo;
                int tipo = obj.Tipo;
                sw.WriteLine($"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}");
                sw.Close();
                Console.WriteLine($"Número da conta: {numero}\nNome: {nome}\nDocumento: {doc}\nSaldo: {saldo}\nTipo: {tipo}");
                break;
            }
            Console.WriteLine("aguarde um instante.");
            Thread.Sleep(500);
            Console.WriteLine("Tudo pronto.\n----------------------");
        }
        public static void ExcluirConta(int numeroConta)
        {
            bool ero = false;
            StreamReader sr = new StreamReader(arquivo);   
            List<string> dado = new List<string>();
            while (!(sr.EndOfStream))
            {
                string[] temp = sr.ReadLine().Split(",");
                if (temp != null)
                {
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
                        string dados = $"{numero},{nome},{doc},{saldo.ToString("f2", CultureInfo.InvariantCulture)},{tipo}";
                        dado.Add(dados);
                    }
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

        public static List<string> Contas()
        {
            StreamReader sr = new StreamReader(arquivo);
            List<string> contas = new List<string>();
            while (!(sr.EndOfStream))
            {
                string[] temp = sr.ReadLine().Split(",");
                if (temp != null)
                {
                    int numero = int.Parse(temp[0]);
                    string nome = temp[1];
                    string doc = temp[2];
                    double saldo = double.Parse(temp[3].Replace(".", ","));
                    int tipo = int.Parse(temp[4]);
                    string dados = $"{numero},{nome},{doc},{saldo},{tipo}";
                    contas.Add(dados);
                }
            }
            return contas;
        }
        public static void Print<T>(string menssagem, IEnumerable<T> collection)
        {
            Console.WriteLine(menssagem);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();

        }

        
    }


}
