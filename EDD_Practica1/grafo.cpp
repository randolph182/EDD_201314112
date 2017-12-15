#include "grafo.h"

void Grafo::generarGrafoDobleAvion(ListaAvion *lstAvion)
{
    string acum = "digraph G{\n rankdir = LR;\nnode [shape=box]; \n compound=true; \n";
    acum += lstAvion->acumLstDoble();
    acum += "\n}\n";

    generarGrafo("ListaAvion",acum);
}

void Grafo::generarGrafoColaPasajero(ListaPasajero *lstPasajero)
{
    string acum  = "digraph G{\nnode [shape=box]; \n compound=true; \n";
    acum += lstPasajero->acumLstSimplePasajero("pasajero");
    acum += "\n}\n";
    generarGrafo("colaEspPasajero",acum);
}

void Grafo::generarGrafoEscritorios(ListaEscritorio *lstEscritorios)
{
//    string acum  = "digraph G{\nnode [shape=box]; \nrankdir = TB;\n compound=true; \n";
    string acum  = "digraph G{\nnode [shape=box];\n";
    acum += lstEscritorios->acumDobleEscritorio();
    acum += "\n}\n";
    generarGrafo("lstEscritorios",acum);
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

void Grafo::generarGrafoMantenimiento(ListaMantenimiento *lstMantenimiento)
{
    string acum  = "digraph G{\nnode [shape=box];\n";
    acum += lstMantenimiento->acumLstSmple();
    acum += "\n}\n";
    generarGrafo("lstMantenimiento",acum);
}

void Grafo::generarGrafoEquipaje(ListaEquipaje *lstEquipaje)
{
    string acum  = "digraph G{\nnode [shape=box];\n";
    acum += lstEquipaje->acumCircularDob();
    acum += "\n}\n";
    generarGrafo("lstEquipaje",acum);
}

Grafo::Grafo()
{

}
