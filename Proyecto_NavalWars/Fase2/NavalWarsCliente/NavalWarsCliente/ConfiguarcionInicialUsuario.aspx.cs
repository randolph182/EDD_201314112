using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavalWarsCliente
{
    public partial class ConfiguarcionInicialUsuario : System.Web.UI.Page
    {
        public static int MaxFilas = 0;
        public static int MaxColumnas = 0;
        public static string nickOp1 = "";
        public static string nickOp2 = "";
        public static int contUnidad = 0;
        public static int cantN0 = 0;
        public static int cantN1 = 0;
        public static int cantN2 = 0;
        public static int cantN3 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtIDUsuario.Text = Session["sesion"].ToString();
                configurarParametrosInicial();
            }
            
        }

        public void configurarParametrosInicial()
        {
            try
            {
                List<string> info =ClaseGlobal.servidorPrincipal.buscarInfoPorOponente(Session["sesion"].ToString());
                if(info.Count !=0)
                {
                    txtCantidadSubmarinos.Text = info[0];
                    cantN0 = Convert.ToInt32(info[0]);
                    txtCantidadUnidadesBarcos.Text = info[1];
                    cantN1 = Convert.ToInt32(info[1]);
                    txtCantidadUnidadesAviones.Text = info[2];
                    cantN2 = Convert.ToInt32(info[2]);
                    txtCantidadUnidadesSatelites.Text = info[3];
                    cantN3 = Convert.ToInt32(info[3]);
                    MaxFilas = Convert.ToInt32(info[4]);
                    MaxColumnas = Convert.ToInt32(info[5]);
                    if(Session["sesion"].ToString() == info[6])
                    {
                        nickOp1 = info[6];
                        nickOp2 = info[7];
                    }
                    else
                    {
                        nickOp1 = info[6];
                        nickOp2 = info[7];
                    }
                    configurarFilasCols();
                        
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void configurarFilasCols()
        {
            if(Session["sesion"].ToString() == nickOp1)
            {
                int posMediaFilas = MaxFilas / 2;
                for (int i = 1; i <= posMediaFilas; i++)
                {
                    ListItem item = new ListItem(i.ToString(), i.ToString());
                    ddLstFilasSubmarinos.Items.Add(item);
                    ddLstFilaBarcos.Items.Add(item);
                    ddLstFilaAviones.Items.Add(item);
                    ddLstFilaSatelites.Items.Add(item);
                }
                int j = 1;
                int col = 65;
                while(MaxColumnas != j)
                {
                    string columna = Convert.ToChar(col).ToString();
                    ListItem item = new ListItem(columna,j.ToString());
                    ddLstColumnaSubmarinos.Items.Add(item);
                    ddLstColumnaBarcos.Items.Add(item);
                    ddLstColumnaAviones.Items.Add(item);
                    ddLstColumnaSatelites.Items.Add(item);
                    col++;
                    j++;
                }
            }
            else
            {
                int posMediaFilas = MaxFilas / 2;
                for (int i = MaxFilas; i >= posMediaFilas; i--)
                {
                    ListItem item = new ListItem(i.ToString(), i.ToString());
                    ddLstFilasSubmarinos.Items.Add(item);
                    ddLstFilaBarcos.Items.Add(item);
                    ddLstFilaAviones.Items.Add(item);
                    ddLstFilaSatelites.Items.Add(item);
                }
                int j = 1;
                int col = 65;
                while (MaxColumnas != j)
                {
                    string columna = Convert.ToChar(col).ToString();
                    ListItem item = new ListItem(columna, j.ToString());
                    ddLstColumnaSubmarinos.Items.Add(item);
                    ddLstColumnaBarcos.Items.Add(item);
                    ddLstColumnaAviones.Items.Add(item);
                    ddLstColumnaSatelites.Items.Add(item);
                    col++;
                    j++;
                }
            }

        }

        protected void btnInsertarSubmarino_Click(object sender, EventArgs e)
        {
            if (cantN0 == 0)
                return;
            int fila = Convert.ToInt32(ddLstFilasSubmarinos.SelectedItem.ToString());
            string columna = ddLstColumnaSubmarinos.SelectedItem.ToString();
            int tipoUnidad = 0;
            int nivel = 0;
            int noUnidad = contUnidad;
            ClaseGlobal.servidorPrincipal.insertarTableroPrincipa(nickOp1, nickOp2, fila, columna, nivel, tipoUnidad, noUnidad);
            contUnidad++;
            cantN0--;
            ClaseGlobal.servidorPrincipal.graficarMatriz(nickOp1, nickOp2);
            //imgSubmarinos.ImageUrl = mostrarImagen("matriz0.png");
            mostrarImagen2();
            txtCantidadSubmarinos.Text = cantN0.ToString();
        }

        protected void btnInsertarBarcos_Click(object sender, EventArgs e)
        {
            if (cantN1 == 0)
                return;
            int fila = Convert.ToInt32(ddLstFilaBarcos.SelectedItem.ToString());
            string columna = ddLstColumnaBarcos.SelectedItem.ToString();
            int tipoUnidad = 0;
            if (ddLstUnidadBarcos.SelectedIndex == 0) //crucero
                tipoUnidad = 1;
            else if (ddLstUnidadBarcos.SelectedIndex == 1) //fragata
                tipoUnidad = 2;
            else
                tipoUnidad = 1;
            
            int nivel = 1;
            int noUnidad = contUnidad;
            ClaseGlobal.servidorPrincipal.insertarTableroPrincipa(nickOp1, nickOp2, fila, columna, nivel, tipoUnidad, noUnidad);
            contUnidad++;
            cantN1--;
            ClaseGlobal.servidorPrincipal.graficarMatriz(nickOp1, nickOp2);
            //imgBarcos.ImageUrl = mostrarImagen("matriz1.png");
            mostrarImagen2();
            txtCantidadUnidadesBarcos.Text = cantN1.ToString();
        }
        protected void bntInsertarAviones_Click(object sender, EventArgs e)
        {
            if (cantN2 == 0)
                return;
            int fila = Convert.ToInt32(ddLstFilaAviones.SelectedItem.ToString());
            string columna = ddLstColumnaAviones.SelectedItem.ToString();
            int tipoUnidad = 0;
            if (ddLstUnidadAviones.SelectedIndex == 0) //helicoptero
                tipoUnidad = 3;
            else if (ddLstUnidadAviones.SelectedIndex == 1) //Caza
                tipoUnidad = 4;
            else if (ddLstUnidadAviones.SelectedIndex == 2) //bombardero
                tipoUnidad = 5;
            else
                tipoUnidad = 3;
            int nivel = 2;
            int noUnidad = contUnidad;
            ClaseGlobal.servidorPrincipal.insertarTableroPrincipa(nickOp1, nickOp2, fila, columna, nivel, tipoUnidad, noUnidad);
            contUnidad++;
            cantN2--;
            ClaseGlobal.servidorPrincipal.graficarMatriz(nickOp1, nickOp2);
            //imgAviones.ImageUrl = mostrarImagen("matriz2.png");
            mostrarImagen2();
            txtCantidadUnidadesAviones.Text = cantN2.ToString();
        }

        protected void btnInsertarSatelites_Click(object sender, EventArgs e)
        {
            if (cantN3 == 0)
                return;
            int fila = Convert.ToInt32(ddLstFilaSatelites.SelectedItem.ToString());
            string columna = ddLstColumnaSatelites.SelectedItem.ToString();
            int tipoUnidad = 6;
            int nivel = 3;
            int noUnidad = contUnidad;
            ClaseGlobal.servidorPrincipal.insertarTableroPrincipa(nickOp1, nickOp2, fila, columna, nivel, tipoUnidad, noUnidad);
            contUnidad++;
            cantN3--;
            ClaseGlobal.servidorPrincipal.graficarMatriz(nickOp1, nickOp2);
            //imgSatelites.ImageUrl = mostrarImagen("matriz3.png");
            mostrarImagen2();
            txtCantidadUnidadesSatelites.Text = cantN3.ToString();
        }

        protected string mostrarImagen(string nombreArchivo)
        {
            try
            {
                string path = "C:/GrafoEDD/" + nombreArchivo;
                byte[] imageByteData = System.IO.File.ReadAllBytes(path);
                string imageBase64Data = Convert.ToBase64String(imageByteData);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                return imageDataURL;
            }
            catch (Exception)
            {
                return "";
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudo mostrar el Arbol')", true);
            }
        }
        protected void mostrarImagen2()
        {
            imgSubmarinos.ImageUrl = mostrarImagen("matriz0.png");
            imgBarcos.ImageUrl = mostrarImagen("matriz1.png");
            imgAviones.ImageUrl = mostrarImagen("matriz2.png");
            imgSatelites.ImageUrl = mostrarImagen("matriz3.png");
        }





    }

    
}