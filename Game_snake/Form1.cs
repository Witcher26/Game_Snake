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
        Point[] p; //массив для сохранения координат
        Point apple; //  Яблоко
        int Len; // длина червя
        int derection; // 1 - left, 2-right, 3 - top, 4-button
        public Form1()
        {
            InitializeComponent();
            Len = 5; //длина червя
            p = new Point[200]; // максммальная длина червя из 200 точек//инициализация массива
            derection = 3;
            for (int i=0; i < 5; i++)
            {
                p[i].X = 100;
                p[i].X = 100+i*10; // начальные координаты червя, размещение червяка вертилкально
                //10 пикселей одно поле.
             }

            apple.X = 10;
            apple.Y = 10;
                             
                
                 
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
                
                p[0].X = p[1].X - 10;
                if (p[0].X < 0) p[0].X= 490;
                p[0].Y = p[1].Y;
                
                
            }

            if (derection == 2)
            {
                p[0].X = p[1].X + 10;
                if (p[0].X > 490) p[0].X = 0;
                p[0].Y = p[1].Y;// д
            }


            if (derection == 3)
            {
                p[0].X = p[1].X;
                p[0].Y = p[1].Y-10;// отчёт по Y идёт сверху вниз 
                if (p[0].Y < 0) p[0].Y = 490;
            }
            if (derection == 4)
            {
                p[0].X = p[1].X;
                p[0].Y = p[1].Y+10;
                if (p[0].Y >490) p[0].Y = 0;
            }
            // отрисовка червя
            SolidBrush b = new SolidBrush(Color.Brown);
            for (int i =0; i<Len; i++)
            {
                e.Graphics.FillEllipse(b, p[i].X, p[i].Y, 10, 10);
            }

            SolidBrush b1 = new SolidBrush(Color.Green);
            
            {
                e.Graphics.FillEllipse(b1, apple.X, apple.Y, 10, 10);
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
