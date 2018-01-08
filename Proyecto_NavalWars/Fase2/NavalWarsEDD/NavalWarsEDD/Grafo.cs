using System;
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
            const string f = "C:\\GrafoEDD\\topJuegos.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(estructuraDot);
            w.Close();
            //generarImagen("C:\\GrafoEDD\\ABBUsuarios.dot" , "C:\\GrafoEDD\\ABBUsuarios.png");
            generarImagen("C:\\GrafoEDD\\topJuegos.dot", "C:\\GrafoEDD\\topJuegos.png");
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
            const string f = "C:\\GrafoEDD\\ABBUsuarios.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(estructuraDot);
            w.Close();
            generarImagen("C:\\GrafoEDD\\ABBUsuarios.dot" , "C:\\GrafoEDD\\ABBUsuarios.png");
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
            const string f = "C:\\GrafoEDD\\ABBUsuariosEsp.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(estructuraDot);
            w.Close();
            //generarImagen("C:\\GrafoEDD\\ABBUsuarios.dot" , "C:\\GrafoEDD\\ABBUsuarios.png");
            generarImagen("C:\\GrafoEDD\\ABBUsuariosEsp.dot", "C:\\GrafoEDD\\ABBUsuariosEsp.png");
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
                    imprimir(tmp, ref acum, ref acumEnlace);
                    for (int i = 0; i <= tmp.cuenta; i++)
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
        
        public void imprimir( Pagina actual, ref string acum ,ref string enlace)
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
        
        public void generarGrafoTablaHash( TablaHash th)
        {
            string acum = "digraph G { \n nodesep=.05; \n rankdir=LR; \n node [shape=record,width=.1,height=.1]; \n";
            th.getAcumGrafo(ref acum);
            acum += "\n } \n";
            const string f = "C:\\GrafoEDD\\TablaHash.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(acum);
            w.Close();
            generarImagen("C:\\GrafoEDD\\TablaHash.dot", "C:\\GrafoEDD\\TablaHash.png");
        }

        public void generarMatriz(Matriz matriz, int nivel)
        {
            string acumInfo = "digraph G{ \n " +
                                "node[shape=box, style=filled, color=deepskyblue3];\n " +
                                "edge[color=black]; \n " +
                                "rankdir=UD; \n";

            string idCabeceraFila = "";
            string cabeceraFila = "";
            string idCabeceraCol = "";
            string cabeceraCol = "";
            string alineacionCol = "{rank=min;Matriz;";
            string acumOrtogonales = "";

            NodoOrtogonal accesoCol = null;
            string cabeceraOrtogonalCol = "";
            string acumEnlaceCol = "";
            bool accesoColEncontrada = false;


            NodoOrtogonal accesoFila = null;
            string cabeceraOrtogonalFila = "";
            string acumEnlaceFila = "";
            bool accesoFilaEncontrada = false;
            string ranksame = "";
            string alineacionFilas = "";

            Encabezado eFila = matriz.ncbzdoFilas.primero;
            Encabezado eCol = matriz.ncbzdoColumnas.primero;

            if (eFila != null)
            {
                cabeceraFila += "Matriz -> " + eFila.GetHashCode().ToString() + ";\n";

                while (eFila.siguiente != null)
                {
                    idCabeceraFila += eFila.GetHashCode().ToString() + "[label = \"" + eFila.id.ToString() + "\"];\n";
                    cabeceraFila += eFila.GetHashCode().ToString() + " -> " + eFila.siguiente.GetHashCode().ToString() + "[rankdir=UD];\n";
                    ranksame = "";
                    ranksame += "{rank=same;" + eFila.GetHashCode().ToString() + ";";
                    obtenerNodosOrtogonalesFila(ref eFila, ref eFila.accesoNodo, ref acumEnlaceFila, ref cabeceraOrtogonalFila, ref ranksame, ref accesoFila, nivel, ref accesoFilaEncontrada);
                    if (accesoFila != null)
                    {
                        acumOrtogonales += cabeceraOrtogonalFila + "\n";
                        acumOrtogonales += accesoFila.GetHashCode().ToString() + "[label=\"" + accesoFila.unidad.idUnidad + "\"];\n";
                        acumOrtogonales += eFila.GetHashCode().ToString() + " -> " + accesoFila.GetHashCode().ToString() + "[constraint=false];\n";
                        acumOrtogonales += acumEnlaceFila + "[constraint=false];\n";

                        ranksame += "};\n";
                        alineacionFilas += ranksame;

                    }
                    ranksame = "";
                    cabeceraOrtogonalFila = "";
                    acumEnlaceFila = "";
                    accesoFila = null;
                    accesoFilaEncontrada = false;

                    eFila = eFila.siguiente;
                }
                if (eFila.siguiente == null)
                {
                    cabeceraOrtogonalFila = "";
                    acumEnlaceFila = "";
                    accesoFila = null;
                    accesoFilaEncontrada = false;
                    ranksame = "";
                    idCabeceraFila += eFila.GetHashCode().ToString() + "[label = \"" + eFila.id.ToString() + "\"];\n";
                    ranksame += "{rank=same;" + eFila.GetHashCode().ToString() + ";";
                    obtenerNodosOrtogonalesFila(ref eFila, ref eFila.accesoNodo, ref acumEnlaceFila, ref cabeceraOrtogonalFila, ref ranksame, ref accesoFila, nivel, ref accesoFilaEncontrada);
                    if (accesoFila != null)
                    {
                        acumOrtogonales += cabeceraOrtogonalFila + "\n";
                        acumOrtogonales += accesoFila.GetHashCode().ToString() + "[label=\"" + accesoFila.unidad.idUnidad + "\"];\n";
                        acumOrtogonales += eFila.GetHashCode().ToString() + " -> " + accesoFila.GetHashCode().ToString() + ";\n";
                        acumOrtogonales += acumEnlaceFila + ";\n";

                        ranksame += "};\n";
                        alineacionFilas += ranksame;
                        ranksame = "";
                    }

                }

                while (eFila.anterior != null)
                {
                    cabeceraFila += eFila.GetHashCode().ToString() + " -> " + eFila.anterior.GetHashCode().ToString() + ";\n";
                    eFila = eFila.anterior;
                }
            }
            if (eCol != null)
            {
                cabeceraCol += "Matriz ->" + eCol.GetHashCode().ToString() + ";\n";
                while (eCol.siguiente != null)
                {
                    string conversion = Convert.ToChar(eCol.id).ToString();
                    alineacionCol += eCol.GetHashCode().ToString() + ";";
                    idCabeceraCol += eCol.GetHashCode().ToString() + "[label=\"" + conversion + "\"];\n";
                    cabeceraCol += eCol.GetHashCode().ToString() + " -> " + eCol.siguiente.GetHashCode().ToString() + ";\n";
                    obtenerNodosOrtogonalesCol(ref eCol, ref eCol.accesoNodo, ref acumEnlaceCol, ref cabeceraOrtogonalCol, ref accesoCol, nivel, ref accesoColEncontrada);
                    if (accesoCol != null)
                    {
                        acumOrtogonales += cabeceraOrtogonalCol + "\n";
                        acumOrtogonales += eCol.GetHashCode().ToString() + " -> " + accesoCol.GetHashCode().ToString() + ";\n";
                        acumOrtogonales += acumEnlaceCol + ";\n";
                    }
                    cabeceraOrtogonalCol = "";
                    acumEnlaceCol = "";
                    accesoColEncontrada = false;
                    accesoCol = null;

                    eCol = eCol.siguiente;
                }
                if (eCol.siguiente == null)
                {
                    string conv = Convert.ToChar(eCol.id).ToString();
                    cabeceraOrtogonalCol = "";
                    acumEnlaceCol = "";
                    accesoColEncontrada = false;
                    accesoCol = null;
                    obtenerNodosOrtogonalesCol(ref eCol, ref eCol.accesoNodo, ref acumEnlaceCol, ref cabeceraOrtogonalCol, ref accesoCol, nivel, ref accesoColEncontrada);
                    if (accesoCol != null)
                    {
                        acumOrtogonales += cabeceraOrtogonalCol + "\n";
                        // acumOrtogonales += accesoCol.GetHashCode().ToString() + "[label=\"" + accesoCol.unidad.idUnidad + "\"];\n";
                        acumOrtogonales += eCol.GetHashCode().ToString() + " -> " + accesoCol.GetHashCode().ToString() + ";\n";
                        acumOrtogonales += acumEnlaceCol + ";\n";
                    }
                    alineacionCol += eCol.GetHashCode().ToString() + ";";
                    idCabeceraCol += eCol.GetHashCode().ToString() + "[label=\"" + conv + "\"];\n";
                }

                while (eCol.anterior != null)
                {
                    cabeceraCol += eCol.GetHashCode().ToString() + " -> " + eCol.anterior.GetHashCode().ToString() + ";\n";
                    eCol = eCol.anterior;
                }
            }
            alineacionCol += "};\n\n";
            acumInfo += alineacionCol + alineacionFilas + idCabeceraCol + idCabeceraFila + cabeceraCol + cabeceraFila + "\n\n" + acumOrtogonales + "\n}\n";

            string idGrafo = "C:\\GrafoEDD\\matriz" + nivel.ToString() + ".dot";
            //const string f = idGrafo.ToString();
            StreamWriter w = new StreamWriter(idGrafo);
            w.WriteLine(acumInfo);
            w.Close();
            generarImagen("C:\\GrafoEDD\\matriz" + nivel.ToString() + ".dot", "C:\\GrafoEDD\\matriz" + nivel.ToString() + ".png");
        }

        public void obtenerNodosOrtogonalesCol(ref Encabezado eCol, ref NodoOrtogonal actual, ref string acumEnlace, ref string cabecera, ref NodoOrtogonal acceso, int nivel, ref bool accesoEncontrado)
        {
            if (actual != null)
            {

                if (actual.atras != null && actual.atras.unidad.nivel == nivel)
                {
                    if (!accesoEncontrado)
                    {
                        accesoEncontrado = true;
                        acceso = actual.atras;// actual.GetHashCode().ToString() + "[label=\"" + actual.atras.unidad.idUnidad + "\"];\n";
                        acumEnlace += actual.atras.GetHashCode().ToString() + " ";
                    }
                    else
                    {
                        cabecera += actual.atras.GetHashCode().ToString() + "[label=\"" + actual.atras.unidad.idUnidad + "\"];\n";
                        acumEnlace += " -> " + actual.atras.GetHashCode().ToString() + " ";
                    }
                }
                else if (actual != null && actual.unidad.nivel == nivel)
                {
                    if (!accesoEncontrado)
                    {
                        accesoEncontrado = true;
                        acceso = actual;
                        acumEnlace += actual.GetHashCode().ToString() + " ";
                    }
                    else
                    {
                        cabecera += actual.GetHashCode().ToString() + "[label=\"" + actual.unidad.idUnidad + "\"];\n";
                        acumEnlace += " -> " + actual.GetHashCode().ToString() + " ";
                    }
                }
                else if (actual.adelante != null && actual.adelante.unidad.nivel == nivel)
                {
                    if (!accesoEncontrado)
                    {
                        accesoEncontrado = true;
                        acceso = actual.adelante;
                        acumEnlace += actual.adelante.GetHashCode().ToString() + " ";
                    }
                    else
                    {
                        cabecera += actual.adelante.GetHashCode().ToString() + "[label=\"" + actual.adelante.unidad.idUnidad + "\"];\n";
                        acumEnlace += " -> " + actual.adelante.GetHashCode().ToString() + " ";
                    }
                }
                else if (actual.adelante != null)
                {
                    if (actual.adelante.adelante != null && actual.adelante.adelante.unidad.nivel == nivel)
                    {
                        if (!accesoEncontrado)
                        {
                            accesoEncontrado = true;
                            acceso = actual.adelante.adelante;
                            acumEnlace += actual.adelante.adelante.GetHashCode().ToString() + " ";
                        }
                        else
                        {
                            cabecera += actual.adelante.adelante.GetHashCode().ToString() + "[label=\"" + actual.adelante.adelante.unidad.idUnidad + "\"];\n";
                            acumEnlace += " -> " + actual.adelante.adelante.GetHashCode().ToString() + " ";
                        }

                    }
                }

                obtenerNodosOrtogonalesCol(ref eCol, ref actual.abajo, ref acumEnlace, ref cabecera, ref acceso, nivel, ref  accesoEncontrado);
            }
        }

        public void obtenerNodosOrtogonalesFila(ref Encabezado eFila, ref NodoOrtogonal actual, ref string acumEnlace, ref string cabecera, ref string rankSame, ref NodoOrtogonal acceso, int nivel, ref bool accesoEncontrado)
        {
            if (actual != null)
            {

                if (actual.atras != null && actual.atras.unidad.nivel == nivel)
                {
                    if (!accesoEncontrado)
                    {
                        accesoEncontrado = true;
                        acceso = actual.atras;// actual.GetHashCode().ToString() + "[label=\"" + actual.atras.unidad.idUnidad + "\"];\n";
                        acumEnlace += actual.atras.GetHashCode().ToString() + " ";
                        rankSame += actual.atras.GetHashCode().ToString() + ";";
                    }
                    else
                    {
                        cabecera += actual.atras.GetHashCode().ToString() + "[label=\"" + actual.atras.unidad.idUnidad + "\"];\n";
                        acumEnlace += " -> " + actual.atras.GetHashCode().ToString() + " ";
                        rankSame += actual.atras.GetHashCode().ToString() + ";";
                    }
                }
                else if (actual != null && actual.unidad.nivel == nivel)
                {
                    if (!accesoEncontrado)
                    {
                        accesoEncontrado = true;
                        acceso = actual;
                        acumEnlace += actual.GetHashCode().ToString() + " ";
                        rankSame += actual.GetHashCode().ToString() + ";";
                    }
                    else
                    {
                        cabecera += actual.GetHashCode().ToString() + "[label=\"" + actual.unidad.idUnidad + "\"];\n";
                        acumEnlace += " -> " + actual.GetHashCode().ToString() + " ";
                        rankSame += actual.GetHashCode().ToString() + ";";
                    }
                }
                else if (actual.adelante != null && actual.adelante.unidad.nivel == nivel)
                {
                    if (!accesoEncontrado)
                    {
                        accesoEncontrado = true;
                        acceso = actual.adelante;
                        acumEnlace += actual.adelante.GetHashCode().ToString() + " ";
                        rankSame += actual.adelante.GetHashCode().ToString() + ";";
                    }
                    else
                    {
                        cabecera += actual.adelante.GetHashCode().ToString() + "[label=\"" + actual.adelante.unidad.idUnidad + "\"];\n";
                        acumEnlace += " -> " + actual.adelante.GetHashCode().ToString() + " ";
                        rankSame += actual.adelante.GetHashCode().ToString() + ";";
                    }
                }
                else if (actual.adelante != null)
                {
                    if (actual.adelante.adelante != null && actual.adelante.adelante.unidad.nivel == nivel)
                    {
                        if (!accesoEncontrado)
                        {
                            accesoEncontrado = true;
                            acceso = actual.adelante.adelante;
                            acumEnlace += actual.adelante.adelante.GetHashCode().ToString() + " ";
                            rankSame += actual.adelante.adelante.GetHashCode().ToString() + ";";
                        }
                        else
                        {
                            cabecera += actual.adelante.adelante.GetHashCode().ToString() + "[label=\"" + actual.adelante.adelante.unidad.idUnidad + "\"];\n";
                            acumEnlace += " -> " + actual.adelante.adelante.GetHashCode().ToString() + " ";
                            rankSame += actual.adelante.adelante.GetHashCode().ToString() + ";";
                        }

                    }
                }

                obtenerNodosOrtogonalesFila(ref eFila, ref actual.derecha, ref acumEnlace, ref cabecera, ref rankSame, ref acceso, nivel, ref  accesoEncontrado);
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