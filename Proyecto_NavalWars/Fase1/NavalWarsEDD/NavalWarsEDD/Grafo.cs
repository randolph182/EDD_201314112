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
        public void generarTopJuegos(Top lista)
        {
            string estructuraDot = "digraph G{\n";
            string cabecera = "";
            string acum = "";

            if(lista.primero != null)
            {
                NodoTop tmp = lista.primero;
                int contador = 0;
                    while(contador != 11 && tmp.siguiete !=null)
                    {
                       
                        cabecera += tmp.GetHashCode().ToString() + "[label=\"" + tmp.user.nickName + "\n \\n" +
                                    tmp.user.partidadGanadas.ToString() + "\"];\n";
                        acum += tmp.GetHashCode().ToString() + " -> " + tmp.siguiete.GetHashCode().ToString() + ";\n";
                        contador++;
                        tmp = tmp.siguiete;
                    }

                   if(contador != 11)
                   {
                       cabecera += tmp.GetHashCode().ToString() + "[label=\"" + tmp.user.nickName + "\n \\n" +
                                    tmp.user.partidadGanadas.ToString() + "\"];\n";
                   }            }

            estructuraDot += cabecera + acum + "\n}\n";
            const string f = "C:\\Users\\rando\\Documents\\GitHub\\EDD_201314112\\Proyecto_NavalWars\\Fase1\\NavalWarsCliente\\NavalWarsCliente\\topJuegos.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(estructuraDot);
            w.Close();
            //generarImagen("C:\\GrafoEDD\\ABBUsuarios.dot" , "C:\\GrafoEDD\\ABBUsuarios.png");
            string archDot = "C:\\Users\\rando\\Documents\\GitHub\\EDD_201314112\\Proyecto_NavalWars\\Fase1\\NavalWarsCliente\\NavalWarsCliente\\topJuegos.dot";
            string archImg = "C:\\Users\\rando\\Documents\\GitHub\\EDD_201314112\\Proyecto_NavalWars\\Fase1\\NavalWarsCliente\\NavalWarsCliente\\topJuegos.png";
            generarImagen(archDot, archImg);
        }




        public void generarABBUsuario(ref ABBUsuario arbol)
        {
            string estructuraDot = "digraph G{\n";
            string acum = "";
            string cabecera = "node [shape = record,height=.1];\n";
            if(arbol.raiz !=null)
            {
                recorrerABB(ref arbol.raiz, ref acum,ref cabecera);
            }

            int altura = arbol.nivelArbol(arbol.raiz);
            int nivel = altura - 1;
            string info = "info[label=\""+"numero de Nodos = " + arbol.size.ToString() + " \n \\n numero de ramas = " + (arbol.size - 1).ToString() 
                + "\n \\n Nivel: "+ nivel.ToString()+ "\n \\n Altura:"+altura.ToString()+"\"];\n";

            estructuraDot += "\n"+ cabecera +"\n"+ acum + "\n\n "+info+"\n}\n";
            //const string f = "C:\\GrafoEDD\\ABBUsuarios.dot";
            const string f = "C:\\Users\\rando\\Documents\\GitHub\\EDD_201314112\\Proyecto_NavalWars\\Fase1\\NavalWarsCliente\\NavalWarsCliente\\ABBUsuarios.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(estructuraDot);
            w.Close();
            //generarImagen("C:\\GrafoEDD\\ABBUsuarios.dot" , "C:\\GrafoEDD\\ABBUsuarios.png");
            string archDot = "C:\\Users\\rando\\Documents\\GitHub\\EDD_201314112\\Proyecto_NavalWars\\Fase1\\NavalWarsCliente\\NavalWarsCliente\\ABBUsuarios.dot";
            string archImg = "C:\\Users\\rando\\Documents\\GitHub\\EDD_201314112\\Proyecto_NavalWars\\Fase1\\NavalWarsCliente\\NavalWarsCliente\\ABBUsuarios.png";
            generarImagen(archDot, archImg);
        }

        public void generarABBEspejo(ref NodoUsuario raiz)
        {
            string estructuraDot = "digraph G{\n";
            string acum = "";
            string cabecera = "node [shape = record,height=.1];\n";
            if (raiz != null)
            {
                recorrerABBEspejo(ref raiz, ref acum, ref cabecera);
            }
            estructuraDot += "\n" + cabecera + "\n" + acum + "\n}\n";
            //const string f = "C:\\GrafoEDD\\ABBUsuarios.dot";
            const string f = "C:\\Users\\rando\\Documents\\GitHub\\EDD_201314112\\Proyecto_NavalWars\\Fase1\\NavalWarsCliente\\NavalWarsCliente\\ABBUsuariosEsp.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(estructuraDot);
            w.Close();
            //generarImagen("C:\\GrafoEDD\\ABBUsuarios.dot" , "C:\\GrafoEDD\\ABBUsuarios.png");
            string archDot = "C:\\Users\\rando\\Documents\\GitHub\\EDD_201314112\\Proyecto_NavalWars\\Fase1\\NavalWarsCliente\\NavalWarsCliente\\ABBUsuariosEsp.dot";
            string archImg = "C:\\Users\\rando\\Documents\\GitHub\\EDD_201314112\\Proyecto_NavalWars\\Fase1\\NavalWarsCliente\\NavalWarsCliente\\ABBUsuariosEsp.png";
            generarImagen(archDot, archImg);
        }
        public void recorrerABBEspejo(ref NodoUsuario actual,ref string acum,ref string cabecera)
        {
            if (actual != null)
            {
                cabecera += "struct" + actual.informacion.nickName + "[label=\"<f0>  | <f1> nickName: " + actual.informacion.nickName + " \n \\n" +
                                                    "nombre: " + actual.informacion.nombre + " \n \\n" +
                                                    "password: " + actual.informacion.password + " \n \\n" +
                                                    "email: " + actual.informacion.email + " \n \\n" +
                                                    "conectado: " + actual.informacion.conectado.ToString() + "  | <f2> \"];\n";
                if (actual.lstJuegos.primero != null)
                {
                    cabecera += "\n" + actual.lstJuegos.listaJuegos(actual.informacion.nickName);
                    acum += "\"struct" + actual.informacion.nickName + "\":f1 -> " + actual.lstJuegos.primero.idNodo + ";\n";
                }
                if (actual.derecha != null)
                {
                    acum += "\"struct" + actual.informacion.nickName + "\":f0 -> \"struct" + actual.derecha.informacion.nickName + "\":f1;\n";
                    
                }

                if (actual.izquierda != null)
                {

                    acum += "\"struct" + actual.informacion.nickName + "\":f2 -> \"struct" + actual.izquierda.informacion.nickName + "\":f1;\n";
                    
                }
                
                recorrerABBEspejo(ref actual.izquierda, ref acum, ref cabecera);
                recorrerABBEspejo(ref actual.derecha, ref acum, ref cabecera);
              
                
               

            }
        }
        public void recorrerABB(ref NodoUsuario actual,ref string acum,ref string cabecera)
        {
            if(actual !=null)
            {
                cabecera += "struct" + actual.informacion.nickName + "[label=\"<f0>  | <f1> nickName: " + actual.informacion.nickName + " \n \\n" +
                                                    "nombre: " + actual.informacion.nombre + " \n \\n" +
                                                    "password: " + actual.informacion.password + " \n \\n" +
                                                    "email: " + actual.informacion.email + " \n \\n" +
                                                    "conectado: " + actual.informacion.conectado.ToString() + "  | <f2> \"];\n"; 
                if(actual.lstJuegos.primero !=null)
                {
                    cabecera += "\n" + actual.lstJuegos.listaJuegos(actual.informacion.nickName);
                    acum += "\"struct" + actual.informacion.nickName + "\":f1 -> " + actual.lstJuegos.primero.idNodo + ";\n";
                }
                if(actual.izquierda !=null)
                {

                    acum += "\"struct" + actual.informacion.nickName + "\":f0 -> \"struct" + actual.izquierda.informacion.nickName + "\":f1;\n";

                    //if (actual.izquierda.lstJuegos.primero != null)
                    //{
                    // //   cabecera += "\n" + actual.izquierda.lstJuegos.listaJuegos(actual.izquierda.informacion.nickName);
                    //    acum += "\"struct" + actual.izquierda.informacion.nickName + "\":f1 -> " + actual.izquierda.lstJuegos.primero.idNodo + ";\n";
                    //}
                }
                if(actual.derecha  != null)
                {
                    acum += "\"struct" + actual.informacion.nickName + "\":f2 -> \"struct" + actual.derecha.informacion.nickName + "\":f1;\n";
                    
                    //if (actual.derecha.lstJuegos.primero != null)
                    //{
                    //  //  cabecera += "\n" + actual.derecha.lstJuegos.listaJuegos(actual.izquierda.informacion.nickName);
                    //    acum += "\"struct" + actual.derecha.informacion.nickName + "\":f1 -> " + actual.derecha.lstJuegos.primero.idNodo + ";\n";
                    //}
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