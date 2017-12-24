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
        public NodoUsuario()
        {
            izquierda = null;
            derecha = null;
        }
        public NodoUsuario(ref Usuario info)
        {
            this.informacion = info;
            izquierda = null;
            derecha = null;
        }
    }
    public class Usuario
    {
        public string nickName;
        public string nombre;
        public string password;
        public string email;
        public int conectado;
        public Usuario(string nombre, string nickName, string password, string email, int conectado)
        {
            this.nombre = nombre;
            this.nickName = nickName;
            this.password = password;
            this.email = email;
            this.conectado = conectado;
        }
    }
    public class ABBUsuario
    {
        public NodoUsuario raiz;
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
                    return true;
                }                    
                else if (tmp.derecha == null)
                {
                    actual = tmp.izquierda;
                    return true;
                }   
                /*-------------- termina la parte donde pregunta si era hoja o tenia 1 hijo, por lo tanto si tiene hijos*/ 
                else
                {
                    //NodoUsuario tmp2,tmp3;
                    //tmp2 = tmp;
                    //tmp3 = tmp.izquierda;
                    //while(tmp3.derecha !=null)
                    //{
                    //    tmp2 = tmp3;
                    //    tmp3 = tmp3.derecha;
                    //}
                    //tmp.informacion = tmp3.informacion;
                    //if (tmp2 == tmp)
                    //    tmp2.izquierda = tmp3.izquierda;
                    //else
                    //    tmp2.derecha = tmp2.izquierda;
                    //tmp = tmp3;
                    NodoUsuario tmp2 = tmp.izquierda;
                    while(tmp2.derecha != null)
                    {
                        tmp = tmp2;
                        tmp2 = tmp2.izquierda;
                    }
                    actual.informacion = tmp2.informacion;
                    if (tmp == actual)
                        tmp.izquierda = tmp2.izquierda;
                    else
                        tmp.derecha = tmp2.izquierda;

                    return true;

                }


            }
        }

    }
}