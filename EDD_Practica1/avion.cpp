#include "avion.h"

Avion::Avion()
{

}
NodoAvion::NodoAvion()
{
    siguiente = NULL;
    anterior = NULL;
}

NodoAvion::NodoAvion(Avion *valor)
{
    this->valor = valor;
    siguiente = NULL;
    anterior = NULL;

}

void ListaAvion::addColaDoble(Avion *avion)
{
    NodoAvion *nuevo = new NodoAvion(avion);

    if(primero == NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        nuevo->idNodo = size;
    }
    else //como es una cola el objetivo es ir agregando al inicio e ir sacando deade el ultimo
    {
        nuevo->siguiente = primero;
        primero->anterior = nuevo;
        primero = nuevo;
        nuevo->idNodo = size;
        size++;
    }
}


