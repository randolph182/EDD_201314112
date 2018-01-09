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
            if (txtNicknameLogin.Text != "" && txtPasswordLogin.Text != "")
            {
                if (txtNicknameLogin.Text == "admin" && txtPasswordLogin.Text == "123")
                {
                    Response.Redirect("~/Administrador.aspx");
                }
                else
                {
                    bool encontrado = ClaseGlobal.servidorPrincipal.buscarUsuario(txtNicknameLogin.Text, txtPasswordLogin.Text);
                        if(encontrado)
                        {
                            Session["sesion"] = txtNicknameLogin.Text;
                            Response.Redirect("~/ConfiguarcionInicialUsuario.aspx");
                            lblMensajeLogin.Text = "El usuario si esta";
                        }
                        else
                            lblMensajeLogin.Text = "El usuario no se encontro";
                }
            }
            else
                lblMensajeLogin.Text = "Debe llenar los campos de nickName y Password para poder ingresar";
            




        }
    }
}