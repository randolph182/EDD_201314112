#include <stdio.h>
#include <stdlib.h>
#include "Biblioteca.h"

int main()
{
    //printf("Hello world!\n");


    Lista *lstDoble = (Lista*)malloc(sizeof(Lista));
    lstDoble->primero = NULL;
    lstDoble->ultimo = NULL;

    insertar(lstDoble,3);
    insertar(lstDoble,1);
    insertar(lstDoble,2);
    mostrar(lstDoble);
     return 0;
}

void insertar(Lista *lista, int valor)
{
    Nodo *nuevo = (Nodo*)malloc(sizeof(Nodo));
    nuevo->valor = valor;
    nuevo->siguiente = NULL;
    nuevo->anterior = NULL;

    if(lista->primero == NULL)
    {
        lista->primero = nuevo;
        lista->ultimo = nuevo;
    }
    else
    {
       lista->ultimo->siguiente = nuevo;
       nuevo->anterior = lista->ultimo;
       lista->ultimo = nuevo;
    }
}

void mostrar(Lista *lista)
{
    if(lista->primero !=NULL)
    {
        Nodo *tmp = lista->primero;
        while(tmp !=NULL)
        {
            //printf(tmp->valor);
            printf("numero: %i\n", tmp->valor);
            tmp = tmp->siguiente;
        }
    }
    else
    {
        printf("No Hay elementos en la lista");
    }



}


