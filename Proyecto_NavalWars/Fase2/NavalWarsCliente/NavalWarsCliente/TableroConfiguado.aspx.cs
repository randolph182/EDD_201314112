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
            switch(select)
            {
                case 0:

                break;

                case 1:
                break;
                case 2:
                break;
                case 3:
                break;
                case 4:
                break;
                case 5:
                break;
                case 6:
                break;
                case 7:
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