using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Diagnostics;

namespace CreacionABB
{
    class Grafo
    {
        public void generarArbol(ref Nodo raiz)
        {
            string acum = "digraph G{\n";
            if (raiz != null)
            {
                acum += raiz.letra + ";\n";
                recorrerABB( raiz,ref acum);
            }
            acum += "\n}\n";
            const string f = "ABB.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(acum);
            w.Close();
            generarImagen("ABB.dot", "ABB.png");
        }

        public void recorrerABB(Nodo actual,ref string acum )
        {
            if (actual != null)
            {
                if (actual.izq != null)
                {
                    acum += actual.letra + "->" + actual.izq.letra + ";\n";
                }
                if (actual.der != null)
                {
                    acum += actual.letra + "->" + actual.der.letra + ";\n";
                }

                recorrerABB(actual.izq, ref acum);
                recorrerABB(actual.der, ref acum);

            }
        }
        public void generarImagen(string nombArchivo,string nombImagen)
        {
            Process a = new Process();
            a.StartInfo.FileName = "\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\"";
            a.StartInfo.Arguments = "dot -Tpng " + nombArchivo + " -o " + nombImagen;
            a.StartInfo.UseShellExecute = false;
            a.Start();
            a.WaitForExit();
        }
    }
}
