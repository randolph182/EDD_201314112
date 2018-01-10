using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavalWarsEDD
{
    public class NodoTop
    {
        public NodoTop siguiete;
        public Usuario user; 
        public NodoTop(Usuario user)
        {
            this.user = user;
            this.siguiete = null;
        }
    }
    public class Top
    {
        public NodoTop primero;
        public int size;
        public Top()
        {
            size = 0;
            primero = null;
        }

        public void agregar(Usuario valor)
        {
            NodoTop nuevo = new NodoTop(valor);
            if(primero==null)
            {
                primero = nuevo;
                size++;
            }
            else
            {
                nuevo.siguiete = primero;
                primero = nuevo;
                size++;
            }
        }

        public void ordenarJuegos()
        {
            if(primero !=null)
            {
                Usuario aux;
                NodoTop tmp = primero;
                while(tmp.siguiete !=null)
                {
                    NodoTop tmp2 = tmp.siguiete;
                    while(tmp2 !=null)
                    {
                        if(tmp.user.partidadGanadas < tmp2.user.partidadGanadas)
                        {
                            aux = tmp.user;
                            tmp.user = tmp2.user;
                            tmp2.user = aux;
                        }
                        tmp2 = tmp2.siguiete;
                    }
                    tmp = tmp.siguiete;
                }
            }
        }

        public void ordenarUniDestru()
        {
            if (primero != null)
            {
                Usuario aux;
                NodoTop tmp = primero;
                while (tmp.siguiete != null)
                {
                    NodoTop tmp2 = tmp.siguiete;
                    while (tmp2 != null)
                    {
                        if (tmp.user.ContUnidadesDestruidas < tmp2.user.ContUnidadesDestruidas)
                        {
                            aux = tmp.user;
                            tmp.user = tmp2.user;
                            tmp2.user = aux;
                        }
                        tmp2 = tmp2.siguiete;
                    }
                    tmp = tmp.siguiete;
                }
            }
        }

        public void ordenarContactos()
        {
            if(primero != null)
            {
                Usuario aux;
                NodoTop tmp = primero;
                while(tmp.siguiete != null)
                {
                    NodoTop tmp2 = tmp.siguiete;
                    while(tmp2 != null)
                    {
                        if(tmp.user.NoContactos < tmp2.user.NoContactos)
                        {
                            aux = tmp.user;
                            tmp.user = tmp2.user;
                            tmp2.user = aux;
                        }
                        tmp2 = tmp2.siguiete;
                    }
                    tmp = tmp.siguiete;
                }
            }
        }
    }
}