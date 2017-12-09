#include <stdio.h>
#include <stdlib.h>
#include "Biblioteca.h"

int main()
{
    Lista *lstDoble = (Lista*)malloc(sizeof(Lista));
    lstDoble->primero = NULL;
    lstDoble->ultimo = NULL;
    int opcion =0;
    do
    {
        printf("\n\nMenu:\n");
        printf("1) Aniadir elementos\n");
        printf("2) Eliminar elementos\n");
        printf("3) Mostrar elementos\n");
        printf("4) Salir\n");
        printf("Escoja una Opcion.\n");
        scanf("%i", &opcion);

        switch(opcion)
        {
            case 1:
                printf("opcion de aniadir elementos\nEscriba el nuevo numero: ");
                int numero = NULL;
                    scanf("%i",&numero);
                if(numero !=NULL)
                {
                    insertar(lstDoble,numero);
                }
                else{
                printf("Erro: El elemento debe se un numero\n");
                }
            break;


            case 2:
                printf("opcion de aniadir elementos\nEscriba el numero que desea eliminar: ");
                numero =  NULL;
                scanf("%i",&numero);
                if(numero !=NULL)
                {
                    eliminar(lstDoble, numero);
                }
                else{
                    printf("Error: El elemento debe ser numero \n");
                }
            break;

            case 3:
                mostrar(lstDoble);
            break;

            default:
                printf("La Seleccion no es valida.\n");
            break;
        }

    }while(opcion != 4);

    insertar(lstDoble,3);
    insertar(lstDoble,1);
    insertar(lstDoble,2);
    mostrar(lstDoble);
     return 0;
}

void insertar(Lista *lista, int valor) //la manera de insercion es en la ultima posicion de la lista
{
    Nodo *nuevo = (Nodo*)malloc(sizeof(Nodo));
    nuevo->valor = valor;
    nuevo->siguiente = NULL;
    nuevo->anterior = NULL;

    if(lista->primero == NULL)
    {
        lista->primero = nuevo;
        lista->ultimo = nuevo;
        printf("\n numero agregado.\n");
    }
    else
    {
       lista->ultimo->siguiente = nuevo;
       nuevo->anterior = lista->ultimo;
       lista->ultimo = nuevo;
       printf("\n numero agregado.\n");
    }
}

void eliminar(Lista *lista, int valor)
{
    if(lista->primero !=NULL)
    {
        //comprobando si esta al inicio de la pila
        if(lista->primero->valor == valor)
        {
            if(lista->primero->siguiente !=NULL) //compruebo que hayan mas elementos para ejecutar esta accion
            {
                lista->primero = lista->primero->siguiente;
                lista->primero->anterior = NULL;
                printf("elemento eliminado en la primero posicion.");
            }
            else
            {
                lista->primero = NULL;
                printf("elemento eliminado en la primero posicion.");
            }
        }
        else if(lista->ultimo->valor == valor) //comprobando si esta al final de la lista
        {
            if(lista->ultimo->anterior !=NULL)
            {
                lista->ultimo = lista->ultimo->anterior;
                 lista->ultimo->siguiente = NULL;
                 printf("elemento eliminado en la ultima posicion.");
            }
            else
            {
                lista->ultimo = NULL;
                printf("elemento eliminado en la ultima posicion.");
            }
        }
        else //sino ha de estar en medio dela lista
        {
            Nodo *tmp = lista->primero;
            while(tmp !=NULL)
            {
                if(tmp->valor == valor)
                {
                    tmp->anterior->siguiente = tmp->siguiente;
                    tmp->siguiente->anterior = tmp->anterior;
                    printf("elemento eliminado");
                    return;
                }
                tmp = tmp->siguiente;
            }
                printf("El numero no existe.");
        }


    }
    else
    {
        printf("No se pueden  eliminar elementos de la lista porque esta vacia \n");
    }
}

void mostrar(Lista *lista)
{
    if(lista->primero !=NULL)
    {
        Nodo *tmp = lista->primero;
        while(tmp !=NULL)
        {
            printf("\nnumero: %i\n", tmp->valor);
            tmp = tmp->siguiente;
        }
    }
    else
    {
        printf("No Hay elementos en la lista");
    }
}


