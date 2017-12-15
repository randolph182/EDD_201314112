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

void ListaPasajero::encolarSimple(Pasajero *pasajero,string id)
{
    NodoPasajero *nuevo = new NodoPasajero(pasajero);

    if(primero == NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        contNodo++;
        nuevo->idNodo = id + to_string(contNodo);
        pasajero->idPasajero  = contNodo;
    }
    else
    {
        /*En este los datos primeros que van entrando son los que van saliendo
          Entonces en vez de ir ingresando por el primero los nuevos datos se van de ultimo*/
        ultimo->siguiente = nuevo;
        ultimo = nuevo;
        size++;
        contNodo++;
        nuevo->idNodo = id +to_string(contNodo);
        pasajero->idPasajero = contNodo;
    }
}

string ListaPasajero::acumLstSimplePasajero(string idCluster)
{
     string acum ="";
    if(primero !=NULL)
    {
       acum += "subgraph cluster"+idCluster+"{\n";
        string acumNodo = "";
        string acumEnlace = "";
        NodoPasajero *tmp = primero;

        while(tmp->siguiente !=NULL)
        {
            acumNodo += tmp->idNodo + "[label=\" idPasajero: "+ to_string(tmp->valor->idPasajero)+"\n";
            acumNodo += "No.Maletas: " + to_string(tmp->valor->NoMaletas) + "\n";
            acumNodo += "No.Docum: " + to_string(tmp->valor->NoDocumetos) + "\n";
            acumNodo += "No.TurnosReg: " + to_string(tmp->valor->NoTurnosRegistro) + "\"];\n";

            acumEnlace += tmp->idNodo+"->"+ tmp->siguiente->idNodo + ";\n";
            tmp = tmp->siguiente;
        }
        acumNodo += tmp->idNodo + "[label=\" idPasajero: "+ to_string(tmp->valor->idPasajero)+"\n";
        acumNodo += "No.Maletas: " + to_string(tmp->valor->NoMaletas) + "\n";
        acumNodo += "No.Docum: " + to_string(tmp->valor->NoDocumetos) + "\n";
        acumNodo += "No.TurnosReg: " + to_string(tmp->valor->NoTurnosRegistro) + "\"];\n";

        acum += acumNodo + acumEnlace  + "\n}\n";


    }

    return acum;

}

bool ListaPasajero::desencolarSimple() //la ventaja de tener los datos al inicio es que solo se corre el puntero de Primero
{
    if(primero !=NULL)
    {

        if(primero->siguiente != NULL)
        {
            primero = primero->siguiente;
            size--;
            return true;
        }
        else
        {
            primero = NULL;
            size--;
            return true;
        }
    }
    else
    {
        return false;
    }
}
