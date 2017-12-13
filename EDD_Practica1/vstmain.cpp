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
    srand(time(0));
}


vstMain::~vstMain()
{
    delete ui;
}

void vstMain::on_btnSiguiente_clicked()
{
//    if(colaAvion->primero ==NULL) //verifico si cola del avion esta vacia
//    {
//        Avion *nuevoAvion = new Avion();
//        nuevoAvion = nuevoAvion->generarAvion();
//        colaAvion->encolarDoble(nuevoAvion);
//    }
//    else
//    {
//        Avion *nuevoAvion = new Avion();
//        nuevoAvion = nuevoAvion->generarAvion();
//        colaAvion->encolarDoble(nuevoAvion);

//    }


//    Escritorio *e1 = new Escritorio('A');
//    Escritorio *e2 = new Escritorio(e1->letra++);
//    Escritorio *e3 = new Escritorio('C');
//    Escritorio *e4 = new Escritorio('D');
//    Escritorio *e5 = new Escritorio('Z');
//    Escritorio *e6 = new Escritorio('F');

//    ListaEscritorio *lstE = new ListaEscritorio();
//    lstE->addDoble(e1);
//    lstE->addDoble(e2);
//    lstE->addDoble(e3);
//    lstE->addDoble(e4);
//    lstE->addDoble(e5);
//    lstE->addDoble(e6);

//       lstE->imprimir();

//    char letra = 'A'+ rand()%(('z'-'A')+1);
//     char letra = 'A'+ rand()%5;

//    std::cout<<letra <<endl;

//    string a = "A";
//    string b = "B";
//    string c = "a";

//    int comparacion = b.compare(a);

//    cout << comparacion <<endl;
}
