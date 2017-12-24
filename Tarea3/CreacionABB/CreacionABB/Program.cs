using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreacionABB
{
    class Program
    {
        static void Main(string[] args)
        {
            Arbol abb = new Arbol();
            Grafo g = new Grafo();

            abb.insertar('R');
            abb.insertar('B');
            abb.insertar('A');
            abb.insertar('C');
            abb.insertar('X');
            abb.insertar('Z');
            abb.insertar('W');

            Console.Write("Recorrido en PreOrden: ");
            abb.recorridoPreOrden(ref abb.raiz);
            Console.Write("\n");

            Console.Write("Recorrido InOrden: ");
            abb.recorridoInOrden(ref abb.raiz);
            Console.Write("\n");

            Console.Write("Recorrido PostOrden: ");
            abb.recorridoPostOrden(ref abb.raiz);
            Console.Write("\n");

            g.generarArbol(ref abb.raiz);
            
            Console.ReadKey();


        }
    }
}
