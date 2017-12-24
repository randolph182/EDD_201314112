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
            string estructuraDot = "digraph G{\n";
            string acum = "";
            string cabecera = "node [shape = record,height=.1];\n";
            if(raiz !=null)
            {
                recorrerABB(ref raiz, ref acum,ref cabecera);
            }
            estructuraDot += "\n"+ cabecera +"\n"+ acum + "\n}\n";
            const string f = "C:\\GrafoEDD\\ABBUsuarios.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(estructuraDot);
            w.Close();
            generarImagen("C:\\GrafoEDD\\ABBUsuarios.dot" , "C:\\GrafoEDD\\ABBUsuarios.png");
        }

        public void recorrerABB(ref NodoUsuario actual,ref string acum,ref string cabecera)
        {
            if(actual !=null)
            {
                cabecera += "struct" + actual.informacion.nickName + "[label=\"<f0>  | <f1> nickName: " + actual.informacion.nickName + " \n" +
                                                    "nombre: "+actual.informacion.nombre+" \n"+
                                                    "password: "+actual.informacion.password+" \n"+
                                                    "email: "+ actual.informacion.email+" \n"+
                                                    "conectado: " + actual.informacion.conectado.ToString() + "  | <f2> \"];\n"; 
                if(actual.izquierda !=null)
                {

                    acum += "\"struct" + actual.informacion.nickName + "\":f0 -> \"struct" + actual.izquierda.informacion.nickName + "\":f1;\n";

                }
                if(actual.derecha  != null)
                {
                    acum += "\"struct" + actual.informacion.nickName + "\":f2 -> \"struct" + actual.derecha.informacion.nickName + "\":f1;\n";
                }

                recorrerABB(ref actual.izquierda, ref acum,ref cabecera);
                recorrerABB(ref actual.derecha, ref acum, ref cabecera);
                
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