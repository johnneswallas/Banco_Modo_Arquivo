
namespace Servicos
{
    class Taxa : ITaxa
    {
        public double Saque(double valor)
        {
            double juros = valor * 0.02;
            return juros;
        }
    }
}
