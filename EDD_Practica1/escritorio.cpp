#include "escritorio.h"

Escritorio::Escritorio(char letra_)
{
    letra = letra_;
}

Escritorio::Escritorio()
{

}

NodoEscritorio::NodoEscritorio()
{
    siguiente = NULL;
    anterior = NULL;
    valor = NULL;
    lstPasajeros = new ListaPasajero();
    lstDocumento = new ListaDocumento();
}

NodoEscritorio::NodoEscritorio(Escritorio *valor_)
{
    valor = valor_;
    siguiente = NULL;
    anterior = NULL;
    lstPasajeros = new ListaPasajero();
    lstDocumento = new ListaDocumento();
}

ListaEscritorio::ListaEscritorio()
{
    primero = NULL;
    ultimo = NULL;
    size = 0;
}

void ListaEscritorio::addDoble(Escritorio *nuevo_)
{
    NodoEscritorio *nuevo  = new NodoEscritorio(nuevo_);
    \
    if(primero ==NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        nuevo->idNodo = size;
    }
    else // en esta parte se aplicaran los metodos de ordenacion
    {
       int comp = comparacion(nuevo,primero);
        if(comp >0) //significa que es mayor que el inicio por tanto el inicio se conserva y se corre el nuevo dato
        {
            if(primero->siguiente ==NULL)
            {
                primero->siguiente = nuevo;
                nuevo->anterior = primero;
                ultimo = nuevo;
                size++;
                nuevo->idNodo++;
            }
            else
            {
                if(ultimo !=NULL)
                {
                    if(comparacion(nuevo,ultimo) >0)//eso significa que el nuevo valor es mayor que el ultimo por lo tanto se agrega al final
                    {
                        ultimo->siguiente = nuevo;
                        nuevo->anterior = ultimo;
                        ultimo = nuevo;
                        size++;
                         nuevo->idNodo++;
                         return;
                    }
                }
                NodoEscritorio *tmp = primero;
                while(tmp!=NULL)
                {
                    if(comparacion(nuevo,tmp)>0) //inicio para saber si el nuevo valor esta en medio
                    {
                        if(tmp->siguiente !=NULL)
                        {
                            if(comparacion(nuevo,tmp->siguiente) < 0)
                            {
                                nuevo->anterior = tmp;
                                nuevo->siguiente = tmp->siguiente;
                                tmp->siguiente->anterior = nuevo;
                                tmp->siguiente = nuevo;
                                size++;
                                nuevo->idNodo++;
                                break;
                            }
                        }

                    }
                    tmp = tmp->siguiente;
                }

            }
        }
        else if(comp <0)
        {
            nuevo->siguiente = primero;
            primero->anterior = nuevo;
            primero = nuevo;
            size++;
            nuevo->idNodo++;
        }
        else //las letras son iguales
        {
            cout << "No se Agrego porque es la misma letra" << endl;
            return;
        }
    }
}

int ListaEscritorio::comparacion(NodoEscritorio *nuevo, NodoEscritorio *actual)
{
    char act = nuevo->valor->letra;

    if(nuevo->valor->letra > actual->valor->letra)
    {
        return 1;
    }
    else if(nuevo->valor->letra == actual->valor->letra)
    {
        return 0;
    }
    else
    {
        return -1;
    }
   // return act.(actual->valor->letra);
}

void ListaEscritorio::imprimir()
{
    if(primero !=NULL)
    {
        NodoEscritorio *tmp = primero;
        while(tmp !=NULL)
        {
            cout<<tmp->valor->letra <<endl;
            tmp = tmp->siguiente;
        }
    }
}
