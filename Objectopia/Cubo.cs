using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectopia
{
    class Cubo
    {
        public Point puntoMedio;
        int TAM;
        int PROFX;
        int PROFY;
        public int x;
        public int y;
        public int indice;
        public bool bOcupado;
        public String sValue;
        public String sName;

        public Cubo()
        {
            sValue = "";
            sName = "";
            TAM = 30;
            PROFX = TAM / 2;
            PROFY = TAM / 3;
            x = 0;
            y = 0;           
            indice = 0;
            bOcupado = false;
        }
        public Cubo(int _x, int _y)
        {
            sValue = "";
            sName = "Programador";
            TAM = 30;
            PROFX = TAM / 2;
            PROFY = TAM / 3;
            indice = 0;
            bOcupado = false;
            x = _x;
            y = _y;
            puntoMedio = new Point(x + 20, y - 5);
        }
        public void dibujaProgramador(Graphics g)
        {
            Point[] Puntos = new Point[4];
            SolidBrush brocha = new SolidBrush(Color.Aqua);
            //Cara frontal
            Puntos[0].X = x;
            Puntos[0].Y = y;
            Puntos[1].X = x + TAM;
            Puntos[1].Y = y;
            Puntos[2].X = x + TAM;
            Puntos[2].Y = y + TAM;
            Puntos[3].X = x;
            Puntos[3].Y = y + TAM;
            g.FillPolygon(brocha, Puntos);
            g.DrawPolygon(new Pen(Color.Black), Puntos);
            //Cara SUperior
            Puntos[0].X = x;
            Puntos[0].Y = y;
            Puntos[1].X = x + PROFX;
            Puntos[1].Y = y - PROFY;
            Puntos[2].X = x + TAM + PROFX;
            Puntos[2].Y = y - PROFY;
            Puntos[3].X = x + TAM;
            Puntos[3].Y = y;
            g.FillPolygon(brocha, Puntos);
            g.DrawPolygon(new Pen(Color.Black), Puntos);
            //Cara Lateral
            Puntos[0].X = x + TAM;
            Puntos[0].Y = y;
            Puntos[1].X = x + TAM + PROFX;
            Puntos[1].Y = y - PROFY;
            Puntos[2].X = x + TAM + PROFX;
            Puntos[2].Y = y + TAM - PROFY;
            Puntos[3].X = x + TAM;
            Puntos[3].Y = y + TAM;
            g.FillPolygon(brocha, Puntos);
            g.DrawPolygon(new Pen(Color.Black), Puntos);

            g.DrawString(sValue, new Font("Arial", 15), Brushes.Black, x + 4, y - 18);
            g.DrawString("<="+sName, new Font("Arial", 10), Brushes.Black, x + 30, y + 5);
        }
        public void dibujaCubo(Graphics g)
        {
            Point[] Puntos = new Point[4];
            SolidBrush brocha = new SolidBrush(Color.AliceBlue);
            //Cara frontal
            Puntos[0].X = x;        
            Puntos[0].Y = y;
            Puntos[1].X = x + TAM; 
            Puntos[1].Y = y;
            Puntos[2].X = x + TAM;   
            Puntos[2].Y = y + TAM;
            Puntos[3].X = x;
            Puntos[3].Y = y + TAM;
            g.FillPolygon(brocha, Puntos);
            g.DrawPolygon(new Pen(Color.Black), Puntos);
            //Cara SUperior
            Puntos[0].X = x;        
            Puntos[0].Y = y;
            Puntos[1].X =x + PROFX;
            Puntos[1].Y = y- PROFY;
            Puntos[2].X = x + TAM + PROFX;  
            Puntos[2].Y = y - PROFY;
            Puntos[3].X = x + TAM;
            Puntos[3].Y = y;
            g.FillPolygon(brocha, Puntos);
            g.DrawPolygon(new Pen(Color.Black), Puntos);
            //Cara Lateral
            Puntos[0].X = x+ TAM;
            Puntos[0].Y = y;
            Puntos[1].X = x + TAM + PROFX; 
            Puntos[1].Y = y - PROFY;
            Puntos[2].X = x + TAM + PROFX;
            Puntos[2].Y = y + TAM - PROFY;
            Puntos[3].X = x + TAM;
            Puntos[3].Y = y + TAM;
            g.FillPolygon(brocha, Puntos);
            g.DrawPolygon(new Pen(Color.Black), Puntos);

            g.DrawString(sValue, new Font("Arial", 15), Brushes.Black,x + 4,y - 18);
            g.DrawString(sName, new Font("Arial", 10), Brushes.Black, x + 10, y + 5);
        }
    }   
}
