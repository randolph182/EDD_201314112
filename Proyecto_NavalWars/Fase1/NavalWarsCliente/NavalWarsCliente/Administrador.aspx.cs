using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

namespace NavalWarsCliente
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnAdminUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUsuarios.aspx");
        }

        protected void btnJuegos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLstJuegos.aspx");
        }

        protected void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnSubirUsuarios_Click(object sender, EventArgs e)
        {
           // string direccion = Path.GetFullPath(FileUpload1.FileName);
            string direccion = Server.MapPath(FileUpload1.FileName);
            
            if(direccion != "")
            {
                int contador = 0;
                string linea;
                using (StreamReader sr = File.OpenText(direccion)) 
                {
                    //linea  = sr.ReadLine();
                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (contador != 0)
                        {
                            string[] iu = linea.Split(',');
                            ClaseGlobal.servidorPrincipal.insertarUsuario(iu[0], " ", iu[1], iu[2], Convert.ToInt32(iu[3]));
                        }
                        contador++;
                    }
                    sr.Close();
                }
                               
            }
            MultiView1.ActiveViewIndex = 1;
        }

        protected void subierArchivoJuegos_Click(object sender, EventArgs e)
        {
            string direccion = Server.MapPath(FileUpload2.FileName);

            if (direccion != "")
            {
                int contador = 0;
                string linea;
                using (StreamReader sr = File.OpenText(direccion))
                {
                    //linea  = sr.ReadLine();
                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (contador != 0)
                        {
                            string[] ij = linea.Split(',');
                            ClaseGlobal.servidorPrincipal.addjuegosUsuario(ij[0], ij[1], Convert.ToInt32(ij[2]), Convert.ToInt32(ij[3]), Convert.ToInt32(ij[4]), Convert.ToInt32(ij[5]));
                            
                        }
                        contador++;
                    }
                    sr.Close();
                }

            }
            MultiView1.ActiveViewIndex = 1;
        }
    }
}