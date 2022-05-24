using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectopia
{
    class Message
    {
        private String sOperador;
        public String _sOperador { get { return sOperador; } set { sOperador = value; } }
        private String sValue1;
        public String _sValue1 { get { return sValue1; }set { sValue1 = value; } }
        private String sValue2;
        public String _sValue2 { get { return sValue2; } set { sValue2 = value; } }

        public Message()
        {
        }
        public Message(String operador)
        {
            sOperador = operador;
        }
        public Message(String operador, String value1)
        {
            sOperador = operador;
            sValue1 = value1;
        }
        public Message(String operador, String value1, String value2)
        {
            sOperador = operador;
            sValue1 = value1;
            sValue2 = value2;
        }
    }
}
