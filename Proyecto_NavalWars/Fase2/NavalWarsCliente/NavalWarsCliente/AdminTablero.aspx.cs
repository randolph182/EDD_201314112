using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavalWarsCliente
{
    public partial class AdminTablero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnConfigurarJuego_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> nicknames = ClaseGlobal.servidorPrincipal.obtenerNicknamesUsuarios();

                ddLstNickOp1.Items.Clear();
                ddLstNickOp2.Items.Clear();
                for (int i = 0; i < nicknames.Count; i++)
                {
                    ListItem item = new ListItem(nicknames[i], i.ToString());
                    ddLstNickOp1.Items.Add(item);
                    ddLstNickOp2.Items.Add(item);
                }
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudieron obtener los nicknames de los usuarios \n debe estar vacia las lista de usuairos')", true);

            }
        }

        protected void BtnConfigurar2_Click(object sender, EventArgs e)
        {
            string nickOp1 = ddLstNickOp1.SelectedItem.Text.ToString().Trim();
            string nickOp2 = ddLstNickOp2.SelectedItem.Text.ToString().Trim();
            int navesN0 = Convert.ToInt32(txtNiv0.Text);
            int navesN1 = Convert.ToInt32(txtNiv1.Text);
            int navesN2 = Convert.ToInt32(txtNiv2.Text);
            int navesN3 = Convert.ToInt32(txtNiv3.Text);
            int sizeFilas = Convert.ToInt32(txtTamanioFilas.Text);
            int sizeColumnas = Convert.ToInt32(txtTamanioColumnas.Text);
            int tipoJuego = Convert.ToInt32(txtTipoJuego.Text);
            string tiempo = txtTiempo.Text.Trim();
            int ordenB = Convert.ToInt32(txtOrdenB.Text);

            ClaseGlobal.servidorPrincipal.insertarListaJuegos(nickOp1, nickOp2, navesN0, navesN1, navesN2, navesN3, sizeFilas, sizeColumnas, tipoJuego, tiempo, ordenB);
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrado.aspx");
        }

        protected void btnCargaDatosArbolB_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnSubirArchivoArbolB_Click(object sender, EventArgs e)
        {

        }


    }
}