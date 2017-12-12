#ifndef ESCRITORIO_H
#define ESCRITORIO_H
#include "pasajero.h"

typedef struct NodoEscritorio NodoEscritorio;
typedef struct ListaEscritorio ListaEscritorio;
typedef struct Escritorio Escritorio;

struct NodoEscritorio
{
public:
    NodoEscritorio *siguiente;
    NodoEscritorio *anterior;
    Escritorio *valor;
    ListaPasajero *lstPasajeros;
    int idNodo;
    NodoEscritorio();
    NodoEscritorio(Escritorio *valor_);
};

struct ListaEscritorio
{
public:
    NodoEscritorio *primero;
    NodoEscritorio *ultimo;
    int size;
    ListaEscritorio();
    void addDoble(Escritorio *nuevo);
};

struct Escritorio
{
public:

    string letra;
    Escritorio();
};

#endif // ESCRITORIO_H
