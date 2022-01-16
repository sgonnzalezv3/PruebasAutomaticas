using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSanti
{
    public interface ICliente
    {
        string ClienteNombre { get; set; }
        int Descuento { get; set; }
        bool IsPremium { get; set; }
        int OrdenTotal { get; set; }
        string CrearNombreCompleto(string nombre, string apellido);
        TipoCliente GetClienteDetalle();
    }
}
