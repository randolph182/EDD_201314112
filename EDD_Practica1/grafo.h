#ifndef GRAFO_H
#define GRAFO_H

#include <fstream>
#include <iostream>
#include "avion.h"

using namespace std;

typedef struct Grafo Grafo;

struct Grafo
{
public:
    void generarGrafoDobleAvion(ListaAvion *lstAvion);
    void generarGrafo(string nombre,string info);
    Grafo();
};

#endif // GRAFO_H
