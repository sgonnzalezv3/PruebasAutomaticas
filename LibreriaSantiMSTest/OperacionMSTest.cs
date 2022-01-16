using LibreriaSanti;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSantiMSTest
{
    [TestClass]
    public class OperacionMSTest
    {
        [TestMethod]
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
    }
}
