using System;

namespace CalcTest.Domain.Model
{
    public class JurosCompostos
    {
        private const double _juros = 0.01;
        public JurosCompostos(decimal valorInicial, int meses)
        {
            ValorInicial = valorInicial;
            Meses = meses;
        }

        public decimal ValorInicial { get; private set; }
        public decimal ValorFinal => CalcularValorFinal();
        public int Meses { get; private set; }

        public bool Validar()
           => ValorInicial > 0 && Meses >= 0;

        private decimal CalcularValorFinal()
        {
            
            if (Validar())
            {
                var valorFinal = ValorInicial * (decimal)Math.Pow((1 + _juros), Meses);
                return Math.Truncate(valorFinal * 100) / 100;
            }
            throw new InvalidOperationException();
        }


    }
}
