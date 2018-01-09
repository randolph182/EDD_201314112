﻿using System;
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

        protected void btnAdminContacUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminContactosUsuarios.aspx");
        }

        protected void btnCargaMasivaContactos_Click(object sender, EventArgs e)
        {
            string direccion = Server.MapPath(FileUpload3.FileName);
            if(direccion !="")
            {
                int contador = 0;
                string linea;
                using (StreamReader sr =File.OpenText(direccion))
                {
                    while((linea = sr.ReadLine()) != null)
                    {
                        if(contador !=0)
                        {
                            string[] info = linea.Split(',');
                            string nickUsuario = info[0];
                            string nickContacto = info[1];
                            string contra = info[2];
                            string email = info[3];
                            ClaseGlobal.servidorPrincipal.insertarAVL(nickUsuario, nickContacto, contra, email);
                        
                        }
                        contador++;
                    }
                    sr.Close();
                }
            }
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnCargaMasivaTablero_Click(object sender, EventArgs e)
        {
            string direccion = Server.MapPath(FileUpload4.FileName);
            if (direccion != "")
            {
                int contador = 0;
                string linea;
                using (StreamReader sr = File.OpenText(direccion))
                {
                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (contador != 0)
                        {
                            string[] info = linea.Split(',');
                            string nickUsuario = info[0];
                            string columna = info[1];
                            int fila = Convert.ToInt32(info[2]);
                            string idUnidad = info[3];
                            int unidadDestuida = Convert.ToInt32(info[4]);
                            
                            int nivel = 0;
                            int tipoUnidad = 0;
                            descifrarUnidad(idUnidad, ref nivel, ref tipoUnidad);
                            ClaseGlobal.servidorPrincipal.insertarCuboTmp(nickUsuario, fila, columna, idUnidad, nivel, tipoUnidad, unidadDestuida);
                        }
                        contador++;
                    }
                    sr.Close();
                }
            }
            MultiView1.ActiveViewIndex = 1;
        }

        protected void descifrarUnidad(string idUnidad,ref int nivel, ref int tipoUnidad)
        {
            if(idUnidad.Contains("Neosatelite"))
            {
                nivel = 3;
                tipoUnidad = 6;
            }
            else if( idUnidad.Contains("Bombardero"))
            {
                nivel = 2;
                tipoUnidad = 5;
            }
            else if (idUnidad.Contains("Caza"))
            {
                nivel = 2;
                tipoUnidad = 4;
            }
            else if (idUnidad.Contains("Helicóptero"))
            {
                nivel = 2;
                tipoUnidad = 3;
            }
            else if (idUnidad.Contains("Fragata"))
            {
                nivel = 1;
                tipoUnidad = 2;
            }
            else if (idUnidad.Contains("Crucero"))
            {
                nivel = 1;
                tipoUnidad = 1;
            }
            else if (idUnidad.Contains("submarino"))
            {
                nivel = 0;
                tipoUnidad = 0;
            }
            
        }

        protected void btnMostrarTablero_Click(object sender, EventArgs e)
        {
            Response.Redirect("TableroConfiguado.aspx");
        }
    }
}