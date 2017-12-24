using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreacionABB
{


    public class Nodo
    {
        public Nodo izq;
        public Nodo der;
        public char letra;
        public Nodo(char letra)
        {
            this.letra = letra;
            izq = null;
            der = null;
        }
    }



    public class Arbol
    {
        public Nodo raiz;
        public Arbol()
        {
            raiz = null;
        }

        public void insertar(char nuevo)
        {
            insertar(ref raiz, nuevo);
        }


        public void insertar(ref Nodo actual,char val)
        {
            if(actual == null)
            {
                actual = new Nodo(val);
            }
            else if(val.CompareTo(actual.letra) < 0 )
            {
                insertar(ref actual.izq, val);
            }
            else if(val.CompareTo(actual.letra) > 0 )
            {
                insertar(ref actual.der, val);
            }

        }



        public void recorridoPreOrden(ref Nodo actual)
        {
           
            if(actual !=null)
            {
                Console.Write(actual.letra + "  ");
                recorridoPreOrden(ref actual.izq);
                recorridoPreOrden(ref actual.der);
            }
        }
        public void recorridoInOrden(ref Nodo actual)
        {
            if(actual !=null)
            {
                recorridoInOrden(ref actual.izq);
                Console.Write(actual.letra + "  ");
                recorridoInOrden(ref actual.der);
            }
        }
        public void recorridoPostOrden(ref Nodo actual)
        {
            if(actual !=null)
            {
                recorridoPostOrden(ref actual.izq);
                recorridoPostOrden(ref actual.der);
                Console.Write(actual.letra + "  ");
            }
        }
    }
    class ABB
    {
    }
}
