﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavalWarsCliente
{
    public partial class AdminUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnAgregarNuevoUsuario_Click(object sender, EventArgs e)
        {
            bool correcto = ClaseGlobal.servidorPrincipal.insertarUsuario(txtNicknameNU.Text, txtNombreNU.Text, txtPasswordNU.Text, txtEmailNU.Text, 0);
            if (correcto)
                lblMensajeAddUsuario.Text = "Se agrego Correctamente. ";
            else
                lblMensajeAddUsuario.Text = "No se pudo Agregar el Nuevo Usuario ";
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnMostrarArbol_Click(object sender, EventArgs e)
        {
            ClaseGlobal.servidorPrincipal.generarArbol();
            string path = "C:/GrafoEDD/ABBUsuarios.png";
            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            Image1.ImageUrl = imageDataURL;
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3; //view 4
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtNicknameElimU.Text != "")
            {
                bool eliminado = ClaseGlobal.servidorPrincipal.eliminarUsuario(txtNicknameElimU.Text);
                if (eliminado)
                {
                    lblMensajeElimUsuario.Text = "usuario eliminado";
                }
                else
                    lblMensajeElimUsuario.Text = "No se pudo eliminar el Usuario";

            }
            else
                lblMensajeElimUsuario.Text = "Tiene que Ingresar un NickName para eliminar";

            MultiView1.ActiveViewIndex = 3;
        }

        protected void btnRegresarElimU_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnMostrarArbolGeneral_Click(object sender, EventArgs e)
        {
            ClaseGlobal.servidorPrincipal.generarArbol();
            mostrarImagen("ABBUsuarios.png");
            MultiView1.ActiveViewIndex = 4;
        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2; //view3
        }

        protected void btnModificarUM_Click(object sender, EventArgs e)
        {
            if (txtNickNameUMod.Text == txtNickNameNuevoUMod.Text)
            {
                bool modificado = ClaseGlobal.servidorPrincipal.modificarUsuario(txtNickNameUMod.Text, "", txtNombreUMod.Text, txtPasswordUMod.Text, txtEmailUMod.Text, Convert.ToInt16(txtConectadoUMod.Text));
                if (modificado)
                {
                    lblMensajeUModificado.Text = "Se modifico Correctamente";
                }
            }
            else
            {
                bool modificado = ClaseGlobal.servidorPrincipal.modificarUsuario(txtNickNameUMod.Text, txtNickNameNuevoUMod.Text, txtNombreUMod.Text, txtPasswordUMod.Text, txtEmailUMod.Text, Convert.ToInt16(txtConectadoUMod.Text));
                lblMensajeUModificado.Text = "Se modifico Correctamente";
            }
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnBuscarNickUMod_Click(object sender, EventArgs e)
        {
            List<string> info = ClaseGlobal.servidorPrincipal.obtenerInfoUsuario(txtNickNameUMod.Text);

            if (info.Count != 0) //signifia que si contiene informacioin 
            {
                txtNickNameNuevoUMod.Text = info[0];
                txtNombreUMod.Text = info[1];
                txtPasswordUMod.Text = info[2];
                txtEmailUMod.Text = info[3];
                txtConectadoUMod.Text = info[4];
            }
            else
                lblMensajeUModificado.Text = "El usuario no exite o salio algo mal.";
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnRegresarUMod_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnRergresarPrincipalAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador.aspx");
        }

        protected void btnMostrarArbolEspejo_Click(object sender, EventArgs e)
        {
            ClaseGlobal.servidorPrincipal.generarArbolEspejo();
            mostrarImagen("ABBUsuariosEsp.png");
            MultiView1.ActiveViewIndex = 4;
        }

        protected void btnMostrarTopJuegos_Click(object sender, EventArgs e)
        {
            ClaseGlobal.servidorPrincipal.generarTopJuegos();
            mostrarImagen("topJuegos.png");
            MultiView1.ActiveViewIndex = 4;
        }

        protected void btnMostrarArbolModUsuario_Click(object sender, EventArgs e)
        {
            ClaseGlobal.servidorPrincipal.generarArbol();
            mostrarImagen("ABBUsuarios.png");
            MultiView1.ActiveViewIndex = 4;
        }
        protected void btnMostrarArbolElimUsuaio_Click(object sender, EventArgs e)
        {
            ClaseGlobal.servidorPrincipal.generarArbol();
            mostrarImagen("ABBUsuarios.png");
            MultiView1.ActiveViewIndex = 4;
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

        protected void bntGrafoTablaHash_Click(object sender, EventArgs e)
        {
            try
            {
                ClaseGlobal.servidorPrincipal.insertarHash();
                mostrarImagen("TablaHash.png");
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudo mostrar la Table')", true);
            }
            MultiView1.ActiveViewIndex = 4;
        }

        protected void btnTopMascontactos_Click(object sender, EventArgs e)
        {
            ClaseGlobal.servidorPrincipal.generarTopContactos();
            mostrarImagen("topContactos.png");
            MultiView1.ActiveViewIndex = 4;
        }

        protected void btnTopUniDestuidas_Click(object sender, EventArgs e)
        {

            ClaseGlobal.servidorPrincipal.generarTopUnidDestruida();
            mostrarImagen("topUniDestru.png");
            MultiView1.ActiveViewIndex = 4;
        }



    }
}