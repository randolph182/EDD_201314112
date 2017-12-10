#include "pasajero.h"

Pasajero::Pasajero()
{

}

Pasajero::Pasajero(int idPasajero_, int NoMaletas_, int NoDocumentos_, int NoTurnosRegistro_)
{
    idPasajero = idPasajero_;
    NoMaletas = NoMaletas_;
    NoDocumetos = NoDocumentos_;
    NoTurnosRegistro = NoTurnosRegistro_;
}

Pasajero *Pasajero::generarPasajero()
{
    int nMaletas = 1+rand()%(5-1);
    int nDocumentos = 1+rand()%(11-1);
    int nTurnosRegistro = 1+rand()%(4-1);
    Pasajero *nuevo = new Pasajero(NULL,nMaletas,nDocumentos,nTurnosRegistro);
    return nuevo;
}

NodoPasajero::NodoPasajero()
{
    siguiente = NULL;
}

NodoPasajero::NodoPasajero(Pasajero *valor_)
{
    siguiente = NULL;
    valor = valor_;

}

ListaPasajero::ListaPasajero()
{
    primero = NULL;
    ultimo = NULL;
    size =0;
}

void ListaPasajero::encolarSimple(Pasajero *pasajero)
{
    NodoPasajero *nuevo = new NodoPasajero(pasajero);

    if(primero == NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        nuevo->idNodo = size;
        pasajero->idPasajero = size;
    }
    else
    {
        /*En este los datos primeros que van entrando son los que van saliendo
          Entonces en vez de ir ingresando por el primero los nuevos datos se van de ultimo*/
        ultimo->siguiente = nuevo;
        ultimo = nuevo;
        size++;
        nuevo->idNodo = size;
        pasajero->idPasajero = size;
    }
}

bool ListaPasajero::desencolarSimple() //la ventaja de tener los datos al inicio es que solo se corre el puntero de Primero
{
    if(primero !=NULL)
    {

        if(primero->siguiente != NULL)
        {
            primero = primero->siguiente;
            return true;
        }
        else
        {
            primero = NULL;
            return true;
        }
    }
    else
    {
        return false;
    }
}
