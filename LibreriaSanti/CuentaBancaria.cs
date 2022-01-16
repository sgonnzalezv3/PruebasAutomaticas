using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaSanti
{
    public class CuentaBancaria
    {
        public int Balance { get; set; }
        private readonly ILoggerGeneral _loggerGeneral;
        public CuentaBancaria(ILoggerGeneral loggerGeneral)
        {
            _loggerGeneral = loggerGeneral;
            Balance = 0;
        }

        public bool Deposito(int monto){

            _loggerGeneral.Message($"Está depositando con la cantidad de: {monto}");
            Balance += monto;
            return true;
        }

        public bool Retiro(int monto)
        {
            if(monto <= Balance)
            {
                Balance -= monto;
                return true;
            }
            return false;
        }
        public int GetBalance()
        {
            return Balance;
        }
    }
}
