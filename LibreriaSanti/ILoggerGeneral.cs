using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSanti
{
    public interface ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int BalanceDespuesRetiro);

        string MessageConReturnString(string message);
        bool MessageConOutParametroReturnBoolean(string str , out string outputStr);
        bool MessageConObjetoReferenciaReturnBoolean(ref Cliente cliente);
    }

}
