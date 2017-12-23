using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace NavalWarsEDD
{
    public class Grafo
    {
        public void generarABBUsuario(ref NodoUsuario raiz)
        {
            string acum = "digraph G{\n";
            if(raiz !=null)
            {
                acum += raiz.informacion.nickName + ";\n";
                recorrerABB(ref raiz, ref acum);
            }
            acum += "\n}\n";
            const string f = "C:\\GrafoEDD\\ABBUsuarios.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(acum);
            w.Close();
            generarImagen("C:\\GrafoEDD\\ABBUsuarios.dot" , "C:\\GrafoEDD\\ABBUsuarios.png");
        }

        public void recorrerABB(ref NodoUsuario actual,ref string acum)
        {
            if(actual !=null)
            {
                if(actual.izquierda !=null)
                {
                    acum += actual.informacion.nickName + "->" + actual.izquierda.informacion.nickName + ";\n";
                }
                if(actual.derecha  != null)
                {
                    acum += actual.informacion.nickName + "->" + actual.derecha.informacion.nickName + ";\n";
                }

                recorrerABB(ref actual.izquierda, ref acum);
                recorrerABB(ref actual.derecha, ref acum);
                
            }
        }

        public void generarImagen(string nombArchivo,string nombImagen)
        {
            Process a = new Process();
            a.StartInfo.FileName = "\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\"";
            //a.StartInfo.Arguments = "-Tjpg" + nombArchivo + " -o " + nombImagen;
            a.StartInfo.Arguments = "dot -Tpng " + nombArchivo + " -o " + nombImagen;
            a.StartInfo.UseShellExecute = false;
            a.Start();
            a.WaitForExit();
        }


    }
}