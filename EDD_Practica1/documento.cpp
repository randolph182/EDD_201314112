#include "documento.h"

NodoDocumento::NodoDocumento(Documento *valor_)
{
    siguiente = NULL;
    valor = valor_;
}

Documento::Documento()
{

}

void ListaDocumento::addPila(Documento *valor, string id)
{
    NodoDocumento *nuevo = new NodoDocumento(valor);
    if(primero == NULL)
    {
        primero = nuevo;
        size++;
        nuevo->idNodo = "docu"+id;
        valor->idPasajero = id;
    }
    else
    {
        nuevo->siguiente = primero;
        primero = nuevo;
        size++;
        nuevo->idNodo = "docu"+id;
        valor->idPasajero = id;
    }
}

string ListaDocumento::acumPila(string idCluster)
{
//    string acum = "subgraph cluster"+idCluster+"{\n";
//    string acumNodo = "";
//    string acumEnlace = "";

//    NodoDocumento *tmp = primero;
//    while(tmp->siguiente !=NULL)
//    {
//        acumNodo += tmp->idNodo + "[label=\" idPasajero: "+ tmp->valor->idPasajero+"\n";

//        acumNodo +=  "\"];\n";

//        acumEnlace += tmp->idNodo+"->"+ tmp->siguiente->idNodo + ";\n";
//        tmp = tmp->siguiente;
//    }
//    acumNodo += tmp->idNodo + "[label=\" idPasajero: "+ tmp->valor->idPasajero+"\n";

//    acumNodo +=  "\"];\n";

//    acum += acumNodo + acumEnlace  + "\n}\n";

    string acum = "";

    if(primero!=NULL)
    {
        acum += primero->idNodo + "[label=\" No. Doc: "+ to_string(size)+"\"];\n";
    }

    return acum;
}

bool ListaDocumento::desapilarTodo()
{

//    if(primero !=NULL)
//    {
//        if(primero->siguiente !=NULL)
//        {
//            primero = primero->siguiente;
//            size--;
//            return true;
//        }
//        else
//        {
//            primero = NULL;
//            size--;
//            return true;
//        }
        while(primero!=NULL)
        {
            if(primero->siguiente!=NULL)
            {
                primero = primero->siguiente;
                size--;
            }
            else
            {
                primero = NULL;
                size--;
                return true;
            }


        }
//        return false
//        primero = NULL;
//        size--;
//        return true;
//    }
//    else
//    {
//        return false;
//    }
}


