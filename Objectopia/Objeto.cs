using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectopia
{
    class Objeto
    {
        public int iTipoValue;
        public String sValue;
        public String sName;
        public List<Message> listM;
        public int iPos;
        public Cubo cubo = null;
        bool dir;

        public Objeto()
        {
            iTipoValue = -1;
            iPos = 0;
            sValue = "";
            sName = "";
            dir = true;
            listM = new List<Message>();
        }
        private String buscaValorN(String name,List<Objeto> listO)
        {
            foreach (Objeto o in listO)
            {
                if (o.sName.CompareTo(name) == 0)
                    return o.sValue;
            }
            return "";
        }
        public void Modifica_sValor(Message mensaje,List<Objeto> listO)
        {
            String valor1 = "";
            String valor2 = "";
            switch (mensaje._sOperador[0])
            {  
                case '+':
                    valor1 = buscaValorN(this.sValue, listO);
                    valor2 = buscaValorN(mensaje._sValue1, listO);
                    if (valor1 == "")
                    {
                        if (valor2 == "")
                        {
                            int Resultado = int.Parse(this.sValue) + int.Parse(mensaje._sValue1);
                            this.sValue = Resultado.ToString();
                        }
                        else
                        {
                            int Resultado = int.Parse(this.sValue) + int.Parse(valor2);
                            this.sValue = Resultado.ToString();
                        }
                    }
                    else
                    {
                        if (valor2 == "")
                        {
                            int Resultado = int.Parse(valor1) + int.Parse(mensaje._sValue1);
                            this.sValue = Resultado.ToString();
                        }else
                        {
                            int Resultado = int.Parse(valor1) + int.Parse(valor2);
                            this.sValue = Resultado.ToString();
                        }
                    }
                    break;
                case '-':
                    valor1 = buscaValorN(this.sValue, listO);
                    valor2 = buscaValorN(mensaje._sValue1, listO);
                    if (valor1 == "")
                    {
                        if (valor2 == "")
                        {
                            int Resultado = int.Parse(this.sValue) - int.Parse(mensaje._sValue1);
                            this.sValue = Resultado.ToString();
                        }
                        else
                        {
                            int Resultado = int.Parse(this.sValue) - int.Parse(valor2);
                            this.sValue = Resultado.ToString();
                        }
                    }
                    else
                    {
                        if (valor2 == "")
                        {
                            int Resultado = int.Parse(valor1) - int.Parse(mensaje._sValue1);
                            this.sValue = Resultado.ToString();
                        }
                        else
                        {
                            int Resultado = int.Parse(valor1) - int.Parse(valor2);
                            this.sValue = Resultado.ToString();
                        }
                    }
                    break;
                case '*':
                    valor1 = buscaValorN(this.sValue, listO);
                    valor2 = buscaValorN(mensaje._sValue1, listO);
                    if (valor1 == "")
                    {
                        if (valor2 == "")
                        {
                            int Resultado = int.Parse(this.sValue) * int.Parse(mensaje._sValue1);
                            this.sValue = Resultado.ToString();
                        }
                        else
                        {
                            int Resultado = int.Parse(this.sValue) * int.Parse(valor2);
                            this.sValue = Resultado.ToString();
                        }
                    }
                    else
                    {
                        if (valor2 == "")
                        {
                            int Resultado = int.Parse(valor1) * int.Parse(mensaje._sValue1);
                            this.sValue = Resultado.ToString();
                        }
                        else
                        {
                            int Resultado = int.Parse(valor1) * int.Parse(valor2);
                            this.sValue = Resultado.ToString();
                        }
                    }
                    break;
                case 'F':
                    valor1 = buscaValorN(this.sValue, listO);
                    if (valor1 == "")
                    {
                        int Resultado = int.Parse(this.sValue);
                        long R = factorial(Resultado);
                        this.sValue = R.ToString();
                    }
                    else
                    {
                        int Resultado = int.Parse(valor1);
                        this.sValue = Resultado.ToString();
                    }
                    break;
                case '>':
                    valor1 = buscaValorN(this.sValue, listO);
                    valor2 = buscaValorN(mensaje._sValue1, listO);
                    if (valor1 == "")
                    {
                        if (valor2 == "")
                        {
                            //Son los valores originales
                            if (int.Parse(this.sValue) > int.Parse(mensaje._sValue1))
                                this.sValue = "true";
                            else
                                this.sValue = "false";
                        }
                        else
                        {
                            //el dato enviado unto con el mensaje es una variable
                            if(int.Parse(this.sValue) > int.Parse(valor2))
                            this.sValue = "true";
                            else
                                this.sValue = "false";
                        }
                    }
                    else
                    {
                        if (valor2 == "")
                        {
                            //El dato enviado con el mensaje es el original
                            if (int.Parse(valor1) > int.Parse(mensaje._sValue1))
                                this.sValue = "true";
                            else
                                this.sValue = "false";
                        }
                        else
                        {
                            //los dos son variables
                            if (int.Parse(valor1) > int.Parse(valor2))
                                this.sValue = "true";
                            else
                                this.sValue = "false";
                        }
                    }
                    break;
                case '<':
                    valor1 = buscaValorN(this.sValue, listO);
                    valor2 = buscaValorN(mensaje._sValue1, listO);
                    if (valor1 == "")
                    {
                        if (valor2 == "")
                        {
                            //Son los valores originales
                            if (int.Parse(this.sValue) < int.Parse(mensaje._sValue1))
                                this.sValue = "true";
                            else
                                this.sValue = "false";
                        }
                        else
                        {
                            //el dato enviado unto con el mensaje es una variable
                            if (int.Parse(this.sValue) < int.Parse(valor2))
                                this.sValue = "true";
                            else
                                this.sValue = "false";
                        }
                    }
                    else
                    {
                        if (valor2 == "")
                        {
                            //El dato enviado con el mensaje es el original
                            if (int.Parse(valor1) < int.Parse(mensaje._sValue1))
                                this.sValue = "true";
                            else
                                this.sValue = "false";
                        }
                        else
                        {
                            //los dos son variables
                            if (int.Parse(valor1) < int.Parse(valor2))
                                this.sValue = "true";
                            else
                                this.sValue = "false";
                        }
                    }
                    break;
                case 'B':
                    //a:=1Between:2 and:3.
                    valor1 = buscaValorN(this.sValue, listO);
                    valor2 = buscaValorN(mensaje._sValue1, listO);
                    String valor3 = buscaValorN(mensaje._sValue2, listO); ;
                    if (valor1 == "")
                    {
                        valor1 = this.sValue;
                    }
                    if (valor2 == "")
                    {
                        valor2 = mensaje._sValue1;
                    }
                    if (valor3 == "")
                    {
                        valor3 = mensaje._sValue2;
                    }
                    if (int.Parse(valor2) < int.Parse(valor1) && int.Parse(valor1) < int.Parse(valor3))
                        this.sValue = "true";
                    else
                        this.sValue = "false";
                    break;
            }
        }
        public long factorial(long num)
        {
            if (num == 0)
                return 1;
            else return num * factorial(num - 1);
        }
        public void CambiaPosObjeto(Cubo[,] cubo)
        {
            if (dir == true)
            {
                if (iPos != 11)
                {
                    iPos = iPos - 20;
                    
                }else
                    dir = false;
            }
            else
            {
                if (iPos != 91)
                {
                    iPos = iPos + 20;
                    
                }else
                    dir = true;
            }

        }

    }
}
