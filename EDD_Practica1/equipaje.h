#ifndef EQUIPAJE_H
#define EQUIPAJE_H
#include <iostream>

typedef struct NodoEquipaje NodoEquipaje;
typedef struct ListaEquipaje ListaEquipaje;
typedef struct Equipaje Equipaje;

using namespace std;
struct NodoEquipaje
{
    NodoEquipaje *siguiente;
    NodoEquipaje *anterior;
    Equipaje *valor;
    NodoEquipaje(Equipaje *valor_);
    NodoEquipaje();
    int idNodo;
};

struct ListaEquipaje
{
    NodoEquipaje *primero;
    NodoEquipaje *ultimo;
    int size;
    void addCircularDoble(Equipaje *valor_);
    void quitarCircDoble(int cant);

};

struct Equipaje
{
public:
    int idCliente;
    Equipaje();
    Equipaje(int idCliente_);
};

#endif // EQUIPAJE_H
