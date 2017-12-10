#ifndef LISTA_H
#define LISTA_H
#include "nodo.h"
#include <iostream>
#include <avion.h>

typedef struct Lista Lista;
typedef struct LstAvion LstAvion;

struct Lista
{
public:
    Nodo *primero;
    Nodo *ultimo;
    Lista();
};

struct LstAvion: public Lista
{
    void addColaDoble(Avion *nuevoAvion);
};

#endif // LISTA_H
