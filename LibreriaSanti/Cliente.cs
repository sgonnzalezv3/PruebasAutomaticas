using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSanti
{
    public class Cliente : ICliente
    {
        public string ClienteNombre { get; set; }
        public int Descuento { get; set; }
        public bool IsPremium { get; set; }
        public int OrdenTotal { get; set; }

        public Cliente()
        {
            IsPremium = false;
            Descuento = 10;
        }
        public string CrearNombreCompleto(string nombre, string apellido)
        {

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre está en blanco");

            Descuento = 30;
            ClienteNombre = $"{nombre} {apellido}";
            return ClienteNombre;
        }
        public TipoCliente GetClienteDetalle()
        {
            if (OrdenTotal < 500)
                return new ClienteBasico();
            return new ClientePremium();
        }
    }

    public class TipoCliente { }
    public class ClienteBasico : TipoCliente { }
    public class ClientePremium : TipoCliente { }
}
