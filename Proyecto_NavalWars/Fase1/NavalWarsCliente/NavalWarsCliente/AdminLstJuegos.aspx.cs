using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavalWarsCliente
{
    public partial class AdminLstJuegos : System.Web.UI.Page
    {
        static bool  banderaEstausuario = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            banderaEstausuario = false;
        }

        protected void btnBuscarNickAddjuegos_Click(object sender, EventArgs e)
        {
            bool estaUsurio = ClaseGlobal.servidorPrincipal.buscarUsuarioNick(txtNickUsuarioAddJuegos.Text);
            if (estaUsurio)
            {
                lblMnsSearchUserAddjuegos.Text = "El usuario si existe";
                banderaEstausuario = true;
            }
            else
                lblMnsSearchUserAddjuegos.Text = "El Usuario que intenta buscar no existe";
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnAddJuegos_Click(object sender, EventArgs e)
        {
           // if(banderaEstausuario)
           // {
                string nickUsuario = txtNickUsuarioAddJuegos.Text;
                string nickOp = txtNickOponeteAddJuegos.Text;
                int uniDesple = Convert.ToInt16(txtUniDesplegAddJuegos.Text);
                int uniSobrev = Convert.ToInt16(txtUniSobrevAddJuegos.Text);
                int uniDestru = Convert.ToInt16(txtUniDestruAddJuegos.Text);
                int gano  = Convert.ToInt16(txtGanoAddJuegos.Text);

                ClaseGlobal.servidorPrincipal.addjuegosUsuario(nickUsuario, nickOp, uniDesple, uniSobrev, uniDestru, gano);
                lblMnsjAddJugos.Text = "Informacion Agregada al usuario " + nickUsuario;
                //banderaEstausuario = false;
          //  }
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnRegresarAddJuegos_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnAgregarJuegosPrinc_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnBuscarNickModjuegos_Click(object sender, EventArgs e)
        {
            if(txtNickUsuarioModJuegos.Text != "" && txtIdJuegoModJuegos.Text != "")
            {
                bool usuario = ClaseGlobal.servidorPrincipal.buscarUsuarioNick(txtNickUsuarioModJuegos.Text);
                if (usuario)
                {
                    List<string> lstInformacion = ClaseGlobal.servidorPrincipal.obtenerInfoJuegosUsuario(txtNickUsuarioModJuegos.Text, txtIdJuegoModJuegos.Text);
                    if (lstInformacion.Count != 0)
                    {
                        txtNickOponeteModJuegos.Text = lstInformacion[0];
                        txtUniDesplegModJuegos.Text = lstInformacion[1];
                        txtUniSobrevModJuegos.Text = lstInformacion[2];
                        txtUniDestruModJuegos.Text = lstInformacion[3];
                        txtGanoModJuegos.Text = lstInformacion[4];
                    }
                    else
                        lblMnsSearchUserModjuegos.Text = "El usuario: " + txtNickUsuarioModJuegos.Text + " no tinee lista de juegos ";
                }
                else
                    lblMnsSearchUserModjuegos.Text = "El Usuario no Existe";
            }
            else
                lblMnsSearchUserModjuegos.Text = "Debe llenar los dos campos para obtener la informacion";

            MultiView1.ActiveViewIndex = 2;

        }

        protected void btnModJuegos_Click(object sender, EventArgs e)
        {
            string nickUsuario = txtNickUsuarioModJuegos.Text;
            string idJuego = txtIdJuegoModJuegos.Text;
            string nickOp = txtNickOponeteModJuegos.Text;
            int uniDesple = Convert.ToInt16(txtUniDesplegModJuegos.Text);
            int uniSobrev = Convert.ToInt16(txtUniSobrevModJuegos.Text);
            int uniDestru = Convert.ToInt16(txtUniDestruModJuegos.Text);
            int gano = Convert.ToInt16(txtGanoModJuegos.Text);
            bool modificado = ClaseGlobal.servidorPrincipal.ModificarJuegosUsuario(nickUsuario, idJuego, nickOp, uniDesple, uniSobrev, uniDestru, gano);

            if (modificado)
            {
                lblMnsjModJugos.Text = "Se Modificaron los datos para el idJuego: " + txtIdJuegoModJuegos.Text;
            }
            else
                lblMnsjModJugos.Text = "No se pudo modificar la informacion de juegos del id:" + txtIdJuegoModJuegos.Text;
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnRegresarModJuegos_Click(object sender, EventArgs e)
        {

        }

        protected void btnMostrarArbol_Click(object sender, EventArgs e)
        {
            ClaseGlobal.servidorPrincipal.generarArbol();
        }

        protected void btnEliminarJuegosPrinc_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void btnModificarJuegosPrinc_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnRegresarPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            bool juegoEliminado = ClaseGlobal.servidorPrincipal.eliminarJuegosUsuario(txtNickUsuarioEliminar.Text, txtIdJuegoEliminar.Text);
            if(juegoEliminado)
            {
                lblMsjeEliminar.Text = "El juego se elimino Correctamente";
            }
            else
            {
                lblMsjeEliminar.Text = "El juego no se pudo eliminar";
            }
            MultiView1.ActiveViewIndex = 3;
        }
    }
}