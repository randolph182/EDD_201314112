#ifndef PASAJERO_H
#define PASAJERO_H
#include <iostream>
#include <QMessageBox>
#include <QString>


using namespace std;

typedef struct Pasajero Pasajero;
typedef struct NodoPasajero NodoPasajero;
typedef struct ListaPasajero ListaPasajero;

struct NodoPasajero
{
    NodoPasajero *siguiente;
    Pasajero *valor;
    int idNodo;

    NodoPasajero();
    NodoPasajero(Pasajero *valor_);
};

struct ListaPasajero
{
    NodoPasajero *primero;
    NodoPasajero *ultimo;
    int size;
    ListaPasajero();
    void encolarSimple(Pasajero *pasajero);
    bool desencolarSimple();
};

struct Pasajero
{
public:
    int idPasajero;
    int NoMaletas;
    int NoDocumetos;
    int NoTurnosRegistro;
    Pasajero();
    Pasajero(int idPasajero_, int NoMaletas_,int NoDocumentos_,int NoTurnosRegistro_);
    Pasajero *generarPasajero();

};

#endif // PASAJERO_H
