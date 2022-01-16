using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSanti
{
    /* Logger que va imprimiendo en la consola las transacciones que van sucediendo */
    public class LoggerGeneral : ILoggerGeneral
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }

    /* Objeto Falso */

    public class LoggerFake : ILoggerGeneral
    {
        public void Message(string message)
        {
        }
    }
}
