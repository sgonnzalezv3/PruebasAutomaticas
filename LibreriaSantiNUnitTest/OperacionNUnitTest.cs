using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSanti
{
    [TestFixture]
    public class OperacionNUnitTest
    {
        [Test]
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
            Assert.AreEqual(119, resultado);

        }

        [Test]
        [TestCase(3,ExpectedResult = false)]
        [TestCase(5,ExpectedResult = false)]
        [TestCase(7,ExpectedResult = false)]
        public bool IsValorPar_InputNumeroImPar_ReturnFalse(int numeroImpar)
        {
            Operacion op = new();

            return op.IsValorPar(numeroImpar);

        }

        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(8)]
        public void IsValorPar_InputNumeroPar_ReturnTrue(int numeroPar)
        {
            Operacion op = new();

            bool isPar = op.IsValorPar(numeroPar);

            /* Si es true, prueba superada */
            Assert.IsTrue(isPar);
            Assert.That(isPar,Is.EqualTo(true));
        }

        [Test]
        [TestCase(2.2,1.2)] //3.4
        [TestCase(2.23,1.24)] // 3.47

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

            // Primer parametro, lo que esperas obtener
            // Segundo, resultado obtenido de la operacion anterior
                                    // Intervalo [3.3 - 3.5]
            Assert.AreEqual(3.4, resultado, 0.1);

        }

        [Test]


        public void GetListaNumerosImpares_InputMinimoMaximoIntervalos_ReturnListaImpares()
        {
            // 1. Arrange 
            // Inicializar valores a probar (variables o componentes que ejecutaran el test)
            Operacion op = new();

            List<int> numerosImparesEsperados = new() { 5, 7, 9 };

            // 2. Act
            // Representa ejecucion de la operacion

            var resultados = op.GetListaNumerosImpares(5,10);

            // 3.Assert
            // Comparacion de resultados

            Assert.That(resultados, Is.EquivalentTo(numerosImparesEsperados));
            Assert.AreEqual(numerosImparesEsperados, resultados);
            
            /* si un elemenot se encuentra en la coleccion */
            Assert.That(resultados, Does.Contain(5));
            Assert.Contains(5,resultados);
            
            /* Si no esta vacia la coleccion */
            Assert.That(resultados, Is.Not.Empty);

            /* Contar la lista de elementos */
            Assert.That(resultados.Count , Is.EqualTo(3));

            /* Buscando un elemento que no esta en la lista */
            Assert.That(resultados, Has.No.Member(100));

            /* Coleccion de elementos ordenados */
            Assert.That(resultados, Is.Ordered.Ascending);
            
            /* Valores duplicados */
            Assert.That(resultados, Is.Unique);



        }


    }
}
