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
    NoTurnos = 0;
    NoEscritorios =0;
    NoMantenimiento =0;
    colaAvion = new ListaAvion();
    colaPasajero = new ListaPasajero();
    circularEquipaje = new ListaEquipaje();
    lstDbleEscritorio = new ListaEscritorio();
    lstSmpMantenimiento = new ListaMantenimiento();
    srand(time(0));
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


    Mantenimiento *nuevo2 = new Mantenimiento();
    lstSmpMantenimiento->addSimple(nuevo2,"estacion"+to_string(0));
    for (int i = 1; i <= 5; ++i) {
        Mantenimiento *nuevo = new Mantenimiento();
        lstSmpMantenimiento->addSimple(nuevo,"estacion"+to_string(i));
    }

    for (int j = 1; j <= 6; ++j) {
        Avion *av = new Avion();
        av = av->generarAvion();
        if(lstSmpMantenimiento->primero !=NULL)
        {
            lstSmpMantenimiento->primero->lstAvion->encolarSimple(av,"avionStacion"+to_string(j));
        }
    }


    Grafo *g = new Grafo();
    g->generarGrafoMantenimiento(lstSmpMantenimiento);
//    for (int i = 1; i <= 4; ++i) {
//        Pasajero *nuevo = new Pasajero();
//        nuevo = nuevo->generarPasajero();
//        colaPasajero->encolarSimple(nuevo,"ColaEsp");
//    }
//    Grafo *g = new Grafo();
//    g->generarGrafoColaPasajero(colaPasajero);


}
