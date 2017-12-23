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
        public bool conectado;
        public Usuario(string nombre, string nickName, string password, string email, bool conectado)
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
        public void insertar(ref Usuario valor)
        {
            insertar(ref raiz, ref valor);
        }
        void insertar(ref NodoUsuario actual,ref Usuario usuario)
        {
            if(actual == null)
            {
                actual = new NodoUsuario(ref usuario);
            }
            else if(usuario.nickName.CompareTo(actual.informacion.nickName) <0)
            {
                insertar(ref actual.izquierda, ref usuario);
            }
            else if(usuario.nickName.CompareTo(actual.informacion.nickName)>0)
            {
                insertar(ref actual.derecha, ref usuario);
            }
        }

    }
}