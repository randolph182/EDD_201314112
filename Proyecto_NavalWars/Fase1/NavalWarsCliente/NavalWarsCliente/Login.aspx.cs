using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavalWarsCliente
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnIngresarLogin_Click(object sender, EventArgs e)
        {
            if(txtNicknameLogin.Text == "admin" && txtPasswordLogin.Text == "123")
            {
                Response.Redirect("~/Administrador.aspx");
            }


        }
    }
}