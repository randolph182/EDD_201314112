using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavalWarsCliente
{
    public partial class ConfiguarcionInicialUsuario : System.Web.UI.Page
    {
        public int MaxFilas = 0;
        public int MaxColumnas = 0;
        public string nickOp1 = "";
        public string nickOp2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIDUsuario.Text = Session["sesion"].ToString();
            configurarParametrosInicial();
        }

        public void configurarParametrosInicial()
        {
            try
            {
                List<string> info =ClaseGlobal.servidorPrincipal.buscarInfoPorOponente(Session["sesion"].ToString());
                if(info.Count !=0)
                {
                    txtCantidadSubmarinos.Text = info[0];
                    txtCantidadUnidadesBarcos.Text = info[1];
                    txtCantidadUnidadesAviones.Text = info[2];
                    txtCantidadUnidadesSatelites.Text = info[3];
                    MaxFilas = Convert.ToInt32(info[4]);
                    MaxColumnas = Convert.ToInt32(info[5]);
                    if(Session["sesion"].ToString() == info[6])
                    {
                        nickOp1 = info[6];
                        nickOp2 = info[7];
                    }
                    else
                    {
                        nickOp1 = info[6];
                        nickOp2 = info[7];
                    }
                    configurarFilasCols();
                        
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void configurarFilasCols()
        {
            if(Session["sesion"].ToString() == nickOp1)
            {
                int posMediaFilas = MaxFilas / 2;
                for (int i = 1; i <= posMediaFilas; i++)
                {
                    ListItem item = new ListItem(i.ToString(), i.ToString());
                    ddLstFilasSubmarinos.Items.Add(item);
                    ddLstFilaBarcos.Items.Add(item);
                    ddLstFilaAviones.Items.Add(item);
                    ddLstFilaSatelites.Items.Add(item);
                }
                int j = 1;
                int col = 65;
                while(MaxColumnas != j)
                {
                    string columna = Convert.ToChar(col).ToString();
                    ListItem item = new ListItem(columna,j.ToString());
                    ddLstColumnaSubmarinos.Items.Add(item);
                    ddLstColumnaBarcos.Items.Add(item);
                    ddLstColumnaAviones.Items.Add(item);
                    ddLstColumnaSatelites.Items.Add(item);
                    col++;
                    j++;
                }
            }
            else
            {
                int posMediaFilas = MaxFilas / 2;
                for (int i = MaxFilas; i >= posMediaFilas; i--)
                {
                    ListItem item = new ListItem(i.ToString(), i.ToString());
                    ddLstFilasSubmarinos.Items.Add(item);
                    ddLstFilaBarcos.Items.Add(item);
                    ddLstFilaAviones.Items.Add(item);
                    ddLstFilaSatelites.Items.Add(item);
                }
                int j = 1;
                int col = 65;
                while (MaxColumnas != j)
                {
                    string columna = Convert.ToChar(col).ToString();
                    ListItem item = new ListItem(columna, j.ToString());
                    ddLstColumnaSubmarinos.Items.Add(item);
                    ddLstColumnaBarcos.Items.Add(item);
                    ddLstColumnaAviones.Items.Add(item);
                    ddLstColumnaSatelites.Items.Add(item);
                    col++;
                    j++;
                }
            }

        }

        protected void btnInsertarSubmarino_Click(object sender, EventArgs e)
        {
          
        }                
         
    }

    
}