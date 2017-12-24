using System;
using System.Collections.Generic;
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
            bool correcto = ClaseGlobal.servidorPrincipal.insertarUsuario(txtNicknameNU.Text, txtNombreNU.Text,txtPasswordNU.Text, txtEmailNU.Text, 0);
            if (correcto)
                lblMensajeAddUsuario.Text = "Se agrego Correctamente. ";
            else
                lblMensajeAddUsuario.Text = "No se pudo Agregar el Nuevo Usuario ";
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnMostrarArbol_Click(object sender, EventArgs e)
        {
            ClaseGlobal.servidorPrincipal.generarArbol();
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
        }




        

    }
}