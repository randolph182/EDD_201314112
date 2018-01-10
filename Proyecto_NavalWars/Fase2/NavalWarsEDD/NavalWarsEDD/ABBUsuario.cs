using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavalWarsEDD
{
    public class NodoUsuario
    {
        public Usuario informacion;
        public NodoUsuario izquierda;
        public NodoUsuario derecha;
        public Juegos lstJuegos;
        public ArbolAVL lstContactos;
        public int altura; 
        public NodoUsuario()
        {
            lstJuegos = new Juegos();
            lstContactos = new ArbolAVL();
            izquierda = null;
            derecha = null;
            altura = 0;
        }
        public NodoUsuario(ref Usuario info)
        {
            lstJuegos = new Juegos();
            lstContactos = new ArbolAVL();
            this.informacion = info;
            izquierda = null;
            derecha = null;
            altura = 0;
        }
    }
    public class Usuario
    {
        public string nickName;
        public string nombre;
        public string password;
        public string email;
        public int conectado;
        public int partidadGanadas;
        public int unidadesDestruidas;
        public int NoContactos =0;
        public int ContUnidadesDestruidas = 0;

        public Usuario(string nombre, string nickName, string password, string email, int conectado)
        {
            this.nombre = nombre;
            this.nickName = nickName;
            this.password = password;
            this.email = email;
            this.conectado = conectado;
            this.partidadGanadas = 0;
            this.unidadesDestruidas = 0;
        }
    }
    public class ABBUsuario
    {
        public NodoUsuario raiz;
        public int size = 0;
        public ABBUsuario()
        {
            this.raiz = null;
        }
        public bool insertar(ref Usuario valor)
        {
            return insertar(ref raiz, ref valor);
        }
        public bool  insertar(ref NodoUsuario actual,ref Usuario usuario)
        {
            if(actual == null)
            {
                actual = new NodoUsuario(ref usuario);
                size++;
                return true;
            }
            else if(usuario.nickName.CompareTo(actual.informacion.nickName) <0)
            {
                return insertar(ref actual.izquierda, ref usuario);
            }
            else if(usuario.nickName.CompareTo(actual.informacion.nickName)>0)
            {
                return insertar(ref actual.derecha, ref usuario);
            }

            return false;
        }


        public NodoUsuario buscar(string nick)
        {
                return buscar(ref raiz, nick);
        }

        public  NodoUsuario buscar(ref NodoUsuario actual,string  dato)
        {
            if(actual !=null)
            {
                if(actual.informacion.nickName == dato)
                {
                    return actual;
                }
                else if(dato.CompareTo(actual.informacion.nickName) <0)
                {
                    return buscar(ref actual.izquierda, dato);
                }
                else if(dato.CompareTo(actual.informacion.nickName) > 0)
                {
                    return buscar(ref actual.derecha, dato);
                }
            }
            return null;
        }

        public bool eliminar(string dato)
        {
            return eliminar(ref raiz, dato);
        }
        public bool eliminar(ref NodoUsuario actual,string dato)
        {
            if(actual == null)
            {
                return false;
            }
            else if (dato.CompareTo(actual.informacion.nickName) <0)
            {
                return eliminar(ref actual.izquierda, dato);
            }
            else if(dato.CompareTo(actual.informacion.nickName) >0)
            {
                return eliminar(ref actual.derecha, dato);
            }
            else
            {
                /*------------ parte donde se pregunta si el nodo tiene hojas---------------*/
                NodoUsuario  tmp = actual;
                if (tmp.izquierda == null)
                {
                    actual = tmp.derecha;
                    size--;
                    return true;
                }                    
                else if (tmp.derecha == null)
                {
                    actual = tmp.izquierda;
                    size--;
                    return true;
                }   
                /*-------------- termina la parte donde pregunta si era hoja o tenia 1 hijo, por lo tanto si tiene hijos*/ 
                else
                {
                    NodoUsuario tmp2 = tmp.izquierda;
                    while(tmp2.derecha != null)
                    {
                        tmp = tmp2;
                        tmp2 = tmp2.derecha;
                    }
                    actual.informacion = tmp2.informacion;
                    if (tmp == actual)
                        tmp.izquierda = tmp2.izquierda;
                    else
                        tmp.derecha = tmp2.izquierda;

                    size--;
                    return true;
                }
            }
        }

        public bool modificar(string nickName,string nickNuevo, string nombre, string password, string email, int conectado)
        {
            NodoUsuario encontrado = buscar(nickName);
            if(nickNuevo != "")
            {
                if (encontrado != null)
                {
                    bool eliminado = eliminar(nickName);
                    if (eliminado)
                    {
                        Usuario act = new Usuario(nombre, nickNuevo, password, email, conectado);
                        insertar(ref act);
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;

            }
            else
            {
                encontrado.informacion.nombre = nombre;
                encontrado.informacion.password = password;
                encontrado.informacion.email = email;
                encontrado.informacion.conectado = conectado;
                return true;
            }
        }


        public int nivelArbol(NodoUsuario actual)
        {
            int izq = 0;
                int der =0;
            if(actual.izquierda == null && actual.derecha ==null) //comprbando si es un nodo hoja
            {
                return 1;
            }
            else
            {
                if(actual.izquierda !=null)
                {
                    izq = nivelArbol(actual.izquierda);
                }
                if( actual.derecha != null)
                {
                   
                    der = nivelArbol(actual.derecha);
                }

                if (izq < der)
                    return der + 1;
                else
                    return izq + 1;
            }
        }


        public void getNickUsuarios(NodoUsuario actual,ref List<string> nick)
        {
            if(actual != null)
            {
                nick.Add(actual.informacion.nickName);
                getNickUsuarios(actual.izquierda, ref nick);
                getNickUsuarios(actual.derecha, ref nick);
            }
        }

        public void generarTopJuegosGanados()
        {
            if(raiz !=null)
            {
                Top newTop = new Top();
                recorrerPreordenTopJuegos(ref raiz, ref newTop);
                newTop.ordenarJuegos();
                Grafo g = new Grafo();
                g.generarTopJuegos(newTop);
            }
        }
        public void generartopMasContactos()
        {
            if(raiz != null)
            {
                Top newTop = new Top();
                recorrerTopContactos(raiz,ref newTop);
                newTop.ordenarContactos();
                Grafo g = new Grafo();
                g.generarTopContactos(newTop);
            }
        }

        public void generartopUnidadesDestruidas()
        {
            if (raiz != null)
            {
                Top newTop = new Top();
                
                recorrerUnidadesDestruidas(ref raiz, ref newTop);
                newTop.ordenarUniDestru();
                Grafo g = new Grafo();
                g.generarTopUniDestru(newTop);
            }
        }

        public void recorrerTopContactos(NodoUsuario actual,ref Top top)
        {
            if(actual != null)
            {
                if(actual.lstContactos.raiz != null)
                {
                    int noContactos =0;
                    actual.lstContactos.contadorContactos(ref noContactos);
                    actual.informacion.NoContactos = noContactos;
                    top.agregar(actual.informacion);
                }
                recorrerTopContactos( actual.izquierda,ref  top);
                recorrerTopContactos( actual.derecha,ref  top);
            }
        }

        public void recorrerPreordenTopJuegos(ref NodoUsuario actual, ref Top top)
        {
            if(actual != null)
            {
                if(actual.lstJuegos.primero!=null)
                {
                    int partidas = actual.lstJuegos.JuegosGanados();
                    actual.informacion.partidadGanadas = partidas;
                    top.agregar(actual.informacion);
                }
                recorrerPreordenTopJuegos( ref actual.izquierda,ref top);
                recorrerPreordenTopJuegos( ref actual.derecha, ref top);
            }
        }

        public void recorrerUnidadesDestruidas(ref NodoUsuario actual, ref Top top)
        {
            if (actual != null)
            {
                if (actual.lstJuegos.primero != null)
                {
                    int partidas = actual.lstJuegos.unidadesDestruidas();
                    actual.informacion.ContUnidadesDestruidas = partidas;
                    top.agregar(actual.informacion);
                }
                recorrerUnidadesDestruidas(ref actual.izquierda, ref top);
                recorrerUnidadesDestruidas(ref actual.derecha, ref top);
            }
        }

    }
}