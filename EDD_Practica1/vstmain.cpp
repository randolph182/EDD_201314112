#include "vstmain.h"
#include "ui_vstmain.h"
#include <iostream>

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
    srand(time(0));
}


vstMain::~vstMain()
{
    delete ui;
}

void vstMain::on_btnSiguiente_clicked()
{
    if(colaAvion->primero ==NULL) //verifico si cola del avion esta vacia
    {
        Avion *nuevoAvion = new Avion();
        nuevoAvion = nuevoAvion->generarAvion();
        colaAvion->encolarDoble(nuevoAvion);
    }
    else
    {
        Avion *nuevoAvion = new Avion();
        nuevoAvion = nuevoAvion->generarAvion();
        colaAvion->encolarDoble(nuevoAvion);

    }
}
