﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;
using System.Collections;


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
                    acum += "\"struct" + actual.informacion.nickName + "\":f0 -> \"struct" + actual.izquierda.informacion.nickName + "\":f1;\n";
                if(actual.derecha  != null)
                    acum += "\"struct" + actual.informacion.nickName + "\":f2 -> \"struct" + actual.derecha.informacion.nickName + "\":f1;\n";

                recorrerABB(ref actual.izquierda, ref acum,ref cabecera);
                recorrerABB(ref actual.derecha, ref acum, ref cabecera);
                
            }
        }

        public void generarGrafoAVL(ref ArbolAVL arbol)
        {
            string acum = "";
            string grafo = "digraph G{\n";
            string cabecera = "node [shape = record,height=.1];\n";
            arbol.preOrden(ref arbol.raiz, ref acum, ref cabecera);
            grafo += cabecera + acum + "\n}\n";
            const string f = "C:\\GrafoEDD\\AVL.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(grafo);
            w.Close();
            generarImagen("C:\\GrafoEDD\\AVL.dot", "C:\\GrafoEDD\\AVL.png");
        }

        public void generarGrafoArbolB(ref Pagina raiz)
        {
            string acum = "digraph G\n" +
                            "{\n node	[shape = record,height=.1];\n";
           
            if(raiz != null)
            {
                string acumEnlace = "";
                int contNodo = 0;
                int contAux = 0;
                Queue cola = new Queue();
                cola.Enqueue(raiz);
                while(cola.Count != 0)
                {
                    Pagina tmp = (Pagina)cola.Peek();
                    cola.Dequeue();
                    imprimir(ref tmp, ref acum, ref acumEnlace);
                    for (int i = 0; i <= tmp.cuenta; ++i)
                    {
                        if (tmp.ramas[i] != null)
                            cola.Enqueue(tmp.ramas[i]);
                    }
                }
                acum += "\n" + acumEnlace;
            }
            acum += "}\n";
            const string f = "C:\\GrafoEDD\\ArbolB.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(acum);
            w.Close();
            generarImagen("C:\\GrafoEDD\\ArbolB.dot", "C:\\GrafoEDD\\ArbolB.png");
        }
        
        public void imprimir(ref Pagina actual, ref string acum ,ref string enlace)
        {
            acum += actual.GetHashCode().ToString() + "[label=\"";
            acum += "<r0>";
            if(actual.ramas[0] != null)
            {
                enlace += "\""+actual.GetHashCode().ToString()+ "\":r0 ->";
                enlace += "\""+actual.ramas[0].GetHashCode().ToString() + "\"\n";
            }
            for (int i = 1; i <= actual.cuenta; i++)
            {
                acum += "|";
                acum += "<c"+i.ToString()+"> " + actual.claves[i].idAtaque.ToString();
                acum += "|<r" + i.ToString() + ">";
                if(actual.ramas[i] != null)
                {
                    enlace += "\""+actual.GetHashCode().ToString() + "\":r" + i.ToString() + " -> ";
                    enlace += "\"" + actual.ramas[i].GetHashCode().ToString() + "\"\n";
                }
            }
            acum += "\"];\n";
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