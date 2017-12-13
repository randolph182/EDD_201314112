#include "mantenimiento.h"

Mantenimiento::Mantenimiento()
{

}

NodoMantenimiento::NodoMantenimiento()
{
    siguiente = NULL;
    lstAvion = new ListaAvion();
}

NodoMantenimiento::NodoMantenimiento(Mantenimiento *valor_)
{
    siguiente = NULL;
    lstAvion = new ListaAvion();
    valor = valor_;
}

void ListaMantenimiento::addSimple(Mantenimiento *valor_)
{
    NodoMantenimiento *nuevo = new NodoMantenimiento(valor_);
    if(primero ==NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        nuevo->idNnodo++;
    }
    else
    {
        ultimo->siguiente = nuevo;
        ultimo = nuevo;
        size++;
        nuevo->idNnodo++;
    }
}
