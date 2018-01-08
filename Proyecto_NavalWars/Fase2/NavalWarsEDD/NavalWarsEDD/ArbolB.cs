using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavalWarsEDD
{
    public class Pagina
    {
        public HistorialMov [] claves;
        public Pagina [] ramas;
        public int cuenta;
        public int m;
        public Pagina(int orden)
        {
            this.m = orden;
            this.claves = new HistorialMov[orden];
            this.ramas = new Pagina[orden];
            //llenamos las paginas
            for (int i = 0; i < orden; i++)
                ramas[i] = null;
        }
        public bool paginaLlena( Pagina actual)
        {
            if (actual.cuenta == m - 1)
                return true;
            else
                return false;
        }
        public bool paginaSemiLlena(Pagina actual)
        {
            if (actual.cuenta < m / 2)
                return true;
            else
                return false;
        }

    }
    public class ArbolB
    {
        public int orden;
        public Pagina raiz;
        public ArbolB(int orden)
        {
            this.orden = orden;
            this.raiz = null;
        }
        public HistorialMov buscarClave(int idMov)
        {
            HistorialMov tmp = null;
            buscarClave( raiz, ref tmp, idMov);
            return tmp;
        }
        public void buscarClave(Pagina actual,ref HistorialMov info,int id)
        {
            if (actual != null)
            {
                for (int i = 1; i <= actual.cuenta; i++)
                {
                    if (actual.claves[i].idAtaque == id)
                    {
                        info = actual.claves[i];
                        return;
                    }
                    else if (id < actual.claves[i].idAtaque)
                        buscarClave( actual.ramas[i-1], ref info, id); // el ramas[i-1] bajo por las ramas izq una anterior
                    else if (id > actual.claves[i].idAtaque)
                        buscarClave( actual.ramas[i], ref info, id); //busco en la rama[i] que seria la actual pero seria de lado derecho
                    else
                        info = null;
                }
            }
            else
                info = null;
        }

        public bool buscarPagina( Pagina actual,  HistorialMov hm, ref int k)
        {
            /* tomar en cuenta que k es la direccion de las ramas por las cuales baja la busqueda*/
            bool encontrado = false;
            HistorialMov tmp = actual.claves[1];
            if(hm.idAtaque < actual.claves[1].idAtaque)
            {
                k = 0;
                encontrado = false;
            }
            else /*examinar la claves del nodo en orden descendente*/
            {
                k = actual.cuenta;
                while((hm.idAtaque < actual.claves[k].idAtaque) && (k > 1))
                {
                    tmp = actual.claves[k];
                    k--;
                }
                if (hm.idAtaque == actual.claves[k].idAtaque)
                    encontrado = true;
                else
                    encontrado = false;
                tmp = actual.claves[k];
            }
            return encontrado;
        }
        public Pagina buscar( Pagina actual, HistorialMov hm,ref int k)
        {
            if (actual == null)
                return null;
            else
            {
                bool esta = false;
                esta = buscarPagina( actual,  hm, ref k);
                if (esta)
                    return actual;
                else
                    return buscar( actual.ramas[k],  hm, ref k);
            }
        }
        public void insertar(HistorialMov hm)
        {
            insertar(ref raiz, hm);
        }
        public void insertar(ref Pagina raiz, HistorialMov hm)
        {
            bool subeArriba = false ;
            HistorialMov mediana = null;
            Pagina p = null;
            Pagina  nd = null;
            empujar( raiz,  hm, ref subeArriba, ref mediana, ref nd);
            if(subeArriba)
            {
                p = new Pagina(orden);
                p.cuenta = 1;
                p.claves[1] = mediana;
                p.ramas[0] = raiz;
                p.ramas[1] = nd;
                raiz = p;
            }
        }

        public void empujar( Pagina actual, HistorialMov hm,ref bool subeArriba,ref HistorialMov mediana,ref Pagina nuevo)
        {
            int k = 0;
            if(actual == null)
            {
                subeArriba = true;
                mediana = hm;
                nuevo = null;
            }
            else
            {
                bool esta;
                esta = buscarPagina( actual, hm,ref k);
                if(esta)
                {
                    Console.WriteLine("Clave duplicada: " + hm.idAtaque);
                    subeArriba = false;
                    return;
                }
                empujar( actual.ramas[k], hm, ref subeArriba, ref mediana, ref nuevo);
                if(subeArriba)
                {
                    if (actual.paginaLlena( actual))
                        dividirNodo( actual,  mediana,  nuevo, k,ref mediana,ref nuevo);
                    else
                    {
                        subeArriba = false;
                        meterHoja( actual,  mediana,  nuevo, k);
                    }
                        
                }
            }
        }

        public void dividirNodo( Pagina actual,  HistorialMov hm, Pagina rd,int k, ref HistorialMov mediana,ref Pagina nuevo)
        {
            int i, posMdna;
            if (k <= orden / 2)
                posMdna = orden / 2;
            else
                posMdna = orden / 2 + 1;

            nuevo = new Pagina(orden);
            for(i= posMdna+1; i< orden; i++)
            {
                /* es desplzada la mida derecha al nuevo nodo, la clave mediana se queda en el nodo origen*/
                nuevo.claves[i - posMdna] = actual.claves[i];
                nuevo.ramas[i - posMdna] = actual.ramas[i];
            }
            nuevo.cuenta = (orden - 1) - posMdna; /* claves en el nuevo nodo*/
            actual.cuenta = posMdna; //claves en el nodo origen    
            /* es insertada la clave y rama en el nodo que le corresponde*/
            if (k <= orden / 2)
                meterHoja( actual,  hm,  rd, k); /* inserta en el nodo origen*/
            else
                meterHoja( nuevo,  hm,  rd, k - posMdna);
            /* se extrae clave mediana del nodo origen*/
            mediana = actual.claves[actual.cuenta];
            /* Rama0 del nuevo nodo es la rama de la mediana*/
            nuevo.ramas[0] = actual.ramas[actual.cuenta];
            actual.cuenta--; /* disminuye ya que se quieta la mediana*/
        }
        public void meterHoja( Pagina actual,  HistorialMov hm,  Pagina rd, int k)
        {
            int i;
            /*desplaza a la derecha los elementos para hcer un hueco*/
            for (i = actual.cuenta; i >= k+1; i--)
            {
                actual.claves[i + 1] = actual.claves[i];
                actual.ramas[i + 1] = actual.ramas[i];
            }
            actual.claves[k + 1] = hm;
            actual.ramas[k + 1] = rd;
            actual.cuenta++;
        }
    }


    public class HistorialMov
    {
        public int coordenadaX;
        public int coordenadaY;
        public string idUnidadAtacante;
        public int resultado;
        public string idUnidadAtacada;
        public string idEmisor;
        public string idReceptor;
        public string fecha;
        public string tiempoRestante;
        public int idAtaque;

        public HistorialMov(int coordX,int coordY,string idUnidadAtacante,int resultDanio,string idUnidadAtacada,string idEmisor, string idReceptor,string fecha,string tiempo,int idAtaque)
        {
            this.coordenadaX = coordX;
            this.coordenadaY = coordY;
            this.idUnidadAtacante = idUnidadAtacante;
            this.resultado = resultDanio;
            this.idUnidadAtacada = idUnidadAtacada;
            this.idEmisor = idEmisor;
            this.idReceptor = idReceptor;
            this.fecha = fecha;
            this.tiempoRestante = tiempo;
            this.idAtaque = idAtaque;
        }

    }
}