using System;
using System.Collections.Generic;
using System.IO;
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
            if(!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            
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
                    
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudieron obtener los nicknames de los usuarios \n debe estar vacia las lista de usuairos')", true);

                }
            MultiView1.ActiveViewIndex = 1;
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
            Response.Redirect("~/Administrador.aspx");
        }

        protected void btnCargaDatosArbolB_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnSubirArchivoArbolB_Click(object sender, EventArgs e)
        {
            string direccion = Server.MapPath(FileUpload1.FileName);

            if (direccion != "")
            {
                int contador = 0;
                string linea;
                using (StreamReader sr = File.OpenText(direccion))
                {
                    //linea  = sr.ReadLine();
                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (contador != 0)
                        {
                            string[] info = linea.Split(',');
                            int cordX = Convert.ToInt32(info[0]);
                            int cordY = Convert.ToInt32(info[1]);
                            string uniAtacante = info[2];
                            int golpe = Convert.ToInt32(info[3]);
                            string uniAtacada = info[4].Trim();
                            string emisor = info[5].Trim();
                            string receptor = info[6].Trim();
                            string fecha = info[7].Trim();
                            string tiempo = info[8].Trim();
                            int numeroAtaque = Convert.ToInt32(info[9]);
                            ClaseGlobal.servidorPrincipal.insertarArbolB(cordX, cordY, uniAtacante, golpe, uniAtacada, emisor, receptor, fecha, tiempo, numeroAtaque);
                            
                        }
                        contador++;
                    }
                    sr.Close();
                }

            }
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnBack3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void MostrarArbolB_Click(object sender, EventArgs e)
        {

                try
                {
                    List<string> nicknames = ClaseGlobal.servidorPrincipal.obtenerNicknamesUsuarios();

                    ddLstGrafoOp1.Items.Clear();
                    ddLstGrafoOp2.Items.Clear();
                    for (int i = 0; i < nicknames.Count; i++)
                    {
                        ListItem item = new ListItem(nicknames[i], i.ToString());
                        ddLstGrafoOp1.Items.Add(item);
                        ddLstGrafoOp2.Items.Add(item);
                    }
                   
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudieron obtener los nicknames de los usuarios \n debe estar vacia las lista de usuairos')", true);

                }
   
            MultiView1.ActiveViewIndex = 3;

        }

        protected void btnBack4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnGraficarB_Click(object sender, EventArgs e)
        {
            try
            {
                string op1 = ddLstGrafoOp1.SelectedItem.Text;
                string op2 = ddLstGrafoOp2.SelectedItem.Text;
                ClaseGlobal.servidorPrincipal.graficarArbolB(op1, op2);
                string path = "C:/GrafoEDD/ArbolB.png";
                byte[] imageByteData = System.IO.File.ReadAllBytes(path);
                string imageBase64Data = Convert.ToBase64String(imageByteData);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                Image1.ImageUrl = imageDataURL;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('No se pudo mostrar el Arbol')", true);
            }

            MultiView1.ActiveViewIndex = 3;
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {

            MultiView1.ActiveViewIndex = 0;
        }


    }
}