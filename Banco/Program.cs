using System;
using Entidades;
using Servicos;
using System.Threading;

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
                        Console.Write("Informe a conta: ");
                        int conta = int.Parse(Console.ReadLine());
                        Console.Write("Valor: ");
                        double valor = double.Parse(Console.ReadLine());
                        Log.Deposito(conta, valor);
                        break;
                    }
                    else if (escolha == 2)
                    {
                        Console.Write("Informe a conta: ");
                        int conta = int.Parse(Console.ReadLine());
                        Console.Write("Valor: ");
                        double valor = double.Parse(Console.ReadLine());
                        Log.Saque(conta, valor);
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
                            double saldo = 0;
                            Console.Write("Nome completo: ");
                            string nome = Console.ReadLine().Trim();
                            Console.Write("CPF: ");
                            string cpf = Console.ReadLine();
                            Console.Write("Haverar deposito inicial?");
                            char dep = char.Parse(Console.ReadLine().ToUpper());
                            if (dep == 'S')
                            {
                                Console.Write("Qual serar o valor: ");
                                saldo = double.Parse(Console.ReadLine());
                            }
                            
                            ContaCorrente[] cc = new ContaCorrente[5];
                            cc[c] = new ContaCorrente(numeroConta, nome, cpf, saldo);
                            Log.AbriConta(cc);
                            
                            c++;


                        }
                        else if (tipo == 2)
                        {
                            Console.Write("Razão Social: ");
                            string nome = Console.ReadLine().Trim();
                            Console.Write("CNPJ: ");
                            string cnpj = Console.ReadLine();
                            double saldo = 0;
                            Console.WriteLine("----------------------");

                            ContaJuridica[] cj = new ContaJuridica[5];
                            cj[j] = new ContaJuridica(numeroConta, nome, cnpj, saldo);
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

            
            
        }
    }
}
