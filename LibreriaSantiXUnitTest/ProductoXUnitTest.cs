//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LibreriaSanti
//{
//    [TestFixture]
//    public class ProductoXUnitTest
//    {
//        [Test]
//        public void GetPrecio_PremiumCliente_ReturnsPrecio80()
//        {
//            Producto producto = new()
//            {
//                Precio = 50
//            };
//            var resultado = producto.GetPrecio(new Cliente { IsPremium = true});

//            //80% de 50 es = 40
//            Assert.That(resultado, Is.EqualTo(40));
//        }

//        [Test]
//        public void GetPrecio_PremiumClienteMoq_ReturnsPrecio80()
//        {
//            Producto producto = new()
//            {
//                Precio = 50
//            };
//            var moqCliente = new Mock<ICliente>();
//            moqCliente.Setup(x=> x.IsPremium).Returns(true);
//            var resultado = producto.GetPrecio(moqCliente.Object);

//            //80% de 50 es = 40
//            Assert.That(resultado, Is.EqualTo(40));
//        }
//    }
//}
