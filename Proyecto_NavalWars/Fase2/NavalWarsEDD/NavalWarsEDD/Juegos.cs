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
                nuevoNodo.idNodo = nuevo.GetHashCode().ToString();
            }
            else
            {
                nuevoNodo.siguiente = primero;
                primero.anterior = nuevoNodo;
                primero = nuevoNodo;
                size++;
                nuevoNodo.idNodo = nuevo.GetHashCode().ToString();
            }
        }

        public bool eliminar(string idNodo)
        {
            if(idNodo == primero.idNodo)
            {
                
                primero = primero.siguiente;
                primero.anterior = null;
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
                        tmp.siguiente.anterior = tmpNodo;
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

        public NodoJuego buscar(string idNodo)
        {
            if(primero !=null)
            {
                
                if(primero.idNodo == idNodo)
                {
                    return primero;
                }
                else
                {
                    NodoJuego tmp = primero;
                    while(tmp !=null)
                    {
                        if(tmp.idNodo == idNodo)
                        {
                            return tmp;
                        }
                        tmp = tmp.siguiente;
                    }
                }
            }
                return null;
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

        public string listaJuegos(string idCluster)
        {
            string acum = "";

            if(primero !=null)
            {
                acum += "subgraph cluster" + idCluster + "{\n";
                acum += "label = \" Lista de Juegos \"";
                string acumNodo = "";
                string acumEnlace = "";
                NodoJuego tmp = primero;
                while(tmp.siguiente !=null)
                {
                    acumNodo += tmp.idNodo + "[label=\" idNodo: " + tmp.idNodo + " \n \\n";
                    acumNodo += "Nick Opnente: " + tmp.valor.nicknameOponente + " \n \\n";
                    acumNodo += "Undads Desplegadas: " + tmp.valor.unidadesDesplegadas.ToString() + " \n \\n";
                    acumNodo += "Undads Sobrevivientes: " + tmp.valor.unidadesSobrevivientes.ToString() + " \n \\n";
                    acumNodo += "Undads Destruidas " + tmp.valor.unidadesDestruidas.ToString() + " \n \\n";
                    acumNodo += "Gano: " + tmp.valor.gano.ToString() + "\"];\n";

                    acumEnlace += tmp.idNodo + "->" + tmp.siguiente.idNodo + ";\n ";

                    tmp = tmp.siguiente;
                }

                acumNodo += tmp.idNodo + "[label=\" idNodo: " + tmp.idNodo + " \n \\n";
                acumNodo += "Nick Opnente: " + tmp.valor.nicknameOponente + " \n \\n";
                acumNodo += "Undads Desplegadas: " + tmp.valor.unidadesDesplegadas.ToString() + " \n \\n";
                acumNodo += "Undads Sobrevivientes: " + tmp.valor.unidadesSobrevivientes.ToString() + " \n \\n";
                acumNodo += "Undads Destruidas " + tmp.valor.unidadesDestruidas.ToString() + " \n \\n";
                acumNodo += "Gano: " + tmp.valor.gano.ToString() + "\"];\n";

                while(tmp.anterior !=null)
                {
                    acumEnlace += tmp.idNodo + "->" + tmp.anterior.idNodo + ";\n";
                    tmp = tmp.anterior;
                }

                acum += acumNodo + acumEnlace + "\n}\n";
            }

            return acum;
        }

        public int JuegosGanados()
        {
            int partidas = 0;
            NodoJuego tmp = primero;
            while(tmp !=null)
            {
                if (tmp.valor.gano == 1)
                    partidas++;
                tmp = tmp.siguiente;
            }
            return partidas;
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