using System;
using Entidades;
using Servicos;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = 0;
            int j = 0;

            int N = 1;

            Console.WriteLine("Bem vindo ao banco JW");
            while (N < 2)
            {
                Console.WriteLine("1 - Movimentação\n2 - Manutenção De Conta\n3 - Sair ");
                int opc = int.Parse(Console.ReadLine());

                if (opc == 1)
                {
                    Console.WriteLine("1 - Depósito\n2 - Saque");
                    int escolha = int.Parse(Console.ReadLine());
                    if (escolha == 1)
                    {
                        Console.WriteLine("Informe a conta: ");
                        int conta = int.Parse(Console.ReadLine());
                        Console.WriteLine("Valor: ");
                        int valor = int.Parse(Console.ReadLine());

                        break;
                    }
                    else if (escolha == 2)
                    {
                        Console.WriteLine("Informe a conta: ");
                        int conta = int.Parse(Console.ReadLine());
                        Console.WriteLine("Valor: ");
                        int valor = int.Parse(Console.ReadLine());

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção invalida tente novamente.");
                        Console.WriteLine();
                    }
                }
                else if (opc == 2)
                {
                    Console.WriteLine("1 - Abrir Conta\n2 - Excluir Conta");
                    int escolha = int.Parse(Console.ReadLine());
                    if (escolha == 1)
                    {

                        Random random = new Random();
                        int numeroConta = random.Next(111111, 999999);

                        Console.WriteLine("1 - Conta Corrente \n2 - Conta Juridica");
                        int tipo = int.Parse(Console.ReadLine());
                        if (tipo == 1)
                        {
                            Console.Write("Nome completo: ");
                            string nome = Console.ReadLine().Trim();
                            Console.Write("CPF: ");
                            long cpf = long.Parse(Console.ReadLine());
                            double saldo = 0;
                            Console.WriteLine("----------------------");

                            ContaCorrente[] cc = new ContaCorrente[5];
                            cc[0] = new ContaCorrente(nome, numeroConta, saldo, cpf);
                            c++;


                        }
                        else if (tipo == 2)
                        {
                            Console.Write("Razão Social: ");
                            string nome = Console.ReadLine().Trim();
                            Console.Write("CNPJ: ");
                            long cnpj = long.Parse(Console.ReadLine());
                            double saldo = 0;
                            Console.WriteLine("----------------------");

                            ContaJuridica[] cj = new ContaJuridica[5];
                            cj[j] = new ContaJuridica(nome, numeroConta, saldo, cnpj);
                            j++;


                        }
                    }
                    else if (escolha == 2)
                    {

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção invalida tente novamente.");
                        Console.WriteLine();
                    }

                }
                else if (opc == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opção invalida tente novamente.");
                    Console.WriteLine();
                }
            }

            Log.Saque(20);

        }
    }
}
