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
            string direccion = Path.GetFullPath(FileUpload1.FileName);
            var path = Server.MapPath(@""+ FileUpload1.FileName);
            if(direccion != "")
            {
                StreamReader file = new StreamReader(path,true);
               // System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);
                int contador = 0;
                string linea;
                while((linea = file.ReadLine())!=null)
                {
                    if(contador != 0)
                    {
                        foreach(string info in linea.ToString().Split(','))
                        {
                            Response.Write("<script LANGUAGE='JavaScript' >alert('"+ info +"')</script>");
                        }
                    }
                    contador++;
                }
                file.Close();
            }
        }
    }
}