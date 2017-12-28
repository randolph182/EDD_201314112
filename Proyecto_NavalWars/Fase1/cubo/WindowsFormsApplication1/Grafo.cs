using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Grafo
    {
        public void generarMatriz(Matriz matriz,int nivel)
        {
            string acumInfo = "digraph G{ \n "+
           "node[shape=box, style=filled, color=deepskyblue3];\n " +
           "edge[color=black]; \n " +
           "rankdir=UD; \n";


            string idCabeceraFila = "";
             string cabeceraFila = "";
             string idCabeceraCol = "";
             string cabeceraCol = "";
             string alineacionCol = "{rank=min;Matriz;";
             string acumOrtogonales = "";

            string nodoAcum = "";
            string anterior = "";
            string anteriorCabecera = "";
            string filas = "Matriz;";
            string columnas = "Matriz";

            //recorrido de filas;
            Encabezado eFila = matriz.ncbzdoFilas.primero;
            Encabezado eCol = matriz.ncbzdoColumnas.primero;
            
            if(eFila !=null)
            {
                cabeceraFila += "Matriz ->" + eFila.GetHashCode().ToString() + ";\n";
                while (eFila.siguiente != null)
                {
                    idCabeceraFila += eFila.GetHashCode().ToString() + "[label = \"" + eFila.id.ToString() + "\"];\n";
                    cabeceraFila += eFila.GetHashCode().ToString() + " -> " + eFila.siguiente.GetHashCode().ToString() + ";\n";
                    
                    eFila = eFila.siguiente;
                }
                idCabeceraFila += eFila.GetHashCode().ToString() + "[label = \"" + eFila.id.ToString() + "\"];\n";
                while (eFila.anterior != null)
                {
                    cabeceraFila += eFila.GetHashCode().ToString() + " -> " + eFila.anterior.GetHashCode().ToString() + ";\n";
                    eFila = eFila.anterior;
                }
            }
            if(eCol != null)
            {
                cabeceraCol += "Matriz ->" + eCol.GetHashCode().ToString() + ";\n";
                while(eCol.siguiente !=null)
                {
                    string conversion = Convert.ToChar(eCol.id).ToString();
                   alineacionCol += eCol.GetHashCode().ToString()+ ";";
                    idCabeceraCol += eCol.GetHashCode().ToString() + "[label=\"" + conversion + "\"];\n";
                    cabeceraCol += eCol.GetHashCode().ToString() + " -> " + eCol.siguiente.GetHashCode().ToString() + ";\n";
                   // MessageBox.Show(eCol.GetHashCode().ToString());
                    enlazarNodosOrtoCol(ref eCol, ref acumOrtogonales,nivel);
                    eCol = eCol.siguiente;
                }
                string conv = Convert.ToChar(eCol.id).ToString();
                enlazarNodosOrtoCol(ref eCol, ref acumOrtogonales, nivel);
                alineacionCol += eCol.GetHashCode().ToString() + ";};\n\n";
                idCabeceraCol += eCol.GetHashCode().ToString() + "[label=\"" + conv + "\"];\n";
                while(eCol.anterior !=null)
                {
                    cabeceraCol += eCol.GetHashCode().ToString() + " -> " + eCol.anterior.GetHashCode().ToString() + ";\n";
                    eCol = eCol.anterior;
                }

            }


            acumInfo += alineacionCol + idCabeceraCol + idCabeceraFila + cabeceraCol + cabeceraFila +"\n\n" + acumOrtogonales +"\n}\n";

            const string f = "matriz.dot";
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(acumInfo);
            w.Close();
            generarImagen("matriz.dot", "matriz.png");
        }

        public void  enlazarNodosOrtoCol(ref Encabezado eActual, ref string acum,int nivel)
        {
            if (eActual.acceso != null)
            {
                string idCum = "";
                string acumElace = "";
                Nodo tmp = eActual.acceso;

                if(tmp.unidad.nivel == nivel)
                {
                    acumElace += eActual.GetHashCode().ToString() + " -> " + tmp.GetHashCode().ToString() + ";\n";
                }


                while(tmp.abajo !=null)
                {
                    if(tmp.unidad.nivel == nivel)
                    {
                        idCum += tmp.GetHashCode().ToString() + "[label=\"" + tmp.unidad.tipo.ToString() + "\"];\n";
                        if(tmp.abajo.unidad.nivel == nivel)
                        {
                            acumElace += tmp.GetHashCode().ToString() + " -> " + tmp.abajo.GetHashCode().ToString() + ";\n";
                        }
                    }               
                    tmp = tmp.abajo;
                }

                
                if(tmp.unidad.nivel == nivel)
                {
                    idCum += tmp.GetHashCode().ToString() + "[label=\"" + tmp.unidad.tipo.ToString() + "\"];\n";
                }
/************************************************************************************************************/
                while (tmp.arriba != null)
                {
                    if (tmp.unidad.nivel == nivel && tmp.arriba.unidad.nivel == nivel)
                    {
                            acumElace += tmp.GetHashCode().ToString() + " -> " + tmp.arriba.GetHashCode().ToString() + ";\n";
                    }
                    tmp = tmp.arriba;
                }

                acum += idCum + acumElace + "\n";
            }
        }


        public Nodo buscarNodoCol(ref Encabezado eCol)
        {
            return null;
        }

        public void enlazarNodosOrtoFila(ref Nodo actual, ref string acum)
        {
            if(actual !=null)
            {

            }
        }
        public void generarImagen(string nombArchivo, string nombImagen)
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
