#ifndef AVION_H
#define AVION_H
#include <QString>
#include <QMessageBox>
#include <string>
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
    string idNodo;
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
    int contNodo =0;
    ListaAvion();
    void encolarDoble(Avion *avion, string id); //el avion utiliza una cola doble
    void encolarSimple(Avion *avion, string id);
    string acumLstDoble();
    string acumLstSmple(string idCluster);
    bool desencolarSimple();
    bool desencolarDoble();
};

struct Avion
{
public:
    Avion();
    Avion(int idAvion,string tipoAvionStr_,int tipoAvion,int nPasajros, int nTurnos, int nMantenimiento);
    int idAvion;
    int tipoAvion;
    string tipoAvionStr;
    int NoPasajeros;
    int NoTurnos;
    int NoTurnosMantenimiento;
    Avion *generarAvion();
};

#endif // AVION_H
