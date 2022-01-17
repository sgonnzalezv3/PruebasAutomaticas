using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibreriaSanti
{
    public class CuentaBancariaXUnitTest
    {
        private CuentaBancaria cuenta;

        public CuentaBancariaXUnitTest()
        {

        }

        /*
        [Test]
        public void Deposito_InputMonto100LoggerFake_ReturnsTrue()
        {
            var cuentaBancaria = new CuentaBancaria(new LoggerFake());

            var resultado = cuentaBancaria.Deposito(100);
            
            Assert.True(resultado);
            Assert.Equal(100,cuentaBancaria.GetBalance);
        }
        */
        [Fact]
        public void Deposito_InputMonto100Mocking_ReturnsTrue()
        {
            /* Mock que representa cualquier implementacion, ya sea clase o interface, no tiene logica */
            var mocking = new Mock<ILoggerGeneral>();

            var cuentaBancaria = new CuentaBancaria(mocking.Object);

            var resultado = cuentaBancaria.Deposito(100);

            Assert.True(resultado);
            Assert.Equal(100,cuentaBancaria.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]

        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retiro)
        {
            /* Logger Mocking */
            var loggerMock = new Mock<ILoggerGeneral>();

            /* - - - - - - - Simulando - - - - - -  */

            /* Indicando el metodo que quiero que realice, pasandole cualquier string y que retorne true */
            loggerMock.Setup(x => x.LogDatabase(It.IsAny<string>())).Returns(true);
            /* Indicando el metodo que quiero que realice, pasandole cualquier int y que retorne true */
            loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);
            /* Mock Listo para utilizarse */


            CuentaBancaria cuentaBancaria = new(loggerMock.Object);
            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.True(resultado);
        }


        [Theory]
        [InlineData(200, 100)]
        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retiro)
        {
            /* Logger Mocking */
            var loggerMock = new Mock<ILoggerGeneral>();

            /* - - - - - - - Simulando - - - - - -  */

            /* Indicando el metodo que quiero que realice, pasandole cualquier int y que retorne true */
            // 1 opcion : loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);

            // Vlr Minimo posible hasta -1
            loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            /* Mock Listo para utilizarse */


            CuentaBancaria cuentaBancaria = new(loggerMock.Object);
            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.False(resultado);
        }


        /* ´Prueba sobre un objeto clase tipo Moc Dependencia (parametro de entrada) */
        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            string textoPrueba = "hola santi";
            loggerGeneralMock.Setup(x => x.MessageConReturnString(It.IsAny<string>())).Returns<string>((string str) => str.ToLower());

            var resultado = loggerGeneralMock.Object.MessageConReturnString("HOla saNti");

            Assert.Equal(textoPrueba, resultado);
        }


        /* ´Prueba sobre un objeto clase tipo Moc Dependencia (parametro de salida out) */
        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingOutPut_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola";

            loggerGeneralMock.Setup(x => x.MessageConOutParametroReturnBoolean(It.IsAny<string>(), out textoPrueba)).Returns(true);

            string parametroOut = "";
            var resultado = loggerGeneralMock.Object.MessageConOutParametroReturnBoolean("Santi", out parametroOut);

            Assert.True(resultado);
        }

        //Ref quiere decir que hara referencia a un objeto que ya fue creado antes
        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingObjetoRef_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            Cliente cliente = new();
            Cliente clienteNoUsado = new();


            loggerGeneralMock.Setup(x => x.MessageConObjetoReferenciaReturnBoolean(ref cliente)).Returns(true);

            string parametroOut = "";
            var resultado = loggerGeneralMock.Object.MessageConOutParametroReturnBoolean("Santi", out parametroOut);

            /* tiene que devolver true porque le esta pasando un objeto que ya ha sido seteado en el setup del metodo */
            Assert.True(loggerGeneralMock.Object.MessageConObjetoReferenciaReturnBoolean(ref cliente));

            /* Retorna false porque no esta seteando el objeto en el setup del metodo principal  */
            Assert.False(loggerGeneralMock.Object.MessageConObjetoReferenciaReturnBoolean(ref clienteNoUsado));
        }

        /* Trabajando con las propiedades que contiene a un objeto de tipo MOC*/
        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnsTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            /* Si no se ejecuta este metodo, al querer hacer la reasignacion al valor que está en 167(100) 
             * No lo tomará y seguirá 
             */
            loggerGeneralMock.SetupAllProperties();

            loggerGeneralMock.Setup(x => x.TipoLogger).Returns("warning");
            loggerGeneralMock.Setup(x => x.PrioridadLogger).Returns(10);


            loggerGeneralMock.Object.PrioridadLogger = 100;

            Assert.Equal("warning",loggerGeneralMock.Object.TipoLogger);
            Assert.Equal(100,loggerGeneralMock.Object.PrioridadLogger);

            //CALLBACKS
            // evento que se dispara inmediatamente culmina la ejecucion del emtodo principal que se está evaluando.
            string textoTemporal = "Santi ";
            loggerGeneralMock.Setup(x => x.LogDatabase(It.IsAny<string>())).Returns(true).Callback((string param) =>
                textoTemporal += param
             );
            loggerGeneralMock.Object.LogDatabase("Gonzalez");

            Assert.Equal("Santi Gonzalez",textoTemporal);
        }


        [Fact]
        public void CuentaBancariaLoggerGeneral_VerifyEjemplo()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new(loggerGeneralMock.Object);
            cuentaBancaria.Deposito(100);
            Assert.Equal(100,cuentaBancaria.GetBalance());

            /* Verificar si .Message se llama 3 veces al metodo*/
            loggerGeneralMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(3));
            /* Verificar si .Message con el texto especificado se ejecuto almenos una vez */
            loggerGeneralMock.Verify(x => x.Message("Santi Gonzalez V"), Times.AtLeastOnce);
            /* Verificar si .Message se llama 1 vez a la propiedad */
            loggerGeneralMock.VerifySet(x => x.PrioridadLogger = 100, Times.Once);
            /* Cuantas veces le aplicas get a una propiedad en el metodo(1) */
            loggerGeneralMock.VerifyGet(x => x.PrioridadLogger, Times.Once);

        }



    }

}
