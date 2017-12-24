﻿using System;
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
            string cabecera = "";
            if(raiz !=null)
            {
                recorrerABB(ref raiz, ref acum,ref cabecera);
            }
            estructuraDot += "\n"+ acum +"\n"+ cabecera + "\n}\n";
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
                 cabecera += actual.informacion.nickName + "[label=\"nickName: "+ actual.informacion.nickName + "\n"+
                                                    "nombre: "+actual.informacion.nombre+"\n"+
                                                    "password: "+actual.informacion.password+"\n"+
                                                    "email: "+ actual.informacion.email+"\n"+
                                                    "conectado: "+actual.informacion.conectado.ToString()+"\"];\n"; 
                if(actual.izquierda !=null)
                {
                    cabecera += actual.izquierda.informacion.nickName + "[label=\"nickName: " + actual.izquierda.informacion.nickName + "\n" +
                                                    "nombre: " + actual.izquierda.informacion.nombre + "\n" +
                                                    "password: " + actual.izquierda.informacion.password + "\n" +
                                                    "email: " + actual.izquierda.informacion.email + "\n" +
                                                    "conectado: " + actual.izquierda.informacion.conectado.ToString() + "\"];\n"; 

                    acum += actual.informacion.nickName + "->" + actual.izquierda.informacion.nickName + ";\n";
                }
                if(actual.derecha  != null)
                {
                    cabecera += actual.derecha.informacion.nickName + "[label=\"nickName: " + actual.derecha.informacion.nickName + "\n" +
                                                    "nombre: " + actual.derecha.informacion.nombre + "\n" +
                                                    "password: " + actual.derecha.informacion.password + "\n" +
                                                    "email: " + actual.derecha.informacion.email + "\n" +
                                                    "conectado: " + actual.derecha.informacion.conectado.ToString() + "\"];\n";

                    acum += actual.informacion.nickName + "->" + actual.derecha.informacion.nickName + ";\n";
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