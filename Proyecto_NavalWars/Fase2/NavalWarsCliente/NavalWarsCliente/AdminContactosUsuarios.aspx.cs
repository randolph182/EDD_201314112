using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavalWarsCliente
{
    public partial class AdminContactosUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnADDContacto_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> nicknames = ClaseGlobal.servidorPrincipal.obtenerNicknamesUsuarios();

                for (int i = 0; i < nicknames.Count; i++)
                {
                    ListItem item = new ListItem(nicknames[i], i.ToString());
                    ddListNickADDContacto.Items.Add(item);
                    ddListLstNickABB.Items.Add(item);
                }
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudieron obtener los nicknames de los usuarios \n debe estar vacia las lista de usuairos')", true);
                                                                           
            }
            //
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nicknameSelect = this.ddListNickADDContacto.SelectedIndex.ToString();
            if(!this.IsPostBack)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('bamos por buen camino')", true);
            }
            MultiView1.ActiveViewIndex = 1;
        }

        protected void ddListLstNickABB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nickname = this.ddListLstNickABB.SelectedIndex.ToString();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnAgregarContacto_1_Click(object sender, EventArgs e)
        {
            string nickUsuario = ddListNickADDContacto.SelectedItem.Text;
            string nickContacto = txtNickNameADDContacto.Text;
            string pass = txtPasswordADDContacto.Text;
            string email = txtEmailADDContacto.Text;
            ClaseGlobal.servidorPrincipal.insertarAVL(nickUsuario, nickContacto, pass, email);
            MultiView1.ActiveViewIndex = 1;

        }

        protected void btnShowAVLADDCont_Click(object sender, EventArgs e)
        {
            try
            {
                ClaseGlobal.servidorPrincipal.graficarAVL(ddListNickADDContacto.SelectedItem.Text);
                mostrarImagen("AVL.png");
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudo mostrar el Arbol')", true);
            }
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

        protected void btnADDContactoSeleccion_Click(object sender, EventArgs e)
        {
            string nickUsuario = ddListNickADDContacto.SelectedItem.Text;
            string nickContacto = ddListLstNickABB.SelectedItem.Text;
            ClaseGlobal.servidorPrincipal.insertarRefAVL(nickUsuario, nickContacto);
        }

        protected void btnBackpricipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador.aspx");
        }

        protected void btnModContacto_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> nicknames = ClaseGlobal.servidorPrincipal.obtenerNicknamesUsuarios();

                for (int i = 0; i < nicknames.Count; i++)
                {
                    ListItem item = new ListItem(nicknames[i], i.ToString());
                    ddLstSelectUsusarioModConctac.Items.Add(item);
                }
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudieron obtener los nicknames de los usuarios \n debe estar vacia las lista de usuairos')", true);

            }
            MultiView1.ActiveViewIndex = 2;
        }

        protected void bntSelectUsuarioModContact_Click(object sender, EventArgs e)
        {

        }


    }
}