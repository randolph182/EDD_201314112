#ifndef BIBLIOTECA_H
#define BIBLIOTECA_H
#include <stdio.h>
#define public
typedef struct Nodo
{
     public struct Nodo *siguiente;
     public struct Nodo *anterior;
    int valor;
}Nodo;

typedef struct
{
     public Nodo *primero;
     public Nodo *ultimo;
}Lista;

 Lista *listaDoble;



#endif // BIBLIOTECA_H
