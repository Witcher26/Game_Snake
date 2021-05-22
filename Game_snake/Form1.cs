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
        Point[] p; // Создаем массив из точек
        int Len; // длина червя
        int derection; // 1 - left, 2-right, 3 - top, 4-button
        public Form1()
        {
            InitializeComponent();
            Len = 5; //длина червя
            p = new Point[200]; // длина червя из 200 точек//инициализация массива
            derection = 3;
            for (int i=0; i < 5; i++)
                {
                p[i].X = 100;
                p[i].X = 1000+i*10; // начальные координаты червя, размещение червяка вертилкально
                }
                             
                
                 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
