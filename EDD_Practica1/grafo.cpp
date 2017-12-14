#include "grafo.h"

void Grafo::generarGrafoDobleAvion(ListaAvion *lstAvion)
{
    string acum = "digraph G{\n node [shape=box]; \n compound=true; \n";
    acum += lstAvion->acumLstDoble();
    acum += "\n}\n";

    generarGrafo("ListaAvion",acum);
}

void Grafo::generarGrafo(string nombre, string info)
{
    string nombreArchivo = nombre + ".dot";
    ofstream fs(nombreArchivo);
    fs << info <<endl;
    fs.close();
    string archivo = "dot -Tpng " + nombreArchivo +" -o " + nombre + ".png";
    system(archivo.c_str());
}

Grafo::Grafo()
{

}
