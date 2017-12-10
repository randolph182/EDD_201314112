#ifndef NODO_H
#define NODO_H
#include <iostream>

typedef struct Nodo Nodo;

struct Nodo
{
public:
    Nodo *siguiente;
    Nodo *anterior;
    int idNodo;
    Nodo();
};


#endif // NODO_H
