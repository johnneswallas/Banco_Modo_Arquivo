using System;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 1;
            Console.WriteLine("Bem vindo ao banco JW");
            while(N < 2)
            {
                Console.WriteLine("1 - Movimentação\n2 - Manutenção De Conta ");
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
                    }
                }
                else if (opc == 2)
                {
                    Console.WriteLine("1 - Abrir Conta\n2 - Excluir Conta");
                    int escolha = int.Parse(Console.ReadLine());
                    if (escolha == 1)
                    {

                        break;
                    }
                    else if (escolha == 2)
                    {

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção invalida tente novamente.");
                    }

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
