#include "equipaje.h"

Equipaje::Equipaje()
{

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
    if(primero ==NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
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
    if(cant <=size)
    {

    }
    else
    {
        cout << "La cantidad de maletas es inferior a la actual por tanto ha de haber algo mal " <<endl;
    }
}
