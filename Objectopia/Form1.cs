using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Objectopia
{
    public partial class Form1 : Form
    {
        Point p1 = new Point();
        Point p2 = new Point();
        Point p3 = new Point();
        Point p4 = new Point();
        Point p5 = new Point();
        Pen pluma1 = new Pen(Color.GreenYellow,5);
        List<String> listS = new List<string>();
        List<Objeto> listO = new List<Objeto>();
        Cubo cProgramador = new Cubo(330,300);
        Cubo[,] Mundo = new Cubo[10,10];
        bool dibujaRec = false;
        private Graphics g;
        private Graphics pagina;
        private Bitmap bmp;
        private SolidBrush Brocha = new SolidBrush(Color.Azure);

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(1600, 1024);
            pagina = Graphics.FromImage(bmp);
            g = CreateGraphics();
            creaMundo();
            AdjustableArrowCap acc = new AdjustableArrowCap(1, 1, true);
            pluma1.CustomEndCap = acc;
        }
        private void creaMundo()
        {
            int x, y;
            x = 140;
            y = 210;
            int id = 1;
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if(Mundo[j, i]!=null)
                    {
                        if (Mundo[j, i].bOcupado == true)
                            ClearCube(Mundo[j,i].indice);
                    }
                }
            }
            for (int j=0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    Mundo[j, i] = new Cubo();
                    Mundo[j, i].indice = id;
                    Mundo[j, i].x = x + (30 * i);
                    Mundo[j, i].y = y;
                    Mundo[j,i].puntoMedio = new Point(Mundo[j, i].x + 20, Mundo[j, i].y - 5);
                    id += 1;
                }
                x = x - 30 / 2;
                y = y + 30 / 3;

            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            pagina.SmoothingMode = SmoothingMode.AntiAlias;
            pagina.Clear(BackColor);
            dibujaMundo(pagina);
            cProgramador.dibujaProgramador(pagina);
            DrawLine(pagina);
            if (dibujaRec == true)
            {
                pagina.FillRectangle(new SolidBrush(Color.Red), 165, 145, 80, 30);
                pagina.DrawString("Integer", new Font("Arial", 10), Brushes.Black, 165, 145);
            }
            g.DrawImage(bmp, 0, 0);
        }
        private void dibujaMundo(Graphics p)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Mundo[j, i].dibujaCubo(p);
                }
            }
            p.FillRectangle(Brocha, 5, 300, 300, 30);
            p.DrawRectangle(new Pen(Color.Black), 5, 300,300, 30);
            //p.FillPolygon(Brocha, new Point(140, 210), );
            //p.DrawRectangle(new Pen(Color.Black), 5, 300, 300, 30);
            p.DrawString("Object Realm", new Font("Arial", 15), Brushes.Black, 5, 305);
            p.DrawRectangle(new Pen(Color.Black),157,14,297,172);
            p.FillRectangle(Brocha, 158, 15, 295, 170);
            //
            p.DrawRectangle(new Pen(Color.Black), 165, 145, 80, 30);
            p.DrawString("Integer", new Font("Arial", 10), Brushes.Black, 165, 145);
            p.DrawRectangle(new Pen(Color.Black), 265, 145, 80, 30);
            p.DrawString("Fraction", new Font("Arial", 10), Brushes.Black, 265, 145);
            p.DrawRectangle(new Pen(Color.Black), 365, 145, 80, 30);
            p.DrawString("Float", new Font("Arial", 10), Brushes.Black, 365, 145);
            p.DrawRectangle(new Pen(Color.Black), 165, 105, 80, 30);
            p.DrawString("Char", new Font("Arial", 10), Brushes.Black, 165, 105);
            p.DrawRectangle(new Pen(Color.Black), 265, 105, 80, 30);
            p.DrawString("Number", new Font("Arial", 10), Brushes.Black, 265, 105);
            p.DrawRectangle(new Pen(Color.Black), 215, 65, 80, 30);
            p.DrawString("Magnitude", new Font("Arial", 10), Brushes.Black, 215, 65);
            p.DrawRectangle(new Pen(Color.Black), 315, 65, 80, 30);
            p.DrawString("Collection", new Font("Arial", 10), Brushes.Black, 315, 65);
            p.DrawRectangle(new Pen(Color.Black), 265, 25, 80, 30);
            p.DrawString("Object", new Font("Arial", 10), Brushes.Black, 265, 25);
        }

        private void Ejecutar_Click(object sender, EventArgs e)
        {
            creaMundo();
            listO.Clear();
            listS.Clear();
            SeparaLineas(LimpiaCadena(CadenaText.Text));
            EjecutaTexto();
        }
        private string LimpiaCadena(string sCadena)
        {
            return sCadena += "\n";
        }
        private void SeparaLineas(String sCadena)
        {
            String cadena = "";
            for (int i = 0; i < sCadena.Length; i++)
            {
                if (sCadena[i] == '.')
                {
                    listS.Add(cadena);
                    i++;
                    cadena = "";
                }
                else
                    cadena += sCadena[i];
            }
        }
        private void EjecutaTexto()
        {
            foreach (String s in listS)
            {
                listO.Add(EjecutaLinea(s));
            }
        }
        private Objeto EjecutaLinea(String sCadena)
        {
            Objeto nuevo = CreaObjeto(sCadena);
            nuevo.cubo = DrawCube(nuevo.iPos, nuevo.sValue, "");
            if (nuevo.listM.Count != 0)
            {
                foreach (Message m in nuevo.listM)
                {
                    nuevo.Modifica_sValor(m, listO);
                    if (m._sValue1 != null)
                        enviaMensaje(nuevo.cubo, m._sOperador);
                    else
                        enviaMensaje(nuevo.cubo, m._sOperador);
                    if (m._sValue1 != null)
                        enviaMensaje(nuevo.cubo, m._sValue1);
                    if (m._sValue2 != null)
                        enviaMensaje(nuevo.cubo, m._sValue2);
                    ClearCube(nuevo.iPos);
                    nuevo.cubo = null;
                    nuevo.CambiaPosObjeto(Mundo);
                    nuevo.cubo = DrawCube(nuevo.iPos, nuevo.sValue, "");
                }
                DrawCube(nuevo.iPos, nuevo.sValue, nuevo.sName);
                return nuevo;
            }
            else
            {
                DrawCube(nuevo.iPos, nuevo.sValue, nuevo.sName);
                return nuevo;
            }
        }
        private Objeto CreaObjeto(String sCadena)
        {
            Objeto nuevo = new Objeto();
            String valor = "";
            nuevo.iPos = RegresaPosLibre();
            //busco el nombre en la cadena de el nuevo objeto que cree y se lo asigno a nuevo
            for (int i = 0; i < sCadena.Length; i++)
            {
                if (sCadena[i] == ':')
                    i = sCadena.Length;
                else
                {
                    nuevo.sName += sCadena[i];
                }
            }
            //elimino de la cadena el nombre +2 es por el :=
            sCadena = sCadena.Remove(0, nuevo.sName.Length + 2);
            for (int i = 0; i < sCadena.Length; i++)
            {
                if (sCadena[i] == '+' || sCadena[i] == '-' || sCadena[i] == '*' || sCadena[i] == '>' || sCadena[i] == '<' || sCadena[i] == 'F' || sCadena[i] == 'B')
                    i = sCadena.Length;
                else
                {
                    valor += sCadena[i];
                }
            }
            nuevo.sValue = valor;
            sCadena = sCadena.Remove(0, valor.Length);
            nuevo.iTipoValue = tipoValue(nuevo.sValue);

            while (sCadena != "")
            {
                switch (sCadena[0])
                {
                    case '+':
                        sCadena = sCadena.Remove(0, 1);
                        String value = "";
                        for (int i = 0; i < sCadena.Length; i++)
                        {
                            if (sCadena[i] != '+' && sCadena[i] != '-' && sCadena[i] != '*' && sCadena[i] != 'F' && sCadena[i] != '>' && sCadena[i] != '<' && sCadena[i] != 'B')
                                value += sCadena[i];
                            else
                            {
                                i = sCadena.Length;
                            }
                        }
                        nuevo.listM.Add(new Message("+", value));
                        sCadena = sCadena.Remove(0, value.Length);
                        break;
                    case '-':
                        sCadena = sCadena.Remove(0, 1);
                        String value1 = "";
                        for (int i = 0; i < sCadena.Length; i++)
                        {
                            if (sCadena[i] != '+' && sCadena[i] != '-' && sCadena[i] != '*' && sCadena[i] != 'F' && sCadena[i] != '>' && sCadena[i] != '<' && sCadena[i] != 'B')
                                value1 += sCadena[i];
                            else
                            {
                                i = sCadena.Length;
                            }
                        }
                        nuevo.listM.Add(new Message("-", value1));
                        sCadena = sCadena.Remove(0, value1.Length);
                        break;
                    case '*':
                        sCadena = sCadena.Remove(0, 1);
                        String value3 = "";
                        for (int i = 0; i < sCadena.Length; i++)
                        {
                            if (sCadena[i] != '+' && sCadena[i] != '-' && sCadena[i] != '*' && sCadena[i] != 'F' && sCadena[i] != '>' && sCadena[i] != '<' && sCadena[i] != 'B')
                                value3 += sCadena[i];
                            else
                            {
                                i = sCadena.Length;
                            }
                        }
                        nuevo.listM.Add(new Message("*", value3));
                        sCadena = sCadena.Remove(0, value3.Length);
                        break;
                    case 'F':
                        sCadena = sCadena.Remove(0, 9);
                        nuevo.listM.Add(new Message("Factorial"));
                        break;
                    case '>':
                        sCadena = sCadena.Remove(0, 1);
                        String value4 = "";
                        for (int i = 0; i < sCadena.Length; i++)
                        {
                            if (sCadena[i] != '+' && sCadena[i] != '-' && sCadena[i] != '*' && sCadena[i] != 'F' && sCadena[i] != '>' && sCadena[i] != '<' && sCadena[i] != 'B')
                                value4 += sCadena[i];
                            else
                            {
                                i = sCadena.Length;
                            }
                        }
                        nuevo.listM.Add(new Message(">", value4));
                        sCadena = sCadena.Remove(0, value4.Length);
                        break;
                    case '<':
                        sCadena = sCadena.Remove(0, 1);
                        String value5 = "";
                        for (int i = 0; i < sCadena.Length; i++)
                        {
                            if (sCadena[i] != '+' && sCadena[i] != '-' && sCadena[i] != '*' && sCadena[i] != 'F' && sCadena[i] != '>' && sCadena[i] != '<' && sCadena[i] != 'B')
                                value5 += sCadena[i];
                            else
                            {
                                i = sCadena.Length;
                            }
                        }
                        nuevo.listM.Add(new Message("<", value5));
                        sCadena = sCadena.Remove(0, value5.Length);
                        break;
                    case 'B':
                        sCadena = sCadena.Remove(0, 8);
                        String value6 = "";
                        for (int i = 0; i < sCadena.Length; i++)
                        {
                            if (sCadena[i] != ' ')
                                value6 += sCadena[i];
                            else
                            {
                                i = sCadena.Length;
                            }
                        }
                        sCadena = sCadena.Remove(0, value6.Length + 1);
                        sCadena = sCadena.Remove(0, 4);
                        String value7 = "";
                        for (int i = 0; i < sCadena.Length; i++)
                        {
                            if (sCadena[i] != '+' && sCadena[i] != '-' && sCadena[i] != '*' && sCadena[i] != 'F' && sCadena[i] != '>' && sCadena[i] != '<' && sCadena[i] != 'B')
                                value7 += sCadena[i];
                            else
                            {
                                i = sCadena.Length;
                            }
                        }
                        //sCadena = sCadena.Remove(0, 4);
                        nuevo.listM.Add(new Message("Between:", value6, value7));
                        sCadena = sCadena.Remove(0, value7.Length);
                        break;
                }
            }
            return nuevo;
        }
        private int tipoValue(String value)
        {
            if (value.CompareTo("false") == 0)
                return 0;
            if (value.CompareTo("true") == 0)
                return 0;
            for(int i=0;i<value.Length;i++)
            {
                if (value[i] == '0' || value[i] == '1' || value[i] == '2' || value[i] == '3' || value[i] == '4' || value[i] == '5' || value[i] == '6' || value[i] == '7' || value[i] == '8' || value[i] == '9')
                    return 1;
            }
            return 2;
        }
        private void ClearCube(int iPos)
        {
            Cubo nuevo = null;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Mundo[i, j].indice == iPos)
                    {
                        nuevo = Mundo[i, j];
                        i = 10;
                        j = 10;
                    }
                }
            }
            nuevo.sValue = "";
            nuevo.sName = "";
            nuevo.bOcupado = false;
            Form1_Paint(this, null);
            for (int y = 0; y < 30; y++)
            {
                nuevo.y += 1;
                Form1_Paint(this, null);
            }
        }
        private Cubo DrawCube(int iPos, String Value,String Name)
        {
            Cubo nuevo = null;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Mundo[i, j].indice == iPos)
                    {
                        nuevo = Mundo[i, j];
                        i = 11;
                        j = 11;
                    }
                }
            }
            //si no esta ocupado lo manda hacia arriba
            if(nuevo.bOcupado == false)
            for (int y = 0; y < 30; y++)
            {
                nuevo.y -= 1;
                Form1_Paint(this, null);
            }
            //lo pone ocupado la de el nombre el valor y ahora se dibuja con nombre
            nuevo.bOcupado = true;
            nuevo.sValue = Value;
            nuevo.sName = Name;
            Form1_Paint(this, null);
            nuevo.puntoMedio = new Point(nuevo.x + 20, nuevo.y - 5);
            return nuevo;
        }
        private int RegresaPosLibre()
        {
            bool linea = true;
            for (int j = 0; j < 9; j += 2)
            {
                for (int i = 9; i > 0; i--)
                {
                    if (Mundo[i, j].bOcupado == true)
                    {
                        linea = false;
                        i = -1;
                    }
                }
                if (linea == true)
                    return Mundo[9, j].indice;
                else
                    linea = true;
            }
            linea = true;
            for (int j = 1; j < 10; j += 2)
            {
                for (int i = 9; i > 0; i--)
                {
                    if (Mundo[i, j].bOcupado == true)
                    {
                        linea = false;
                        i = -1;
                    }
                }
                if (linea == true)
                    return Mundo[9, j].indice;
                else
                    linea = true;
            }
            return 1;
        }

        private void enviaMensaje(Cubo cubo, String mensaje)
        {
            if (esMensaje(mensaje) == true)
            {
                cProgramador.sValue = mensaje;
                Cubo limite = damePrimero(cubo.indice);
                DibujaTrayecto(cProgramador.puntoMedio, new Point(limite.x, limite.y), cubo.puntoMedio);
                ReslataCuadro(mensaje);
            }
            else
            if (buscaValorN(mensaje) != "")
            {
                Cubo limite = damePrimero(cubo.indice);
                Objeto objeto = buscaValorO(mensaje);
                DibujaTrayecto(objeto.cubo.puntoMedio, new Point(limite.x, limite.y), cubo.puntoMedio);
                ReslataCuadro(mensaje);
            }
            else
            {
                cProgramador.sValue = mensaje;
                Cubo limite = damePrimero(cubo.indice);
                DibujaTrayecto(cProgramador.puntoMedio, new Point(limite.x, limite.y), cubo.puntoMedio);
                ReslataCuadro(mensaje);
            }
        }
        private bool esMensaje(String mensaje)
        {
            switch (mensaje[0])
            {
                case '+':
                case '-':
                case '!':
                case 'B':
                case '>':
                case '<':
                    return true;
            }
            return false;
        }
        private Cubo damePrimero(int indice)
        {
            bool linea = false;
            for (int j = 0; j < 9; j += 1)
            {
                for (int i = 9; i > 0; i--)
                {
                    if (Mundo[i, j].indice == indice)
                    {
                        linea = true;
                        i = -1;
                    }
                }
                if (linea == true)
                    return Mundo[9, j];
                else
                    linea = false;
            }
            return null;
        }
        private void DibujaTrayecto(Point Origen, Point Limite,Point Destino)
        {
            p1 = Origen;

            p2.X = p1.X;
            p2.Y = p1.Y;
            p3.X = p2.X;
            p3.Y = p2.Y;
            p4.X = p3.X;
            p4.Y = p3.Y;
            p5.X = p4.X;
            p5.Y = p4.Y;
            for (int i = 0; i < 10; i++)//Se levanta
            {
                p2.Y -= 5;
                Form1_Paint(this,null);
            }
            p3.X = p2.X;
            p3.Y = p2.Y;
            p4.X = p3.X;
            p4.Y = p3.Y;
            p5.X = p4.X;
            p5.Y = p4.Y;
            if (Limite.X < p3.X)
            {
                for (;;)//Se dirige al limite
                {
                    p3.X -= 5;
                    if (Limite.X > p3.X)
                        break;
                    Form1_Paint(this, null);
                }
            }
            else
            {
                for (;;)//Se dirige al limite
                {
                    p3.X += 5;
                    if (Limite.X+35 < p3.X)
                        break;
                    Form1_Paint(this, null);
                }
            }
            p4.X = p3.X;
            p4.Y = p3.Y;
            p5.X = p4.X;
            p5.Y = p4.Y;
            if (p4.X < Destino.X)
            {
                for (;;)
                {
                    p4.X += 15;
                    p4.Y -= 30 / 3;
                    if (p4.X > Destino.X)
                        break;
                    Form1_Paint(this, null);
                }
            }
            else
            {
                for (;;)
                {
                    p4.X -= 15;
                    p4.Y += 30 / 3;
                    if (p4.X < Destino.X)
                        break;
                    Form1_Paint(this, null);
                }
            }
            p5.X = p4.X;
            p5.Y = p4.Y;
            for (; ; )
            {
                p5.Y += 5;
                if (p5.Y > Destino.Y)
                    break;
                Form1_Paint(this, null);
            }
            //Atras
            for (int i = 0; i < 10; i++)
            {
                p1.Y -= 5;
                Form1_Paint(this, null);
            }
            if (Limite.X < p2.X)
            {
                for (;;)
                {
                    p2.X -= 5;
                    p1.X -= 5;
                    if (Limite.X > p2.X)
                        break;
                    Form1_Paint(this, null);
                }
            }
            else
            {
                for (;;)
                {
                    p2.X += 5;
                    p1.X += 5;
                    if (Limite.X < p2.X)
                        break;
                    Form1_Paint(this, null);
                }
            }
            if (p3.X < Destino.X)
            {
                for (;;)
                {
                    p3.X += 15;
                    p3.Y -= 30 / 3;
                    p2.X += 15;
                    p2.Y -= 30 / 3;
                    p1.X += 15;
                    p1.Y -= 30 / 3;
                    if (p3.X > Destino.X)
                        break;
                    Form1_Paint(this, null);
                }
            }
            else
            {
                for (;;)
                {
                    p3.X -= 15;
                    p3.Y += 30 / 3;
                    p2.X -= 15;
                    p2.Y += 30 / 3;
                    p1.X -= 15;
                    p1.Y += 30 / 3;
                    if (p3.X < Destino.X)
                        break;
                    Form1_Paint(this, null);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                p4.Y += 5;
                p3.Y += 5;
                p2.Y += 5;
                p1.Y += 5;
                Form1_Paint(this, null);
            }
            p1 = new Point();
            p2 = new Point();
            p3 = new Point();
            p4 = new Point();
            p5 = new Point();
            cProgramador.sValue = "";
        }

        private String buscaValorN(String name)
        {
            foreach (Objeto o in listO)
            {
                if (o.sName.CompareTo(name) == 0)
                    return o.sValue;
            }
            return "";
        }
        private Objeto buscaValorO(String name)
        {
            foreach (Objeto o in listO)
            {
                if (o.sName.CompareTo(name) == 0)
                    return o;
            }
            return null;
        }
      
        
        private void DrawLine(Graphics g)
        {
            g.DrawLine(pluma1, p1, p2);
            g.DrawLine(pluma1, p2, p3);
            g.DrawLine(pluma1, p3, p4);
            g.DrawLine(pluma1, p4, p5);
        }
        private void ReslataCuadro(String mensaje)
        {
            switch (mensaje)
            {
                case "+":
                    for (int i = 0; i < 50; i++)
                    {
                        dibujaRec = true;
                        Form1_Paint(this,null);
                        if (dibujaRec == true)
                            dibujaRec = false;
                        else
                            dibujaRec = true;
                    }
                    break;
                case "Factorial":
                    for (int i = 0; i < 50; i++)
                    {
                        dibujaRec = true;
                        Form1_Paint(this, null);
                        if (dibujaRec == true)
                            dibujaRec = false;
                        else
                            dibujaRec = true;
                    }
                    break;
            }
        }
        private void Abrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogoArchivo = new OpenFileDialog();

            DialogoArchivo.Filter = "txt files (*.txt)|*.txt";
            DialogoArchivo.FilterIndex = 2;
            DialogoArchivo.RestoreDirectory = true;

            if (DialogoArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(DialogoArchivo.FileName))
                    {
                        string line="";
                        while (sr.EndOfStream == false)
                        {
                           line += sr.ReadLine();
                        }
                        CadenaText.Text = line;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
