using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavalWarsCliente
{
    public partial class _Default : System.Web.UI.Page
    {
        ServiceReference1.Service1SoapClient servidor;
        protected void Page_Load(object sender, EventArgs e)
        {
            servidor = new ServiceReference1.Service1SoapClient();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            servidor.insertarUsuario(txtNickname.Text, txtNombre.Text, txtPassword.Text, txtEmail.Text, true);
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            servidor.generarArbol();
        }


    }
}