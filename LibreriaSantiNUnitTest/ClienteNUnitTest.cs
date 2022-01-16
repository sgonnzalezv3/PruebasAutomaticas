using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSanti
{
    [TestFixture]
    public class ClienteNUnitTest
    {
        private Cliente cliente;

        [SetUp]
        public void Setup()
        {
            cliente = new Cliente();
        }

        [Test]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            /* Arrange */

            /* Act */

            cliente.CrearNombreCompleto("Santiago", "Gonzalez");

            Assert.Multiple(() =>
            {
                /* Assert */
                Assert.That(cliente.ClienteNombre, Is.EqualTo("Santiago Gonzalez"));

                Assert.AreEqual(cliente.ClienteNombre, "Santiago Gonzalez");

                /* Evaluar si cierto texto existe sobre la cadena total */
                Assert.That(cliente.ClienteNombre, Does.Contain("Gonzalez"));

                /* Ignorar Mayusculas Minusculas */
                Assert.That(cliente.ClienteNombre, Does.Contain("Gonzalez").IgnoreCase);

                /* Con que texto empieza la cadena */
                Assert.That(cliente.ClienteNombre, Does.StartWith("Santiago"));

                /* Termina con un determinado valor */
                Assert.That(cliente.ClienteNombre, Does.EndWith("Gonzalez"));
            });

        }

        /* Evalua propiedad ClientNombre */
        [Test]
        public void ClientNombre_NoValues_ReturnsNull()
        {
            /* Arrange */
            Assert.IsNull(cliente.ClienteNombre);
        }


        [Test]
        public void DescuentoEvaluacion_DefaultCliente_ReturnsDescuentoIntervalo()
        {
            int descuento = cliente.Descuento;

            /* Intervalo numerico */
            Assert.That(descuento, Is.InRange(5, 24));
        }

        [Test]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            cliente.CrearNombreCompleto("Santiago", "");
            Assert.IsNotNull(cliente.ClienteNombre);
            Assert.IsFalse(string.IsNullOrEmpty(cliente.ClienteNombre));

        }

        /* Captura de excepcion */
        [Test]
        public void ClienteNombre_InputNombreEnBlanco_ThrowExcepcion()
        {
            var excepcionDetalle = Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Gonzalez"));
            Assert.AreEqual("El nombre está en blanco", excepcionDetalle.Message);
            Assert.That(() => cliente.CrearNombreCompleto("", "Gonzalez"), Throws.ArgumentException.With.Message.EqualTo("El nombre está en blanco"));

            /* comparar el objeto excepcion (no el mensaje) */
            Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Gonzalez"));
            Assert.That(() => cliente.CrearNombreCompleto("", "Gonzalez"), Throws.ArgumentException);

        }


        [Test]
        public void GetClienteDetalle_CrearClienteConMenosDe500TotalOrder_ReturnsClienteBasico()
        {
            cliente.OrdenTotal = 150;
            var resultado = cliente.GetClienteDetalle();
            Assert.That(resultado, Is.TypeOf<ClienteBasico>());
        }

        [Test]
        public void GetClienteDetalle_CrearClienteConMasDe500TotalOrder_ReturnsClientePremium()
        {
            cliente.OrdenTotal = 700;
            var resultado = cliente.GetClienteDetalle();
            Assert.That(resultado, Is.TypeOf<ClientePremium>());
        }


    }
}
