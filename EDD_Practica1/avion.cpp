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

void ListaAvion::encolarDoble(Avion *avion,string id)
{
    NodoAvion *nuevo = new NodoAvion(avion);

    if(primero == NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        contNodo++;
        nuevo->idNodo = id+to_string(contNodo);
        avion->idAvion = contNodo;
    }
    else //como es una cola el objetivo es ir agregando al inicio e ir sacando deade el ultimo
    {
        ultimo->siguiente = nuevo;
        nuevo->anterior = ultimo;
        ultimo = nuevo;
        size++;
        contNodo++;
        nuevo->idNodo = id +to_string(contNodo);
        avion->idAvion = contNodo;
    }
}

void ListaAvion::encolarSimple(Avion *avion,string id)
{
    NodoAvion *nuevo = new NodoAvion(avion);
    if(primero ==NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        contNodo++;
        nuevo->idNodo = id + to_string(contNodo);
        avion->idAvion = contNodo;
    }
    else
    {
        ultimo->siguiente = nuevo;
        ultimo = nuevo;
        size++;
        contNodo++;
        nuevo->idNodo = id + to_string(contNodo);
        avion->idAvion = contNodo;
    }
}

string ListaAvion::acumLstDoble()
{
    string acum = "";

    if(primero!=NULL)
    {
        string nodos = "";
        string enlaces = "";
        //sacando enlaces desde la primera posicion a la ultima
        NodoAvion *tmp = primero;
        while(tmp->siguiente != NULL)
        {
            nodos += tmp->idNodo+"[label=\"Avion: "+ to_string(tmp->valor->idAvion)+ "\n";  //+"\"];\n";
            nodos += "tipo: "+tmp->valor->tipoAvionStr+"\n";
            nodos += "No.Pasajeros: "+to_string(tmp->valor->NoPasajeros)+"\n";
            nodos += "No.Turnos: "+to_string(tmp->valor->NoTurnos)+"\n";
            nodos += "No.Mantmto: "+to_string(tmp->valor->NoTurnosMantenimiento)+"\"];\n";

            enlaces += tmp->idNodo + "->" + tmp->siguiente->idNodo + ";\n";
            tmp = tmp->siguiente;
        }
        nodos += tmp->idNodo+"[label=\"Avion: "+ to_string(tmp->valor->idAvion)+ "\n";  //+"\"];\n";
        nodos += "tipo: "+tmp->valor->tipoAvionStr+"\n";
        nodos += "No.Pasajeros: "+to_string(tmp->valor->NoPasajeros)+"\n";
        nodos += "No.Turnos: "+to_string(tmp->valor->NoTurnos)+"\n";
        nodos += "No.Mantmto: "+to_string(tmp->valor->NoTurnosMantenimiento)+"\"];\n";

    //    /sacando enlaces desde la primera posicion a la ultima
        NodoAvion *tmp2 = ultimo;
        while(tmp2->anterior !=NULL)
        {
            enlaces += tmp2->idNodo+ "->"+tmp2->anterior->idNodo+ ";\n";
            tmp2 = tmp2->anterior;
        }
        acum += nodos + enlaces;
    }

    return acum;
}

string ListaAvion::acumLstSmple(string idCluster)
{

    string acum = "subgraph cluster"+idCluster+"{\n";
    string acumNodo = "";
//    string acumEnlace = " {rank = same;\n";
    string acumEnlace = "";

    NodoAvion *tmp = primero;
    while(tmp->siguiente !=NULL)
    {
        acumNodo +=  tmp->idNodo+"[label=\"Avion: "+ to_string(tmp->valor->idAvion)+ "\n";
        acumNodo += "tipo: "+tmp->valor->tipoAvionStr+"\n";
        acumNodo += "No.Pasajeros: "+to_string(tmp->valor->NoPasajeros)+"\n";
        acumNodo += "No.Turnos: "+to_string(tmp->valor->NoTurnos)+"\n";
        acumNodo += "No.MantmtoReg: "+to_string(tmp->valor->NoTurnosMantenimiento)+"\"];\n";
        acumEnlace += tmp->idNodo+"->"+ tmp->siguiente->idNodo + ";\n";
        tmp = tmp->siguiente;
    }
    acumNodo +=  tmp->idNodo+"[label=\"Avion: "+ to_string(tmp->valor->idAvion)+ "\n";
    acumNodo += "tipo: "+tmp->valor->tipoAvionStr+"\n";
    acumNodo += "No.Pasajeros: "+to_string(tmp->valor->NoPasajeros)+"\n";
    acumNodo += "No.Turnos: "+to_string(tmp->valor->NoTurnos)+"\n";
    acumNodo += "No.MantmtoReg: "+to_string(tmp->valor->NoTurnosMantenimiento)+"\"];\n";

  //  acumEnlace += "}\n";
    acum += acumNodo + acumEnlace  + "\n}\n";

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
    if(primero !=NULL)
    {
        if(primero->siguiente !=NULL)
        {
            primero = primero->siguiente;
            primero->anterior = NULL;
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
    else
    {
        //QMessageBox::information(NULL,"Error","No quedan mas elementos en la Cola doble del avion");
        return false;
    }
}


