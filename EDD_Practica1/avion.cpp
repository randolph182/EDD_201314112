#include "avion.h"

Avion::Avion()
{

}

Avion::Avion(int idAvion,string tipoAvionStr_, int tipoAvion, int nPasajros, int nTurnos, int nMantenimiento)
{
    this->idAvion =idAvion;
    this->tipoAvionStr = tipoAvionStr_;
    this->tipoAvion = tipoAvion;
    this->NoPasajeros = nPasajros;
    this->NoTurnos = nTurnos;
    this->NoTurnosMantenimiento = nMantenimiento;
}

Avion *Avion::generarAvion()
{
   int tipoAvion = rand()%3; /* rango de 0  a 2 donde: 0 = avion pequenio, 1 = avion medio, 2 = avion grande*/
   string tAv="";
   int nTurnos = NULL;
   int nPasajeros = NULL;
   int nTurnosMantenimiento = NULL;

   if(tipoAvion == 0) /* si el avion es pequenio*/
   {
       tAv = "pequenio";
       nTurnos = 1;
       nPasajeros = 5+rand()%(11-5); /* pasajeros entre 5 a 10*/
       nTurnosMantenimiento = 1+rand()%(4-1); /* mantenimiento entre 1 a 3*/
   }
   else if(tipoAvion == 1) //si el avion es mediano
   {
       tAv = "mediano";
       nTurnos = 2;
       nPasajeros = 15+rand()%(26-15); /* pasajeros entre 15 al 25*/
       nTurnosMantenimiento = 2+rand()%(5-2); /* mantenimiento entre 2 a 4*/
   }
   else /* sino el avion es grande*/
   {
       tAv = "grande";
       nTurnos = 3;
       nPasajeros = 30+rand()%(41-30); /* pasajeros entre 30 a 40*/
       nTurnosMantenimiento = 3+rand()%(7-3); /* Mantenimiento entre 3 al 6*/
   }

   Avion *nuevo = new Avion(NULL,tAv,tipoAvion,nPasajeros,nTurnos,nTurnosMantenimiento);
   return nuevo;


}
NodoAvion::NodoAvion()
{
    siguiente = NULL;
    anterior = NULL;
}

NodoAvion::NodoAvion(Avion *valor)
{
    this->valor = valor;
    siguiente = NULL;
    anterior = NULL;

}

ListaAvion::ListaAvion()
{
    primero =NULL;
    ultimo = NULL;
    int size = 0;
}

void ListaAvion::encolarDoble(Avion *avion)
{
    NodoAvion *nuevo = new NodoAvion(avion);

    if(primero == NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        contNodo++;
        nuevo->idNodo = contNodo;
        avion->idAvion = contNodo;
    }
    else //como es una cola el objetivo es ir agregando al inicio e ir sacando deade el ultimo
    {
        ultimo->siguiente = nuevo;
        nuevo->anterior = ultimo;
        ultimo = nuevo;
        size++;
        contNodo++;
        nuevo->idNodo = contNodo;
        avion->idAvion = contNodo;
    }
}

void ListaAvion::encolarSimple(Avion *avion)
{
    NodoAvion *nuevo = new NodoAvion(avion);
    if(primero ==NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        nuevo->idNodo++;
        avion->idAvion++;
    }
    else
    {
        ultimo->siguiente = nuevo;
        ultimo = nuevo;
        size++;
        nuevo->idNodo++;
        avion->idAvion++;
    }
}

string ListaAvion::acumLstDoble()
{
    string acum = "";
    string nodos = "";
    string enlaces = "";
    //sacando enlaces desde la primera posicion a la ultima
    NodoAvion *tmp = primero;
    while(tmp->siguiente != NULL)
    {
        nodos += to_string(tmp->idNodo)+"[label=\"Avion: "+ to_string(tmp->idNodo)+ "\n";  //+"\"];\n";
        nodos += "tipo: "+tmp->valor->tipoAvionStr+"\n";
        nodos += "No.Pasajeros: "+to_string(tmp->valor->NoPasajeros)+"\n";
        nodos += "No.Turnos: "+to_string(tmp->valor->NoTurnos)+"\n";
        nodos += "No.Mantmto: "+to_string(tmp->valor->NoTurnosMantenimiento)+"\"];\n";

        enlaces += to_string(tmp->idNodo) + "->" + to_string(tmp->siguiente->idNodo) + ";\n";
        tmp = tmp->siguiente;
    }
    nodos += to_string(tmp->idNodo)+"[label=\"Avion: "+ to_string(tmp->idNodo)+ "\n";  //+"\"];\n";
    nodos += "tipo: "+tmp->valor->tipoAvionStr+"\n";
    nodos += "No.Pasajeros: "+to_string(tmp->valor->NoPasajeros)+"\n";
    nodos += "No.Turnos: "+to_string(tmp->valor->NoTurnos)+"\n";
    nodos += "No.Mantmto: "+to_string(tmp->valor->NoTurnosMantenimiento)+"\"];\n";

//    /sacando enlaces desde la primera posicion a la ultima
    NodoAvion *tmp2 = ultimo;
    while(tmp2->anterior !=NULL)
    {
        enlaces += to_string(tmp2->idNodo)+ "->"+to_string(tmp2->anterior->idNodo)+ ";\n";
        tmp2 = tmp2->anterior;
    }
    acum += nodos + enlaces;
    return acum;
}

bool ListaAvion::desencolarSimple()
{
    if(primero !=NULL)
    {
        if(primero->siguiente !=NULL)
        {
            primero = primero->siguiente;
            size--;
            return true;
        }
        else
        {
            primero = NULL;
            size--;
            return true;
        }
    }
    return false;
}

bool ListaAvion::desencolarDoble()
{
    if(ultimo !=NULL)
    {
        if(ultimo->anterior !=NULL)
        {
            ultimo = ultimo->anterior;
            ultimo->siguiente = NULL;
            size--;
            return true;
        }
        else
        {
            ultimo = NULL;
            size--;
            return true;
        }
    }
    else
    {
        //QMessageBox::information(NULL,"Error","No quedan mas elementos en la Cola doble del avion");
        return false;
    }
}


