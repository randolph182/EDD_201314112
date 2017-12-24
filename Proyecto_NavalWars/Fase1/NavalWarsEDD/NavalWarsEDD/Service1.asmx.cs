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
        public bool insertarUsuario(string nickname,string nombre,string password,string email,int conectado)
        {
            Usuario nuevoUsurio = new Usuario(nombre, nickname, password, email, conectado);
            return usuarioABB.insertar(ref nuevoUsurio);
        }

        [WebMethod]
        public void generarArbol()
        {
            g.generarABBUsuario(ref usuarioABB.raiz);
        }

        [WebMethod]
        public bool buscarUsuario(string nickname,string password)
        {
            NodoUsuario buscado =  usuarioABB.buscar(nickname);

            if(buscado !=null)
            {
                if(buscado.informacion.nickName == nickname && buscado.informacion.password == password)
                {
                    return true;
                }
                return false;
            }else
                return false;
        }
        [WebMethod]
        public bool eliminarUsuario(string nickname)
        {
            return usuarioABB.eliminar(nickname);
        }
    }
}