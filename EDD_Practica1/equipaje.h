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
    string idNodo;
};

struct ListaEquipaje
{
    NodoEquipaje *primero;
    NodoEquipaje *ultimo;
    int size = 0;
    void addCircularDoble(Equipaje *valor_, string idCliente);
    void quitarCircDoble(int cant);
    string acumCircularDob();

};

struct Equipaje
{
public:
    string idCliente;
    Equipaje();
    Equipaje(int idCliente_);
};

#endif // EQUIPAJE_H
