#ifndef DOCUMENTO_H
#define DOCUMENTO_H
#include <QString>
#include <iostream>
#include <string>
using namespace std;

typedef struct NodoDocumento NodoDocumento;
typedef struct ListaDocumento ListaDocumento;
typedef struct Documento Documento;

struct NodoDocumento
{
public:
    NodoDocumento *siguiente;
    Documento *valor;
    string idNodo;
    NodoDocumento(Documento *valor_);
};

struct ListaDocumento
{
public:
    NodoDocumento *primero;
    int size;
    void addPila(Documento *valor,string id);
    string acumPila(string idCluster);
    bool desapilarTodo();
};

struct Documento
{
public:
    string idPasajero;

    Documento();
};

#endif // DOCUMENTO_H
