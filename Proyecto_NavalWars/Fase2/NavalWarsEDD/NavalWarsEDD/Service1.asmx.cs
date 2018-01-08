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
        public static ArbolAVL avlContactos = new ArbolAVL();
        public static ArbolB arbolB = new ArbolB(5);
        public static TablaHash tablaHash = new TablaHash(43);
        public static Matriz cubo = new Matriz();

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
            g.generarABBUsuario(ref usuarioABB);
        }

        [WebMethod]
        public void generarArbolEspejo()
        {
            g.generarABBEspejo(ref usuarioABB.raiz);
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

        [WebMethod]
        public List<string> obtenerInfoUsuario(string nickname)
        {
            List<string> listaInfo = new List<string>();

            NodoUsuario encontrado = usuarioABB.buscar(nickname);
            if(encontrado !=null)
            {
                listaInfo.Add(encontrado.informacion.nickName);
                listaInfo.Add(encontrado.informacion.nombre);
                listaInfo.Add(encontrado.informacion.password);
                listaInfo.Add(encontrado.informacion.email);
                listaInfo.Add(encontrado.informacion.conectado.ToString());
            }

            return listaInfo;
        }

        [WebMethod]
        public bool modificarUsuario(string nickname,string nuevoNick,string nombre,string password,string email,int conectado)
        {
            return usuarioABB.modificar(nickname, nuevoNick, nombre, password, email, conectado);
        }

        [WebMethod]
        public bool buscarUsuarioNick(string nickname)
        {
            NodoUsuario buscado = usuarioABB.buscar(nickname);

            if (buscado != null)
            {
                return true;
            }
            else
                return false;
        }

        /* -------------------------- Metodos para agregar Juegos a los usuarios --------------------------*/


        [WebMethod]
        public bool addjuegosUsuario(string nickUsuario,string nickOp,int uniDespl, int uniSobrev,int uniDestru,int gano)
        {
            NodoUsuario usuario = usuarioABB.buscar(nickUsuario);
            if (usuario != null)
            {
                Juego nuevoJuego = new Juego(nickOp, uniDespl, uniSobrev, uniDestru, gano);
                usuario.lstJuegos.add(nuevoJuego);
                return true;
            }
            else
                return false;
        }

        [WebMethod]
        public bool eliminarJuegosUsuario(string nickUsuario,string idJuego)
        {
            NodoUsuario usuario = usuarioABB.buscar(nickUsuario);
            
            if (usuario != null)
            {
                bool eliminado = usuario.lstJuegos.eliminar(idJuego);
                if (eliminado)
                    return true;
                else
                    return false;
            }
            else
                return false;
               
        }

        [WebMethod]
        public bool ModificarJuegosUsuario(string nickUsuario,string idJuego,string nickOp,int uniDespla,int uniSobrev,int uniDestru,int gano)
        {
            NodoUsuario usuario = usuarioABB.buscar(nickUsuario);
            if (usuario != null)
            {
                bool modificado = usuario.lstJuegos.modificar(idJuego, nickOp, uniDespla, uniSobrev, uniDestru, gano);
                if (modificado)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        [WebMethod]
        public List<string> obtenerInfoJuegosUsuario(string nickname,string idJuego)
        {
            List<string> listaJuegos = new List<string>();
                NodoUsuario usuario = usuarioABB.buscar(nickname);
            if(usuario!=null)
            {
                NodoJuego juego = usuario.lstJuegos.buscar(idJuego);
                if(juego != null)
                {
                    listaJuegos.Add(juego.valor.nicknameOponente);
                    listaJuegos.Add(juego.valor.unidadesDesplegadas.ToString());
                    listaJuegos.Add(juego.valor.unidadesSobrevivientes.ToString());
                    listaJuegos.Add(juego.valor.unidadesDestruidas.ToString());
                    listaJuegos.Add(juego.valor.gano.ToString());
                }
            }
            return listaJuegos;
        }

        /*--------------------------------- parte de los Tops -------------------------------------*/
        [WebMethod]

        public void generarTopJuegos()
        {
            usuarioABB.generarTopJuegosGanados();
        }

        /*-------------------------------- <AVL>------------------------------------------------------*/
        [WebMethod]
        public void insertarAVL(string nickname, string password, string email)
        {
            avlContactos.insertar(nickname, password, email);
        }
        [WebMethod]
        public void graficarAVL()
        {
            g.generarGrafoAVL(ref avlContactos);
        }
        [WebMethod]
        public void eliminarNodoAVL(string nickname)
        {
            avlContactos.eliminar(nickname);
        }
        [WebMethod]
        public void modificarAVL(string nickname,string nickMod, string password, string email)
        {
            avlContactos.modificar(nickname,nickMod, password, email, ref avlContactos.raiz);
        }

        /*-------------------------------- <Arbol B>------------------------------------------------------*/
        [WebMethod]
        public void insertarArbolB(int coordX,int coordY,string idUnidadAtacante,int resultDanio,string idUnidadAtacada,string idEmisor, string idReceptor,string fecha,string tiempo,int idAtaque)
        {
            HistorialMov nuevo = new HistorialMov(coordX, coordY, idUnidadAtacante, resultDanio, idUnidadAtacada, idEmisor, idReceptor, fecha, tiempo, idAtaque);
            arbolB.insertar(nuevo);
            g.generarGrafoArbolB(ref arbolB.raiz);
        }

        /*-------------------------------- <Arbol B>------------------------------------------------------*/
        [WebMethod]
        public void insertarHash()
        {
            tablaHash.insertarFromABB(ref usuarioABB.raiz);
            g.generarGrafoTablaHash(tablaHash);
        }
        
        [WebMethod]
        public void insertarUnidadMatriz(int fila,string columna,int nivel,int tipoUnidad,string idUnidad)
        {
            Unidad nueva = new Unidad(nivel, tipoUnidad, idUnidad);
            cubo.insertar(fila, columna, ref nueva);
            g.generarMatriz(cubo, 0);
            g.generarMatriz(cubo, 1);
            g.generarMatriz(cubo, 2);
            g.generarMatriz(cubo, 3);
        }
    }
}