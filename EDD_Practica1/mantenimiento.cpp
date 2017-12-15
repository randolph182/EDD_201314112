#include "mantenimiento.h"

Mantenimiento::Mantenimiento()
{

}

NodoMantenimiento::NodoMantenimiento()
{
    siguiente = NULL;
    lstAvion = new ListaAvion();
}

NodoMantenimiento::NodoMantenimiento(Mantenimiento *valor_)
{
    siguiente = NULL;
    lstAvion = new ListaAvion();
    valor = valor_;
}

void ListaMantenimiento::addSimple(Mantenimiento *valor_, string id)
{
    NodoMantenimiento *nuevo = new NodoMantenimiento(valor_);
    if(primero ==NULL)
    {
        primero = nuevo;
        ultimo = nuevo;
        size++;
        contNodo++;
        nuevo->idNodo = id+to_string(contNodo);
        valor_->idMantenimiento = contNodo;
    }
    else
    {
        ultimo->siguiente = nuevo;
        ultimo = nuevo;
        size++;
        contNodo++;
        nuevo->idNodo = id+to_string(contNodo);
        valor_->idMantenimiento = contNodo;
    }
}

string ListaMantenimiento::acumLstSmple()
{
     string acum = "subgraph clusterEscritoriosReg{\nrankdir = LR;\n";
     string acumSubGraph = "";
     string acumEnlaceSubG = "";
     string acumNodo = "";
     string acumEnlace  = "{rank = same;\n";

     NodoMantenimiento *tmp = primero;

     while(tmp->siguiente !=NULL)
     {
         acumNodo += tmp->idNodo+"[label=\"Mantenimiento: " + to_string(tmp->valor->idMantenimiento) + "\"];\n";
         acumEnlace += tmp->idNodo + "->" + tmp->siguiente->idNodo + ";\n";

         if(tmp->lstAvion->primero!=NULL)
         {
             acumSubGraph = tmp->lstAvion->acumLstSmple("mantenimiento"+tmp->idNodo);//acumLstSimplePasajero("Psjro"+tmp->valor->letra);
             acumEnlaceSubG += tmp->idNodo +"->"+tmp->lstAvion->primero->idNodo + ";\n";
         }

         tmp = tmp->siguiente;
     }

     acumNodo += tmp->idNodo+"[label=\"Mantenimiento: " + to_string(tmp->valor->idMantenimiento)+ "\"];\n";
     if(tmp->siguiente == NULL)
     {
         if(tmp->lstAvion->primero!=NULL)
         {
             acumSubGraph = tmp->lstAvion->acumLstSmple("mantenimiento"+tmp->idNodo);//acumLstSimplePasajero("Psjro"+tmp->valor->letra);
             acumEnlaceSubG += tmp->idNodo +"->"+tmp->lstAvion->primero->idNodo + ";\n";
         }
     }

     acumEnlace +="\n}\n";

     acum += acumNodo  + acumEnlace +  "}\n" + acumSubGraph +"\n" + acumEnlaceSubG;
     return acum;
}
