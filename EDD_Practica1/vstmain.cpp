#include "vstmain.h"
#include "ui_vstmain.h"
#include <iostream>
#include "escritorio.h"
#include <cstring>
#include <string>
#include <QString>


vstMain::vstMain(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::vstMain)
{
    ui->setupUi(this);
    NoAviones =0;
    NoTurnos = 20;
    NoEscritorios =3;
    NoMantenimiento =1;
    colaAvion = new ListaAvion();
    colaPasajero = new ListaPasajero();
    circularEquipaje = new ListaEquipaje();
    lstDbleEscritorio = new ListaEscritorio();
    lstSmpMantenimiento = new ListaMantenimiento();
    lstCircDobEquipaje = new ListaEquipaje();
    lstPilaDoc = new ListaDocumento();
    creacionEstruct();
    srand(time(0));
}

void vstMain::generarGrafo()
{
    Grafo *g  = new Grafo();

    string acum  = "digraph G{\nnode [shape=box];\n";
    string escritorios = lstDbleEscritorio->acumDobleEscritorio();
   // escritorios += "\n}\n";
    string mante= lstSmpMantenimiento->acumLstSmple();
     acum += colaAvion->acumLstDoble();
   // mante += "\n}\n";
    acum += escritorios + mante ;
    acum += "\n}\n";
    g->generarGrafo("estructuras",acum);
}

void vstMain::creacionEstruct()
{
    if(NoEscritorios >0)
    {
        char letra = 'A';
             Escritorio *nuevo = new Escritorio(letra);
             lstDbleEscritorio->addDoble(nuevo);
         if(NoEscritorios >1)
         {
             for (int escritorio = 1; escritorio < NoEscritorios; ++escritorio) {
                 Escritorio *nuevo2 = new Escritorio(++letra);
                 lstDbleEscritorio->addDoble(nuevo2);
             }
         }
    }

    Mantenimiento *mant = new Mantenimiento();
    lstSmpMantenimiento->addSimple(mant,"estacion"+to_string(0));
    for (int mante = 1; mante <= NoMantenimiento; ++mante) {
        Mantenimiento *mant2 = new Mantenimiento();
        lstSmpMantenimiento->addSimple(mant2,"estacion"+to_string(mante));
    }

}

void vstMain::logica()
{
    logicaAvion();
    verificarColaAvion();
   // verificarColaMant();
    NoTurnos--;
}

void vstMain::logicaAvion()
{
    if(NoTurnos != 0)
    {
         Avion *nuevoAvion = new Avion();
         nuevoAvion = nuevoAvion->generarAvion();
         colaAvion->encolarDoble(nuevoAvion,"ColaAvion");
    }
    else
    {
        cout<<"se acabaron los turnos" <<endl;
    }
}

void vstMain::verificarColaAvion()
{
    if(NoTurnos !=0)
    {
        if(colaAvion->primero !=NULL)
        {
            if(colaAvion->primero->valor->NoTurnos==0)
            {
                Avion *avMant = new Avion();
                avMant = colaAvion->primero->valor;
                bool bandera = colaAvion->desencolarDoble();

                if(bandera !=NULL)
                {
                    NodoMantenimiento *mantTmp = lstSmpMantenimiento->primero;

                    for (int i = 1; i <= lstSmpMantenimiento->size; ++i) {
                        if(mantTmp->lstAvion->primero ==NULL){
                            mantTmp->lstAvion->encolarSimple(avMant,"avMant"+to_string(NoTurnos));
                            break;
                        }
                        if(lstSmpMantenimiento->size == i )
                        {
                            mantTmp = lstSmpMantenimiento->primero;
                            for (int j = 1; j <= lstSmpMantenimiento->size; ++j) {
                                mantTmp->lstAvion->encolarSimple(avMant,"avMant"+to_string(NoTurnos));
                                break;
                            }
                        }
                        mantTmp = mantTmp->siguiente;
                    }
                }
              //  lstSmpMantenimiento->primero->lstAvion->encolarSimple(avMant,"avMant"+to_string(NoTurnos));

            }
            else
            {
                colaAvion->primero->valor->NoTurnos--;
            }
        }
    }
    else
    {
        cout<<"se acabaron los turnos" <<endl;
    }
}

void vstMain::verificarColaMant()
{
    if(NoTurnos !=0)
    {
        if(lstSmpMantenimiento->primero !=NULL)
        {
            if(lstSmpMantenimiento->primero->lstAvion->primero!=NULL)
            {
                if(lstSmpMantenimiento->primero->lstAvion->primero->valor->NoTurnosMantenimiento ==0)
                {
                    lstSmpMantenimiento->primero->lstAvion->desencolarSimple();
                }
                else
                {
                    lstSmpMantenimiento->primero->lstAvion->primero->valor->NoTurnosMantenimiento--;
                }
            }
        }
    }
    else
    {
        cout<<"se acabaron los turnos" <<endl;
    }
}


vstMain::~vstMain()
{
    delete ui;
}

void vstMain::on_btnSiguiente_clicked()
{
//    for (int i = 1; i <= 5; ++i) {
//        Avion *nuevo = new Avion();
//        nuevo = nuevo->generarAvion();
//        colaAvion->encolarDoble(nuevo);
//    }

//   Grafo *g = new Grafo();
//   g->generarGrafoDobleAvion(colaAvion);

//char letra = 'A';
//     Escritorio *nuevo = new Escritorio(letra);
//     lstDbleEscritorio->addDoble(nuevo);
//    for (int i = 1; i <= 5; ++i) {

//        Escritorio *nuevo2 = new Escritorio(++letra);
//        lstDbleEscritorio->addDoble(nuevo2);
//    }
//        for (int i = 1; i <= 4; ++i) {
//            Pasajero *psjro = new Pasajero();
//            psjro = psjro->generarPasajero();
//            lstDbleEscritorio->primero->lstPasajeros->encolarSimple(psjro,lstDbleEscritorio->primero->idNodo);
//        }
//    Grafo *g = new Grafo();

//    g->generarGrafoEscritorios(lstDbleEscritorio);


//    Mantenimiento *nuevo2 = new Mantenimiento();
//    lstSmpMantenimiento->addSimple(nuevo2,"estacion"+to_string(0));
//    for (int i = 1; i <= 5; ++i) {
//        Mantenimiento *nuevo = new Mantenimiento();
//        lstSmpMantenimiento->addSimple(nuevo,"estacion"+to_string(i));
//    }

//    for (int j = 1; j <= 6; ++j) {
//        Avion *av = new Avion();
//        av = av->generarAvion();
//        if(lstSmpMantenimiento->primero !=NULL)
//        {
//            lstSmpMantenimiento->primero->lstAvion->encolarSimple(av,"avionStacion"+to_string(j));
//        }
//    }


//    Grafo *g = new Grafo();
//    g->generarGrafoMantenimiento(lstSmpMantenimiento);



//    for (int i = 1; i <= 6; ++i) {
//        Equipaje *nuevo = new Equipaje();
//        lstCircDobEquipaje->addCircularDoble(nuevo,i);
//    }
//    Grafo *g = new Grafo();
//    g->generarGrafoEquipaje(lstCircDobEquipaje);




//    for (int i = 1; i <= 4; ++i) {
//        Pasajero *nuevo = new Pasajero();
//        nuevo = nuevo->generarPasajero();
//        colaPasajero->encolarSimple(nuevo,"ColaEsp");
//    }
//    Grafo *g = new Grafo();
//    g->generarGrafoColaPasajero(colaPasajero);
    logica();
    generarGrafo();

}
