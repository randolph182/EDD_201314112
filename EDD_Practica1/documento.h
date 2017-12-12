#ifndef DOCUMENTO_H
#define DOCUMENTO_H

typedef struct NodoDocumento NodoDocumento;
typedef struct ListaDocumento ListaDocumento;
typedef struct Documento Documento;

struct NodoDocumento
{
public:
    NodoDocumento *siguiente;

    Documento *valor;
};

struct ListaDocumento
{
public:

};

struct Documento
{
public:
    Documento();
};

#endif // DOCUMENTO_H
