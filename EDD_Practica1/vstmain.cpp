#include "vstmain.h"
#include "ui_vstmain.h"
#include <iostream>
#include "escritorio.h"
#include <cstring>


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
    circularEquipaje = new ListaEquipaje();
    srand(time(0));
}


vstMain::~vstMain()
{
    delete ui;
}

void vstMain::on_btnSiguiente_clicked()
{
    for (int i = 1; i <= 5; ++i) {
        Avion *nuevo = new Avion();
        nuevo = nuevo->generarAvion();
        colaAvion->encolarDoble(nuevo);
    }

   Grafo *g = new Grafo();
   g->generarGrafoDobleAvion(colaAvion);


}
