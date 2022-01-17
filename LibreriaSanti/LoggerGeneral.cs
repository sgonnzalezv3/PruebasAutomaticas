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
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        public bool LogBalanceDespuesRetiro(int BalanceDespuesRetiro)
        {
            if (BalanceDespuesRetiro >= 0)
            {
                Console.WriteLine("Exito");
                return true;

            }
            Console.WriteLine("Error");

            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool MessageConObjetoReferenciaReturnBoolean(ref Cliente cliente)
        {
            return true;
        }

        public bool MessageConOutParametroReturnBoolean(string str, out string outputStr)
        {
            outputStr = "Hola " + str;
            return true;
        }

        public string MessageConReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    /* Objeto Falso */

    public class LoggerFake : ILoggerGeneral
    {
        public int PrioridadLogger { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TipoLogger { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool LogBalanceDespuesRetiro(int BalanceDespuesRetiro)
        {
            throw new NotImplementedException();
        }

        public bool LogDatabase(string message)
        {
            throw new NotImplementedException();
        }

        public void Message(string message)
        {
        }

        public bool MessageConObjetoReferenciaReturnBoolean(ref Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool MessageConOutParametroReturnBoolean(string str, out string outputStr)
        {
            throw new NotImplementedException();
        }

        public string MessageConReturnString(string message)
        {
            throw new NotImplementedException();
        }
    }
}
