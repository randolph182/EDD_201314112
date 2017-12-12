#include "documento.h"

NodoDocumento::NodoDocumento(Documento *valor_)
{
    siguiente = NULL;
    valor = valor_;
}

Documento::Documento()
{

}

void ListaDocumento::addPila(Documento *valor)
{
    NodoDocumento *nuevo = new NodoDocumento(valor);
    if(primero == NULL)
    {
        primero = nuevo;
        size++;
        nuevo->idNodo = size;
    }
    else
    {
        nuevo->siguiente = primero;
        primero = nuevo;
        size++;
        nuevo->idNodo = size;
    }
}

bool ListaDocumento::desapilarTodo()
{

    if(primero !=NULL)
    {
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
        primero = NULL;
        size--;
        return true;
    }
    else
    {
        return false;
    }
}


