using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Matriz nuevo = new Matriz();
            Unidad u1 = new Unidad(0, 0);
            Unidad u2 = new Unidad(1, 1);
            Unidad u3 = new Unidad(1, 3);
            Unidad u4 = new Unidad(0, 0);
            Unidad u5 = new Unidad(2, 1);
            Unidad u6 = new Unidad(3, 1);
            Unidad u7 = new Unidad(2, 1);

            nuevo.insertar(1, "A", ref u1);
            nuevo.insertar(1, "B", ref u2);
            nuevo.insertar(1, "A", ref u3);
            nuevo.insertar(1, "B", ref u4);
            nuevo.insertar(1, "A", ref u5);
            nuevo.insertar(1, "B", ref u6);
            nuevo.insertar(1, "B", ref u7);

      //      nuevo.insertar(1, "B", ref u2);
            //nuevo.insertar(1, "B", ref u4);


            //Unidad u5 = new Unidad(0, 0);
            //Unidad u6 = new Unidad(1, 1);
            //Unidad u7 = new Unidad(2, 3);
            //Unidad u8 = new Unidad(3, 6);

            //nuevo.insertar(2, "A", ref u5);
            //nuevo.insertar(2, "A", ref u6);
            //nuevo.insertar(2, "A", ref u7);
            //nuevo.insertar(2, "D", ref u8);

            //Unidad u9 = new Unidad(0, 0);
            //Unidad u10 = new Unidad(1, 1);
            //Unidad u11 = new Unidad(2, 3);
            //Unidad u12 = new Unidad(3, 6);

            //nuevo.insertar(1, "A", ref u1);
            //nuevo.insertar(1, "A", ref u2);
            //nuevo.insertar(1, "A", ref u3);
            //nuevo.insertar(1, "A", ref u4);

           // Unidad u5 = new Unidad(0, 0);
           // Unidad u6 = new Unidad(1, 1);
           // Unidad u7 = new Unidad(2, 3);
           // Unidad u8 = new Unidad(3, 6);

           //// nuevo.insertar(1, "C", ref u5);
           //// nuevo.insertar(1, "C", ref u6);
           ////// nuevo.insertar(1, "C", ref u3);
           //// nuevo.insertar(1, "C", ref u8);


            //Unidad u9 = new Unidad(0, 0);
            //Unidad u10 = new Unidad(1, 1);
            //Unidad u11 = new Unidad(2, 3);
            //Unidad u12 = new Unidad(3, 6);

            //nuevo.insertar(1, "B", ref u9);
            //nuevo.insertar(1, "B", ref u12);
            //nuevo.insertar(1, "B", ref u10);
            //nuevo.insertar(1, "B", ref u11);
            //nuevo.insertar(1, "D", ref u12);






            //Unidad u1 = new Unidad(3, 6);
            //Unidad u2 = new Unidad(2, 5);
            //Unidad u3 = new Unidad(1, 2);
            //Unidad u4 = new Unidad(1,2);
            //Unidad u5 = new Unidad(1, 2);
            //Unidad u6 = new Unidad(0, 0);

            //Unidad u7 = new Unidad(1, 2);
            //Unidad u8 = new Unidad(1, 2);
            //Unidad u9 = new Unidad(1, 2);

            //nuevo.insertar(1, "A", ref u1);
            //nuevo.insertar(12, "D", ref u2);

            //nuevo.insertar(8, "E", ref u3);
            //nuevo.insertar(9, "E", ref u7);
            //nuevo.insertar(10, "E", ref u8);
            //nuevo.insertar(11, "E", ref u9);

            //nuevo.insertar(2, "F", ref u4);
            //nuevo.insertar(5, "G", ref u5);
            //nuevo.insertar(7, "V", ref u6);

           // Grafo g = new Grafo();
           // g.generarMatriz(nuevo, 1);

        }
    }
}
