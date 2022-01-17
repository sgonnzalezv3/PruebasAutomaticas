using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibreriaSanti
{
    public class OperacionXUnitTest
    {
        [Fact]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            // 1. Arrange 
            // Inicializar valores a probar (variables o componentes que ejecutaran el test)
            Operacion op = new();

            int numero1Test = 50;
            int numero2Test = 69;

            // 2. Act
            // Representa ejecucion de la operacion

            var resultado = op.SumarNumeros(numero1Test, numero2Test);

            // 3.Assert
            // Comparacion de resultados

            // Primer parametro, lo que esperas obtener
            // Segundo, resultado obtenido de la operacion anterior
            Assert.Equal(119, resultado);

        }

        [Theory]
        [InlineData(3,false)]
        [InlineData(5,false)]
        [InlineData(7,false)]
        public void IsValorPar_InputNumeroImPar_ReturnFalse(int numeroImpar, bool expectedResult)
        {
            Operacion op = new();
            var resultado = op.IsValorPar(numeroImpar);

            Assert.Equal(expectedResult, resultado);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        public void IsValorPar_InputNumeroPar_ReturnTrue(int numeroPar)
        {
            Operacion op = new();

            bool isPar = op.IsValorPar(numeroPar);

            /* Si es true, prueba superada */
            Assert.True(isPar);
        }

        [Theory]
        [InlineData(2.2, 1.2)] //3.4
        [InlineData(2.23, 1.24)] // 3.47

        public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double decimal1Test, double decimal2Test)
        {
            // 1. Arrange 
            // Inicializar valores a probar (variables o componentes que ejecutaran el test)
            Operacion op = new();

            // 2. Act
            // Representa ejecucion de la operacion

            var resultado = op.SumarDecimal(decimal1Test, decimal2Test);

            // 3.Assert
            // Comparacion de resultados

            /* 0:redondear la diferencia que hay entre dos valores y dara un resultado positivo */
            Assert.Equal(3.4, resultado, 0);

        }

        [Fact]


        public void GetListaNumerosImpares_InputMinimoMaximoIntervalos_ReturnListaImpares()
        {
            // 1. Arrange 
            // Inicializar valores a probar (variables o componentes que ejecutaran el test)
            Operacion op = new();

            List<int> numerosImparesEsperados = new() { 5, 7, 9 };

            // 2. Act
            // Representa ejecucion de la operacion

            var resultados = op.GetListaNumerosImpares(5, 10);

            // 3.Assert
            // Comparacion de resultados

            /* Valores esperados y resultados de la operacion | Comparacion */
            Assert.Equal(numerosImparesEsperados,resultados);

            /* si un elemenot se encuentra en la coleccion */
            Assert.Contains(5, resultados);
            Assert.Contains(5, resultados);

            /* Si no esta vacia la coleccion */
            Assert.NotEmpty(resultados);

            /* Contar la lista de elementos */
            Assert.Equal(3,resultados.Count);

            /* Buscando un elemento que no esta en la lista */
            Assert.DoesNotContain(100, resultados);

            /* Coleccion de elementos ordenados */
            Assert.Equal(resultados.OrderBy(x=>x), resultados);



        }


    }
}
