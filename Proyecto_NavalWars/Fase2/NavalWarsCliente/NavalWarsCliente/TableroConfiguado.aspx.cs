using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavalWarsCliente
{
    public partial class TableroConfiguado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador.aspx");
        }

        protected void MostrarUnidades_Click(object sender, EventArgs e)
        {
            int select = DropDownList1.SelectedIndex;
            switch (select)
            {
                case 0:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerUnidadDetuida(0,0);
                    mostrarImagen("matriz0.png");
                    break;

                case 1:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerUnidadDetuida(1, 0);
                    mostrarImagen("matriz1.png");
                    break;
                case 2:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerUnidadDetuida(2, 0);
                    mostrarImagen("matriz2.png");
                    break;
                case 3:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerUnidadDetuida(3, 0);
                    mostrarImagen("matriz3.png");
                    break;
                case 4:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerUnidadDetuida(0, 1);
                    mostrarImagen("matriz0.png");
                    break;
                case 5:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerUnidadDetuida(1, 1);
                    mostrarImagen("matriz1.png");
                    break;
                case 6:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerUnidadDetuida(2, 1);
                    mostrarImagen("matriz2.png");
                    break;
                case 7:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerUnidadDetuida(3, 1);
                    mostrarImagen("matriz3.png");
                    break;

                case 8:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerNivel(0);
                    mostrarImagen("matriz0.png");
                    break;

                case 9:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerNivel(1);
                    mostrarImagen("matriz1.png");
                    break;

                case 10:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerNivel(2);
                    mostrarImagen("matriz2.png");
                    break;

                case 11:
                    ClaseGlobal.servidorPrincipal.graficarMatrizPerNivel(3);
                    mostrarImagen("matriz3.png");
                    break;
            }
        }
        protected void mostrarImagen(string nombreArchivo)
        {
            try
            {
                string path = "C:/GrafoEDD/" + nombreArchivo;
                byte[] imageByteData = System.IO.File.ReadAllBytes(path);
                string imageBase64Data = Convert.ToBase64String(imageByteData);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                Image1.ImageUrl = imageDataURL;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudo mostrar el Arbol')", true);
            }
        }
    }
}