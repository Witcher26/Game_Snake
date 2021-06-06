using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_snake
{
    public partial class Form1 : Form
    {
        Point[] p; //массив для хранения координат
        Point apple; //  Яблоко
        int Len; // длина червя
        int derection; // направление двжиения: 1 - налево, 2-направо, 3 - наверх, 4-вниз
        public Form1()
        {
            InitializeComponent();
            Len = 7; //длина червя
            p = new Point[200]; // максимальное кол-во координат/червя
            derection = 3;
            for (int i=0; i < Len; i++)
            {
                p[i].X = 100;
                p[i].X = 100+i*50; // начальные координаты червя, размещение червяка горизонтальное
                //10 пикселей одно поле.
             }

            apple.X = 400;
            apple.Y = 400;
                             
                
                 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for ( int i=198; i>=0; i--)
            {
                p[i+1].X = p[i].X;
                p[i + 1].Y = p[i].Y;// движение массива от 199 до 0
            }
            if (derection ==1)
            {
                
                p[0].X = p[1].X - 15;
                if (p[0].X < 0) p[0].X= 490;
                p[0].Y = p[1].Y;
                
                
            }

            if (derection == 2)
            {
                p[0].X = p[1].X + 15;
                if (p[0].X > 490) p[0].X = 0;
                p[0].Y = p[1].Y;// д
            }


            if (derection == 3)
            {
                p[0].X = p[1].X;
                p[0].Y = p[1].Y-15;// отчёт по Y идёт сверху вниз 
                if (p[0].Y < 0) p[0].Y = 490;
            }
            if (derection == 4)
            {
                p[0].X = p[1].X;
                p[0].Y = p[1].Y+15;
                if (p[0].Y >490) p[0].Y = 0;
            }
            // отрисовка червя
            SolidBrush b = new SolidBrush(Color.Black);
            for (int i =0; i<Len; i++)
            {
                e.Graphics.FillEllipse(b, p[i].X, p[i].Y, 15, 15); // размеры точек 10 на 10
            }

            SolidBrush b1 = new SolidBrush(Color.Green);
            
            {
                e.Graphics.FillEllipse(b1, apple.X, apple.Y, 50, 50);
            }
            if(p[0].X==apple.X && p[0].Y==apple.Y) // событие после съедения яблока
            {
                Len++;
                Random R;
                R = new Random();
                apple.X = R.Next(0, 50) * 10;
                apple.Y = R.Next(0, 50) * 10;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate(); //  метод Invalidate - перерисовка формы
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // управление с клавиатуры. 
            if (e.KeyCode == Keys.Left)
                derection = 1;
            if (e.KeyCode == Keys.Right)
                derection = 2;
            if (e.KeyCode == Keys.Up)
                derection = 3;
            if (e.KeyCode == Keys.Down)
                derection = 4;
            

        }
    }
}
