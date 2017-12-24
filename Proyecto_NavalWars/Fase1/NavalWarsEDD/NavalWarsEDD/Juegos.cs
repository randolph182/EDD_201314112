using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavalWarsEDD
{
    public class NodoJuego
    {
        public NodoJuego siguiente;
        public NodoJuego anterior;
        public Juego valor;
        public string idNodo;
        public NodoJuego(Juego valor)
        {
            this.valor = valor;
            idNodo = "";
            siguiente = null;
            anterior = null;
        }
    }

    public class Juegos
    {
        public NodoJuego primero;
        public  int size;
        public int cont;
        public Juegos()
        {
            primero = null;
            size = 0;
            cont = 0;
        }

        public void add(Juego nuevo)
        {
            NodoJuego nuevoNodo = new NodoJuego(nuevo);
            if(primero ==null)
            {
                primero = nuevoNodo;
                size++;
            }
            else
            {
                nuevoNodo.siguiente = primero;
                primero.anterior = nuevoNodo;
                primero = nuevoNodo;
                size++;
            }
        }

        public bool eliminar(string idNodo)
        {
            if(idNodo == primero.idNodo)
            {
                primero.anterior = null;
                primero = primero.siguiente;
                size--;
                return true;
            }
            else
            {
                NodoJuego tmp = primero;

                while(tmp.siguiente !=null)
                {
                    if(tmp.idNodo == idNodo)
                    {
                        NodoJuego tmpNodo = tmp.anterior;
                        tmpNodo.siguiente = tmp.siguiente;
                        tmp.anterior = tmpNodo;
                        size--;
                        return true;
                    }
                    tmp = tmp.siguiente;
                }

                if(tmp.siguiente == null)
                {
                    if(tmp.idNodo == idNodo)
                    {
                        NodoJuego tmpNodo = tmp.anterior;
                        tmpNodo.siguiente = null;
                        tmp.anterior = null;
                        size--;
                        return true;
                    }
                }

                return false;
            }
        }

        public bool modificar(string idNodo,string nicknameOp,int uniDesplegadas,int uniSobrevivientes,int uniDestruidas,int gano)
        {

            if (idNodo == primero.idNodo)
            {
                primero.valor.nicknameOponente = nicknameOp;
                primero.valor.unidadesDesplegadas = uniDesplegadas;
                primero.valor.unidadesSobrevivientes = uniSobrevivientes;
                primero.valor.unidadesDestruidas = uniDestruidas;
                primero.valor.gano = gano;
                return true;
            }
            else
            {
                NodoJuego tmp = primero;

                while (tmp != null)
                {
                    if (tmp.idNodo == idNodo)
                    {
                        tmp.valor.nicknameOponente = nicknameOp;
                        tmp.valor.unidadesDesplegadas = uniDesplegadas;
                        tmp.valor.unidadesSobrevivientes = uniSobrevivientes;
                        tmp.valor.unidadesDestruidas = uniDestruidas;
                        tmp.valor.gano = gano;
                        return true;
                    }
                    tmp = tmp.siguiente;
                }

                return false;
            }
        }


    }

    public class Juego
    {
        public string nicknameOponente;
        public int unidadesDesplegadas;
        public int unidadesSobrevivientes;
        public int unidadesDestruidas;
        public int gano;

        public Juego(string nickOponete,int uniDesplegadas,int uniSobrev,int uniDestru,int gano)
        {
            this.nicknameOponente = nickOponete;
            this.unidadesDesplegadas = uniDesplegadas;
            this.unidadesSobrevivientes = uniSobrev;
            this.unidadesDestruidas = uniDestru;
            this.gano = gano;
        }
       
    }

}