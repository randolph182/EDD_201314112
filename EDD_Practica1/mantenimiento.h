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
    int idNnodo;
    NodoMantenimiento();
    NodoMantenimiento(Mantenimiento *valor_);
};

struct ListaMantenimiento
{
    NodoMantenimiento *primero;
    NodoMantenimiento *ultimo;
    int size;
    void addSimple(Mantenimiento *valor_);

};

struct Mantenimiento
{
public:
    Mantenimiento();
};

#endif // MANTENIMIENTO_H
