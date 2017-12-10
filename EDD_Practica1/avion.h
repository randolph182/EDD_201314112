#ifndef AVION_H
#define AVION_H
#include <QString>
typedef struct NodoAvion NodoAvion;
typedef struct ListaAvion ListaAvion;
typedef struct Avion Avion;


struct NodoAvion
{
public:
    NodoAvion *siguiente;
    NodoAvion *anterior;
    Avion *valor;
    int idNodo;
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
    void addColaDoble(Avion *avion);
};

struct Avion
{
public:
    Avion();
    QString tipo;
    int NoPasajeros;
    int NoTurnos;
    int NoTurnosMantenimiento;
};

#endif // AVION_H
