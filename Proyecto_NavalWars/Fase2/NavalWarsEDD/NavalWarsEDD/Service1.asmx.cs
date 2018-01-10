using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public static Dictionary<string, Matriz> matricesTemporales = new Dictionary<string, Matriz>();
        public static ABBUsuario usuarioABB = new ABBUsuario();
       // public static ArbolAVL avlContactos = new ArbolAVL();
      //  public static ArbolB arbolB = new ArbolB(5);
        
       // public static Matriz cubo = new Matriz();
        public static Matriz cuboTmp = new Matriz();
        public static ListaMatriz listaJuegos = new ListaMatriz();

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
        public List<string> obtenerNicknamesUsuarios()
        {
            List<string> listaNick = new List<string>();
            usuarioABB.getNickUsuarios(usuarioABB.raiz, ref listaNick);
            return listaNick;
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
        [WebMethod]
        public void generarTopContactos()
        {
            usuarioABB.generartopMasContactos();
        }

        [WebMethod]
        public void generarTopUnidDestruida()
        {
            usuarioABB.generartopUnidadesDestruidas();
        }

        /*-------------------------------- <AVL>------------------------------------------------------*/
        [WebMethod]
        public void insertarAVL(string nickUsuario,string nickname, string password, string email)
        {
          //  avlContactos.insertar(nickname, password, email);
            NodoUsuario nUsuario = usuarioABB.buscar(nickUsuario);
            if(nUsuario != null)
            {
                nUsuario.lstContactos.insertar(nickname, password, email);
            }
            //usuarioABB
        }
        [WebMethod]
        public void insertarRefAVL(string nickUsuario,string nickContacto)
        {
            NodoUsuario usuario = usuarioABB.buscar(nickUsuario);
            NodoUsuario usuarioContacto = usuarioABB.buscar(nickContacto);
            if(usuario!=null && usuarioContacto != null)
            {
                usuario.lstContactos.insertarRef(ref usuarioContacto);
            }
        }
        [WebMethod]
        public void graficarAVL(string nickUsuario)
        {
            NodoUsuario usuario = usuarioABB.buscar(nickUsuario);
            if(usuario != null)
            {
                g.generarGrafoAVL(ref usuario.lstContactos);
            }
            
        }
        [WebMethod]
        public bool eliminarNodoAVL(string nickUsuario, string nickContacto)
        {
            NodoUsuario usuario = usuarioABB.buscar(nickUsuario);
            if(usuario!=null)
            {
                bool eliminado =usuario.lstContactos.eliminar(nickContacto);
                if (eliminado)
                    return true;
            }
            return false;
         //   avlContactos.eliminar(nickname);
        }
        [WebMethod]
        public bool modificarAVL(string nickUsuario,string nickContacto,string nickMod, string password, string email)
        {
            NodoUsuario usuario = usuarioABB.buscar(nickUsuario);
            if(usuario != null)
            {
                bool modificado = usuario.lstContactos.modificar(nickContacto, nickMod, password, email,ref  usuario.lstContactos.raiz);
                if(modificado)
                    return true;
            }
            return false;
          //  avlContactos.modificar(nickname,nickMod, password, email, ref avlContactos.raiz);
        }
        [WebMethod]
        public List<string> getListaContactosUsuario(string nickUsuario)
        {
            NodoUsuario usuario = usuarioABB.buscar(nickUsuario);
            List<string> listaContactos = new List<string>();
            if(usuario!=null)
            {
                usuario.lstContactos.getNickContacto(usuario.lstContactos.raiz, ref listaContactos);
            }
            return listaContactos;
        }

        [WebMethod]
        public List<string> getInfoContacto(string nickUsuario,string nickContacto)
        {
            List<string> infoContacto = new List<string>();
            NodoUsuario usuario = usuarioABB.buscar(nickUsuario);
            if(usuario !=null)
            {
                NodoAVL contacto = usuario.lstContactos.getContacto(usuario.lstContactos.raiz, nickContacto);
                if(contacto != null)
                {

                    if(contacto.referenciaUsurio != null)
                    {
                        infoContacto.Add(contacto.referenciaUsurio.informacion.nickName);
                        infoContacto.Add(contacto.referenciaUsurio.informacion.password);
                        infoContacto.Add(contacto.referenciaUsurio.informacion.email);
                    }
                    else
                    {
                        infoContacto.Add(contacto.nickname);
                        infoContacto.Add(contacto.password);
                        infoContacto.Add(contacto.email);
                    }
                }
            }
            return infoContacto;
        }

        /*-------------------------------- <Arbol B>------------------------------------------------------*/
        [WebMethod]
        public void insertarArbolB(int coordX,int coordY,string idUnidadAtacante,int resultDanio,string idUnidadAtacada,string idEmisor, string idReceptor,string fecha,string tiempo,int idAtaque)
        {
            NodoMatriz  cubo = listaJuegos.buscar(idEmisor, idReceptor);
            if(cubo != null)
            {
                HistorialMov nuevo = new HistorialMov(coordX, coordY, idUnidadAtacante, resultDanio, idUnidadAtacada, idEmisor, idReceptor, fecha, tiempo, idAtaque);
                cubo.historial.insertar(nuevo);
            }

            
            //arbolB.insertar(nuevo);
            //g.generarGrafoArbolB(ref arbolB.raiz);
            
        }

        [WebMethod]
        public void graficarArbolB(string nickOp1,string nickOp2)
        {
            NodoMatriz cubo = listaJuegos.buscar(nickOp1,nickOp2);
            if(cubo!= null)
            {
                g.generarGrafoArbolB(ref cubo.historial.raiz);
            }
            
        }

        /*-------------------------------- <Tabla hash>------------------------------------------------------*/
        [WebMethod]
        public void insertarHash()
        {
              TablaHash tablaHash = new TablaHash(43);
            tablaHash.insertarFromABB(ref usuarioABB.raiz);
            g.generarGrafoTablaHash(tablaHash);
        }
        /*-------------------------------- <Matriz>------------------------------------------------------*/
        [WebMethod]
        public void insertarListaJuegos(string nickOp1,string nickOp2,int n0,int n1,int n2, int n3,int noFilas,int noCols,int tipoJuego,string tiempo,int ordenB)
        {
            //listaJuegos.insertar(nickOp1, nickOp2, n0, n1, n2, n3, tipoJuego, tiempo, ordenB);
            listaJuegos.insertar(nickOp1, nickOp2, n0, n1, n2, n3,noFilas,noCols, tipoJuego, tiempo, ordenB);
        }
        [WebMethod]
        public List<string> buscarInfoPorOponente(string nickname)
        {
            NodoMatriz juegoActual = listaJuegos.buscarPorOponente(nickname);
            List<string> parametrosJuego = new List<string>();
            if(juegoActual != null)
            {
                parametrosJuego.Add(juegoActual.No_Naves_Nivel0.ToString());
                parametrosJuego.Add(juegoActual.No_Naves_Nivel1.ToString());
                parametrosJuego.Add(juegoActual.No_Naves_Nivel2.ToString());
                parametrosJuego.Add(juegoActual.No_Naves_Nivel3.ToString());
                parametrosJuego.Add(juegoActual.No_Filas.ToString());
                parametrosJuego.Add(juegoActual.No_Columnas.ToString());
                parametrosJuego.Add(juegoActual.nickOponente1);
                parametrosJuego.Add(juegoActual.nickOponente2);
            }
            return parametrosJuego;
        }


        [WebMethod]
        public void insertarCuboTmp(string nickJugador,int fila, string columna,string idUnidad,int nivel,int tipoUnidad,int destruida)
        {
            int col = Encoding.ASCII.GetBytes(columna)[0]; 
            Unidad nueva = new Unidad(nivel, tipoUnidad, idUnidad);
            nueva.fila = fila;
            nueva.columna = col;
            nueva.destruida = destruida;
            cuboTmp.insertar(fila, columna, ref nueva);
        }
        [WebMethod]
        public void insertarTableroPrincipa(string nickUsu,string nickOp,int fila,string columna,int nivel,int tipoUnidad,int NoUnidad)
        {
            NodoMatriz tableroPrincipal = listaJuegos.buscar(nickUsu, nickOp);
            if (tableroPrincipal != null)
            {
                int col = Encoding.ASCII.GetBytes(columna)[0]; 
                Unidad nueva = new Unidad(nivel, tipoUnidad, "");
                nueva.fila = fila;
                nueva.columna = col;
                nueva.idUsurio = nickUsu;
                nueva.idUnidad += NoUnidad.ToString();
                tableroPrincipal.tablero.insertar(fila, columna, ref nueva);
            }
        }

        [WebMethod]
        public void graficarMatriz(string nickOp1, string nickOp2)
        {
            NodoMatriz tablero = listaJuegos.buscar(nickOp1, nickOp2);

            if(tablero !=null)
            {
                g.generarMatriz(tablero.tablero, 0);
                g.generarMatriz(tablero.tablero, 1);
                g.generarMatriz(tablero.tablero, 2);
                g.generarMatriz(tablero.tablero, 3);
            }
            
        }
        [WebMethod]
        public void graficarMatrizPerNivel(int nivel)
        {
            g.generarMatriz(cuboTmp, nivel);
        }
        [WebMethod]
        public void graficarMatrizPerUnidadDetuida(int nivel, int destruida)
        {
            g.generarMatrizUnidadDestruida(cuboTmp, nivel, destruida);
        }
    }
}