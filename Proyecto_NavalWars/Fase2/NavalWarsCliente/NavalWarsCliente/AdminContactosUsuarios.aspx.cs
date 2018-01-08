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

                ddListNickADDContacto.Items.Clear();
                ddListLstNickABB.Items.Clear();
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
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nicknameSelect = this.ddListNickADDContacto.SelectedIndex.ToString();
            if (!this.IsPostBack)
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
                ddLstSelectUsusarioModConctac.Items.Clear();
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
            try
            {
                string nickUsuario = ddLstSelectUsusarioModConctac.SelectedItem.Text;
                List<string> contactos = ClaseGlobal.servidorPrincipal.getListaContactosUsuario(nickUsuario);
                for (int i = 0; i < contactos.Count; i++)
                {
                    ListItem item = new ListItem(contactos[i], i.ToString());
                    ddLstSelectContactModConcta.Items.Add(item);
                }
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudo obtener los contactos')", true);
            }
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnSelectConctacoModContact_Click(object sender, EventArgs e)
        {
            string nickUsuario = ddLstSelectUsusarioModConctac.SelectedItem.Text;
            string nickContacto = ddLstSelectContactModConcta.SelectedItem.Text;
            List<string> infoContacto = ClaseGlobal.servidorPrincipal.getInfoContacto(nickUsuario, nickContacto);
            if (infoContacto.Count > 0)
            {
                txtNickContactoModContact.Text = infoContacto[0];
                txtPassModContac.Text = infoContacto[1];
                txtEmailModContact.Text = infoContacto[2];
            }
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnModContacto_2_Click(object sender, EventArgs e)
        {
            string nickUsuario = ddLstSelectUsusarioModConctac.SelectedItem.Text;
            string nickContacto = ddLstSelectContactModConcta.SelectedItem.Text;
            string nickAModContacto = txtNickModModContact.Text;
            string passContacto = txtPassModContac.Text;
            string emailContacto = txtEmailModContact.Text;
            bool modifico = ClaseGlobal.servidorPrincipal.modificarAVL(nickUsuario, nickContacto, nickAModContacto, passContacto, emailContacto);
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnDelContacto_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> nicknames = ClaseGlobal.servidorPrincipal.obtenerNicknamesUsuarios();
                ddLstUsuarioElim.Items.Clear();
                for (int i = 0; i < nicknames.Count; i++)
                {
                    ListItem item = new ListItem(nicknames[i], i.ToString());
                    ddLstUsuarioElim.Items.Add(item);
                }
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudieron obtener los nicknames de los usuarios \n debe estar vacia las lista de usuairos')", true);

            }
            MultiView1.ActiveViewIndex = 3;
        }

        protected void btnnickUsuarioElim_Click(object sender, EventArgs e)
        {
            try
            {
                string nickUsuario = ddLstUsuarioElim.SelectedItem.Text;
                List<string> contactos = ClaseGlobal.servidorPrincipal.getListaContactosUsuario(nickUsuario);
                for (int i = 0; i < contactos.Count; i++)
                {
                    ListItem item = new ListItem(contactos[i], i.ToString());
                    ddLstContactoElim.Items.Add(item);
                }
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudo obtener los contactos')", true);
            }
            MultiView1.ActiveViewIndex = 3;
        }

        protected void btnContactoElim_Click(object sender, EventArgs e)
        {
            string nickUsuario = ddLstUsuarioElim.SelectedItem.Text;
            string nickContacto = ddLstContactoElim.SelectedItem.Text;
            try
            {
                bool eliminado = ClaseGlobal.servidorPrincipal.eliminarNodoAVL(nickUsuario, nickContacto);
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('Hubo problemas con Eliminar ')", true);
            }

            
          //  if (eliminado)
          //      lblElimiado.Text = "Se elimino correctamente";
          //  else
           //     lblElimiado.Text = "Hubo problemas con la eliminacion del contacto";
            MultiView1.ActiveViewIndex = 3;       
        }

        protected void btnMostrarGrafoElim_Click(object sender, EventArgs e)
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                ClaseGlobal.servidorPrincipal.graficarAVL(ddLstUsuariosMostrarGrafo.SelectedItem.Text);
                string path = "C:/GrafoEDD/AVL.png";
                byte[] imageByteData = System.IO.File.ReadAllBytes(path);
                string imageBase64Data = Convert.ToBase64String(imageByteData);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                Image2.ImageUrl = imageDataURL;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudo mostrar el Arbol')", true);
            }
            MultiView1.ActiveViewIndex = 5;

        }


        protected void btnMostrarAVLContacto_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> nicknames = ClaseGlobal.servidorPrincipal.obtenerNicknamesUsuarios();
                ddLstUsuariosMostrarGrafo.Items.Clear();
                for (int i = 0; i < nicknames.Count; i++)
                {
                    ListItem item = new ListItem(nicknames[i], i.ToString());
                    ddLstUsuariosMostrarGrafo.Items.Add(item);
                }
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudieron obtener los nicknames de los usuarios \n debe estar vacia las lista de usuairos')", true);

            }
            MultiView1.ActiveViewIndex = 5;
        }





    }
}