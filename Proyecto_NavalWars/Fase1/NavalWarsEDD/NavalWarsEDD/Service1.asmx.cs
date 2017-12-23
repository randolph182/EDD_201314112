using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NavalWarsEDD
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        public static ABBUsuario usuarioABB = new ABBUsuario();
        Grafo g = new Grafo();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void insertarUsuario(string nickname,string nombre,string password,string email,bool conectado)
        {
            Usuario nuevoUsurio = new Usuario(nombre, nickname, password, email, conectado);
            usuarioABB.insertar(ref nuevoUsurio);
        }

        [WebMethod]
        public void generarArbol()
        {
            g.generarABBUsuario(ref usuarioABB.raiz);
        }
    }
}