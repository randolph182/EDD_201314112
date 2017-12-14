#include "equipaje.h"

Equipaje::Equipaje()
{

}

Equipaje::Equipaje(int idCliente_)
{
    idCliente = idCliente_;
}

NodoEquipaje::NodoEquipaje(Equipaje *valor_)
{
    siguiente = NULL;
    anterior = NULL;
    valor = valor_;
}

NodoEquipaje::NodoEquipaje()
{
    siguiente = NULL;
    anterior = NULL;
}

void ListaEquipaje::addCircularDoble(Equipaje *valor_)
{
    NodoEquipaje *nuevo = new NodoEquipaje(valor_);
    if(primero ==NULL && ultimo ==NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        primero->siguiente = ultimo;
        ultimo->anterior = primero;
        ultimo->siguiente= primero;
        primero->anterior = ultimo;
        size++;
        nuevo->idNodo++;
    }
    else if(primero !=NULL && ultimo ==NULL)
    {
        ultimo = nuevo;
        primero->siguiente = ultimo;
        ultimo->anterior = primero;
        ultimo->siguiente= primero;
        primero->anterior = ultimo;
        size++;
        nuevo->idNodo++;
    }
    else
    {
        ultimo->siguiente = nuevo;
        nuevo->anterior = ultimo;
        nuevo->siguiente = primero;
        primero->anterior = nuevo;
        ultimo = nuevo;
        size++;
        nuevo->idNodo++;
    }
}

void ListaEquipaje::quitarCircDoble(int cant)
{
    if(cant >0)
    {
        if(primero->siguiente !=ultimo && primero->siguiente !=NULL)
        {
            ultimo = ultimo->anterior;
            ultimo->siguiente = primero;
            primero->anterior = ultimo;
            size--;
            quitarCircDoble(cant-1);
        }
        else if(primero->siguiente == NULL)
        {
            primero = NULL;
            size--;
        }
        else if(primero->siguiente = ultimo)
        {
            ultimo = NULL;
            primero->siguiente = NULL;
            size--;
            quitarCircDoble(cant-1);
        }
    }

}
