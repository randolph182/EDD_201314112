#include <stdio.h>
#include <stdlib.h>
#include "Biblioteca.h"

int main()
{
    printf("Hello world!\n");
    return 0;
}

void insertar(Lista *lista, int valor)
{
    Nodo *nuevo = (Nodo*)malloc(sizeof(Nodo));
    nuevo->valor = valor;
    nuevo->siguiente = NULL;
    nuevo->anterior = NULL;
}


