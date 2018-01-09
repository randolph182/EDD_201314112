using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavalWarsEDD
{
    public class NodoMatriz
    {
        public NodoMatriz siguiente;
        public string nickOponente1;
        public string nickOponente2;
        public int No_Naves_Nivel0;
        public int No_Naves_Nivel1;
        public int No_Naves_Nivel2;
        public int No_Naves_Nivel3;
        public int tipoJuego;
        public string tiempo;
        public Matriz tablero;

        public NodoMatriz(string op1, string op2,int n0, int n1,int n2,int n3,int tJuego,string tiempo)
        {
            tablero = new Matriz();
            this.nickOponente1 = op1;
            this.nickOponente2 = op2;
            this.No_Naves_Nivel0 = n0;
            this.No_Naves_Nivel1 = n1;
            this.No_Naves_Nivel2 = n2;
            this.No_Naves_Nivel3 = n3;
            this.tipoJuego = tJuego;
            this.tiempo = tiempo;
        }

    }
    public class ListaMatriz
    {
        public NodoMatriz primero;
        int size;
        public ListaMatriz()
        {
            this.primero = null;
            this.size = 0;
        }

        public void insertar(string op1, string op2,int n0, int n1,int n2,int n3,int tJuego,string tiempo)
        {
            NodoMatriz nuevo = new NodoMatriz(op1, op2, n0, n1, n2, n3, tJuego, tiempo);
            if(primero == null)
            {
                primero = nuevo;
            }
            else
            {
                nuevo.siguiente = primero;
                primero = nuevo;
            }
        }

        public NodoMatriz buscar(string op1,string op2)
        {
            NodoMatriz tmp = primero;
            if(tmp!=null)
            {
                while(primero!=null)
                {
                    if(tmp.nickOponente1 == op1 && tmp.nickOponente2 ==op2)
                        return tmp;
                    primero = primero.siguiente;
                }
            }
            return null;
        }
    }
}