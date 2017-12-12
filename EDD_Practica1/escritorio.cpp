#include "escritorio.h"

Escritorio::Escritorio()
{

}

NodoEscritorio::NodoEscritorio()
{
    siguiente = NULL;
    anterior = NULL;
    valor = NULL;
    lstPasajeros = NULL;
}

NodoEscritorio::NodoEscritorio(Escritorio *valor_)
{
    valor = valor_;
    siguiente = NULL;
    anterior = NULL;
    lstPasajeros = NULL;
}

ListaEscritorio::ListaEscritorio()
{
    primero = NULL;
    ultimo = NULL;
    size = 0;
}

void ListaEscritorio::addDoble(Escritorio *nuevo)
{

}
