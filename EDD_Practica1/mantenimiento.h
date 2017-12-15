#ifndef MANTENIMIENTO_H
#define MANTENIMIENTO_H
#include <iostream>
#include "avion.h"

typedef struct NodoMantenimiento NodoMantenimiento;
typedef struct ListaMantenimiento ListaMantenimiento;
typedef struct Mantenimiento Mantenimiento;

struct NodoMantenimiento
{
    NodoMantenimiento *siguiente;
    Mantenimiento * valor;
    ListaAvion *lstAvion;
    string idNodo;
    NodoMantenimiento();
    NodoMantenimiento(Mantenimiento *valor_);
};

struct ListaMantenimiento
{
    NodoMantenimiento *primero;
    NodoMantenimiento *ultimo;
    int size;
    int contNodo= 0;
    void addSimple(Mantenimiento *valor_,string id);
    string acumLstSmple();

};

struct Mantenimiento
{
public:
    int idMantenimiento;
    Mantenimiento();
};

#endif // MANTENIMIENTO_H
