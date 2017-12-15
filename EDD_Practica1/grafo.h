#ifndef GRAFO_H
#define GRAFO_H

#include <fstream>
#include <iostream>
#include "avion.h"
#include "pasajero.h"
#include "escritorio.h"
#include "mantenimiento.h"
#include "equipaje.h"

using namespace std;

typedef struct Grafo Grafo;

struct Grafo
{
public:
    void generarGrafoDobleAvion(ListaAvion *lstAvion);
    void generarGrafoColaPasajero(ListaPasajero *lstPasajero);
    void generarGrafoEscritorios(ListaEscritorio *lstEscritorios);
    void generarGrafo(string nombre,string info);
    void generarGrafoMantenimiento(ListaMantenimiento *lstMantenimiento);
    void generarGrafoEquipaje(ListaEquipaje * lstEquipaje);
    Grafo();
};

#endif // GRAFO_H
