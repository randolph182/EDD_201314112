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

void ListaEquipaje::addCircularDoble(Equipaje *valor_, string idCliente)
{
    NodoEquipaje *nuevo = new NodoEquipaje(valor_);
    if(primero ==NULL )
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        nuevo->idNodo = "idMaleta"+idCliente;
        valor_->idCliente = idCliente;
    }
    else
    {
        ultimo->siguiente = nuevo;
       nuevo->anterior = ultimo;
       nuevo->siguiente = primero;
       primero->anterior = nuevo;
       ultimo = nuevo;
        size++;
        nuevo->idNodo = "idMaleta"+idCliente;
        valor_->idCliente = idCliente;
    }
//    if(primero ==NULL && ultimo ==NULL)
//    {
//        primero = nuevo;
//        ultimo = nuevo;
//        primero->siguiente = ultimo;
//        ultimo->anterior = primero;
//        ultimo->siguiente= primero;
//        primero->anterior = ultimo;
//        size++;
//        nuevo->idNodo = "idMaleta"+to_string(idCliente);
//        valor_->idCliente = idCliente;
//    }
//    else if(primero !=NULL && ultimo ==NULL)
//    {
//        ultimo = nuevo;
//        primero->siguiente = ultimo;
//        ultimo->anterior = primero;
//        ultimo->siguiente= primero;
//        primero->anterior = ultimo;
//        size++;
//        nuevo->idNodo = "idMaleta"+to_string(idCliente);
//        valor_->idCliente = idCliente;
//    }
//    else
//    {
//        ultimo->siguiente = nuevo;
//        nuevo->anterior = ultimo;
//        nuevo->siguiente = primero;
//        primero->anterior = nuevo;
//        ultimo = nuevo;
//        size++;
//        nuevo->idNodo = "idMaleta"+to_string(idCliente);
//        valor_->idCliente = idCliente;
//    }
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

string ListaEquipaje::acumCircularDob()
{
    string acum = "";
    if(primero!=NULL)
    {
         acum += "subgraph clusterMaletaPasajero{\n";
        string acumNodo = "";
        string acumEnlace  = "";

        NodoEquipaje *tmp = primero;
        do
        {
            acumNodo += tmp->idNodo+"[label=\"Maleta: " +tmp->valor->idCliente + "\"];\n";
            acumEnlace += tmp->idNodo +"->"+tmp->siguiente->idNodo + ";\n";
            tmp = tmp->siguiente;
        }while(tmp->siguiente != primero);

        acumNodo += tmp->idNodo+"[label=\"Maleta: " + tmp->valor->idCliente + "\"];\n";
        acumEnlace += tmp->idNodo +"->"+tmp->siguiente->idNodo + ";\n";

        NodoEquipaje *tmp2 = ultimo;
        do
        {
            acumEnlace += tmp2->idNodo +"->"+tmp2->anterior->idNodo + ";\n";
            tmp2 = tmp2->anterior;
        }while(tmp2->anterior != ultimo);
        acumEnlace += tmp2->idNodo +"->"+tmp2->anterior->idNodo + ";\n";

       // acumEnlace +="\n}\n";

        acum += acumNodo  + acumEnlace +  "}\n" ;
    }

    return acum;
}
