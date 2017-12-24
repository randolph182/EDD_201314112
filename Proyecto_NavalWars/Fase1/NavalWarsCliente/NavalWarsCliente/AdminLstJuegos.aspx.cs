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
            if(banderaEstausuario)
            {
                string nickUsuario = txtNickUsuarioAddJuegos.Text;
                string nickOp = txtNickOponeteAddJuegos.Text;
                int uniDesple = Convert.ToInt16(txtUniDesplegAddJuegos.Text);
                int uniSobrev = Convert.ToInt16(txtUniSobrevAddJuegos.Text);
                int uniDestru = Convert.ToInt16(txtUniDestruAddJuegos.Text);
                int gano  = Convert.ToInt16(txtGanoAddJuegos.Text);

                ClaseGlobal.servidorPrincipal.addjuegosUsuario(nickUsuario, nickOp, uniDesple, uniSobrev, uniDestru, gano);
                lblMnsjAddJugos.Text = "Informacion Agregada al usuario " + nickUsuario; 
            }
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

        }

        protected void btnModJuegos_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresarModJuegos_Click(object sender, EventArgs e)
        {

        }
    }
}