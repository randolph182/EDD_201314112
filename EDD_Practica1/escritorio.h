#ifndef ESCRITORIO_H
#define ESCRITORIO_H
#include "pasajero.h"
#include "documento.h"

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
    ListaDocumento *lstDocumento;
    int idNodo;
    int contPasajero;
    int maximoPasajero =10;
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
    void addDoble(Escritorio *nuevo_);
    int comparacion(NodoEscritorio *nuevo, NodoEscritorio *actual);
    void imprimir();
};

struct Escritorio
{
public:
    char letra;
    Escritorio(char letra_);
    Escritorio();
};

#endif // ESCRITORIO_H
