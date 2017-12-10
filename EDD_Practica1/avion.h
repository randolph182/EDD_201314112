#ifndef AVION_H
#define AVION_H
#include <QString>
#include <QMessageBox>
//librerias para la generacion de numeros aleatorios
#include <stdlib.h>
#include <time.h>
#include <cstdlib>


typedef struct NodoAvion NodoAvion;
typedef struct ListaAvion ListaAvion;
typedef struct Avion Avion;

using namespace std;

struct NodoAvion
{
public:
    NodoAvion *siguiente;
    NodoAvion *anterior;
    int idNodo;
    Avion *valor;
    NodoAvion();
    NodoAvion(Avion *valor);
};

struct ListaAvion
{
public:
    NodoAvion *primero;
    NodoAvion *ultimo;
    int size;
    ListaAvion();
    void encolarDoble(Avion *avion); //el avion utiliza una cola doble
    bool desencolarDoble();
};

struct Avion
{
public:
    Avion();
    Avion(int idAvion,int tipoAvion,int nPasajros, int nTurnos, int nMantenimiento);
    int idAvion;
    int tipoAvion;
    int NoPasajeros;
    int NoTurnos;
    int NoTurnosMantenimiento;
    Avion *generarAvion();
};

#endif // AVION_H
