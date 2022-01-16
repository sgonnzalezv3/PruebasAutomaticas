using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSanti
{
    [TestFixture]
    public class CuentaBancariaNUnitTest
    {
        private CuentaBancaria cuenta;
    
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Deposito_InputMonto100LoggerFake_ReturnsTrue()
        {
            var cuentaBancaria = new CuentaBancaria(new LoggerFake());

            var resultado = cuentaBancaria.Deposito(100);
            
            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance,Is.EqualTo(100));
        }

        [Test]
        public void Deposito_InputMonto100Mocking_ReturnsTrue()
        {
            /* Mock que representa cualquier implementacion, ya sea clase o interface, no tiene logica */
            var mocking = new Mock<ILoggerGeneral>();

            var cuentaBancaria = new CuentaBancaria(mocking.Object);

            var resultado = cuentaBancaria.Deposito(100);

            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));
        }
    }

}
