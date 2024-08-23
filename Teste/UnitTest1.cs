using System;
using TestesTDD;
using Xunit;

namespace Teste
{
    public class UnitTest1
    {
        public Calculadora ConstruirClasse()
        {
            string data = "02/02/2020";
            Calculadora calc = new Calculadora(data);

            return calc;
        }
        
        [Theory]
        [InlineData (1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TesteSomar(int val1, int val2, int resultado)
        {
            Calculadora calc = ConstruirClasse();
            int resultadoCalculadora = calc.Somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(5, 2, 3)]
        public void TesteSubtrair(int val1, int val2, int resultado)
        { 
            Calculadora calc = ConstruirClasse();
            int resultadoCalculadora = calc.Subtrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TesteMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora calc = ConstruirClasse();
            int resultadoCalculadora = calc.Multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(20, 2, 10)]
        [InlineData(40, 5, 8)]
        public void TesteDividir(int val1, int val2, int resultado)
        {
            Calculadora calc = ConstruirClasse();
            int resultadoCalculadora = calc.Dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = ConstruirClasse();
            Assert.Throws<DivideByZeroException>(
                () => calc.Dividir(3, 0)
                );
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = ConstruirClasse();

            calc.Somar(1, 2);
            calc.Somar(2, 2);
            calc.Somar(3, 2);
            calc.Somar(4, 2);

            var lista = calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}
