#include "vstmain.h"
#include "ui_vstmain.h"
#include <iostream>
#include "escritorio.h"
#include <cstring>
#include <string>
#include <QString>
#include <sstream>
#include <QPixmap>
#include <QGraphicsPixmapItem>
#include <QRectF>
//#include


vstMain::vstMain(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::vstMain)
{
    ui->setupUi(this);
    srand(time(0));
}

void vstMain::configuracionInicial(int noAviones, int noTurnos, int noEscritorios, int noMantenimiento)
{
    this->NoAviones = noAviones;
    this->NoTurnos = noTurnos;
    this->NoEscritorios = noEscritorios;
    this->NoMantenimiento = noMantenimiento;
    colaAvion = new ListaAvion();
    colaPasajero = new ListaPasajero();
    circularEquipaje = new ListaEquipaje();
    lstDbleEscritorio = new ListaEscritorio();
    lstSmpMantenimiento = new ListaMantenimiento();
    lstCircDobEquipaje = new ListaEquipaje();
    lstPilaDoc = new ListaDocumento();
    creacionEstruct();
}

void vstMain::generarGrafo()
{
    Grafo *g  = new Grafo();

    string acum  = "digraph G{\nnode [shape=box];\n";
    acum += colaAvion->acumLstDoble();
     acum += colaPasajero->acumLstSimplePasajero("EsperaPajaero");
     acum += circularEquipaje->acumCircularDob();
    acum += lstDbleEscritorio->acumDobleEscritorio();
     acum += lstSmpMantenimiento->acumLstSmple();
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
    for (int mante = 1; mante < NoMantenimiento; ++mante) {
        Mantenimiento *mant2 = new Mantenimiento();
        lstSmpMantenimiento->addSimple(mant2,"estacion"+to_string(mante));
    }

}

void vstMain::logica()
{
    if(NoTurnos !=0)
    {
        logicaAvion();
        verificarColaAvion();
        insertPasajeroEscritorio();
        verificarColaEsperaEscritorio();
        insertDocumento();
        verificarColaMant();
        NoTurnos--;
        contTurno++;
    }
    else
    {
        QMessageBox::information(NULL,"Advertencia","Se acabaron los Turnos");
    }


}

void vstMain::logicaAvion()
{
    if(NoTurnos != 0)
    {
        if( NoAviones !=0 )
        {
            Avion *nuevoAvion = new Avion();
            nuevoAvion = nuevoAvion->generarAvion();
            colaAvion->encolarDoble(nuevoAvion,"ColaAvion");
            infoAvion  = "arribo Avion: "+to_string(nuevoAvion->idAvion) + "\n\n";
            NoAviones--;
        }
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
                    insertAvionMantenimiento(avMant);
                    insertColaEsperaPasaje(avMant);

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
            NodoMantenimiento *tmpMant = lstSmpMantenimiento->primero;
                infoMantenimiento += "-------------------- Area de Mantenimiento -----------------------\n\n";
            for (int i = 0; i < NoMantenimiento; ++i) {
                if(tmpMant->lstAvion->primero !=NULL)
                {
                    if(tmpMant->lstAvion->primero->valor->NoTurnosMantenimiento ==0)
                    {
                       tmpMant->lstAvion->desencolarSimple();
                       if(tmpMant->lstAvion->primero !=NULL)
                       {
                           infoMantenimiento += "Sala de Mantenimiento No:"+to_string(tmpMant->valor->idMantenimiento)+":\n";
                           infoMantenimiento += "Avion atendido: " + to_string(tmpMant->lstAvion->primero->valor->idAvion)+"\n";
                           infoMantenimiento += "Turnos Restantes: " +to_string(tmpMant->lstAvion->primero->valor->NoTurnosMantenimiento)+"\n\n";
                       }


                    }
                    else
                    {
                        tmpMant->lstAvion->primero->valor->NoTurnosMantenimiento--;

                        infoMantenimiento += "Sala de Mantenimiento No:"+to_string(tmpMant->valor->idMantenimiento)+":\n";
                        infoMantenimiento += "Avion atendido: " + to_string(tmpMant->lstAvion->primero->valor->idAvion)+"\n";
                        infoMantenimiento += "Turnos Restantes: " +to_string(tmpMant->lstAvion->primero->valor->NoTurnosMantenimiento)+"\n\n";
                    }
                }
                else
                {
                    infoMantenimiento += "Sala de Mantenimiento No:"+to_string(tmpMant->valor->idMantenimiento)+":\n";
                    infoMantenimiento += "Avion atendido: ninguno \n";
                    infoMantenimiento += "Turnos Restantes:  nunguno \n\n";
                }
                tmpMant = tmpMant->siguiente;
            }
        }
    }
    else
    {
        cout<<"se acabaron los turnos" <<endl;
    }
}

void vstMain::insertAvionMantenimiento(Avion *nuevo)
{
    NodoMantenimiento *mantTmp = lstSmpMantenimiento->primero;

    for (int i = 1; i <= lstSmpMantenimiento->size; ++i) {

        if(mantTmp->lstAvion->primero ==NULL){
            mantTmp->lstAvion->encolarSimple(nuevo,"avMant"+to_string(NoTurnos));
            break;
        }
        if(lstSmpMantenimiento->size == i )
        {
            mantTmp = lstSmpMantenimiento->primero;
            for (int j = 1; j <= lstSmpMantenimiento->size; ++j) {
                mantTmp->lstAvion->encolarSimple(nuevo,"avMant"+to_string(NoTurnos));
                break;
            }
        }
        mantTmp = mantTmp->siguiente;
    }
}

void vstMain::insertColaEsperaPasaje(Avion *avion)
{
    for (int i = 1; i <= avion->NoPasajeros; ++i) {
        Pasajero *nuevoPasajero = new Pasajero();
        nuevoPasajero = nuevoPasajero->generarPasajero();
        colaPasajero->encolarSimple(nuevoPasajero,"colaEspera"+to_string(i));
        insertMaletas(nuevoPasajero);
    }
}

void vstMain::insertPasajeroEscritorio()
{
    if(colaPasajero->primero!=NULL)
    {
        NodoPasajero *pasjero = colaPasajero->primero;
        NodoEscritorio *escritorio = lstDbleEscritorio->primero;

            while(colaPasajero->primero!=NULL)
            {
                pasjero = colaPasajero->primero;
                if(escritorio == NULL)
                {
                    break;
                }
               if(escritorio->lstPasajeros->size != 10 )
               {
                   escritorio->lstPasajeros->encolarSimple(pasjero->valor,to_string(escritorio->valor->letra).c_str());
               }
               else
               {
                        escritorio = escritorio->siguiente;
                        continue;
               }
               colaPasajero->desencolarSimple();
            }

            infoColaPasajeros += "--------------------- Cola de Pasajeros ----------------------------\n\n";
            infoColaPasajeros += "Pasajeros Esperando ser atendidos: " + to_string(colaPasajero->size)+"\n\n";
    }
}

void vstMain::insertMaletas(Pasajero *maletaPasajero)
{
    for (int i = 1; i <= maletaPasajero->NoMaletas; ++i) {
        Equipaje *equip = new Equipaje();
        circularEquipaje->addCircularDoble(equip,to_string(i)+to_string(NoTurnos)+to_string(maletaPasajero->idPasajero));
    }
}

void vstMain::insertDocumento()
{
    NodoEscritorio *escritorio = lstDbleEscritorio->primero;

        while(escritorio !=NULL)
        {
            if(escritorio->lstDocumento->primero ==NULL && escritorio->lstPasajeros->primero!=NULL)
            {
                for (int i = 1; i <=escritorio->lstPasajeros->primero->valor->NoDocumetos; ++i) {
                   Documento *doc = new Documento();
                   doc->idPasajero = escritorio->lstPasajeros->primero->idNodo;
                   escritorio->lstDocumento->addPila(doc,to_string(i)+doc->idPasajero+escritorio->valor->letra);
                }
            }
            escritorio  = escritorio->siguiente;
        }


}

void vstMain::verificarDocumento(NodoEscritorio *actual)
{
    if(actual->lstDocumento->primero !=NULL)
    {
        actual->lstDocumento->desapilarTodo();
    }
//    if(actual->lstDocumento->primero !=NULL && actual->lstPasajeros->primero !=NULL)
//    {
//        actual->lstDocumento->desapilarTodo();
//    }
}

void vstMain::actualizarConsola()
{
    acumTerminal = ui->textEdit->toPlainText().toStdString();
    ui->textEdit->clear();
    acumTerminal += "***************************** Turno " +to_string(contTurno) + "*****************************\n\n";
    infoMaletas += "----------------------- Maletas en el Sistema -------------------------\n";
    infoMaletas += "Maletas en Espera: " + to_string(circularEquipaje->size)+ "\n\n";
    acumTerminal += infoAvion + infoEscritorios + infoColaPasajeros + infoMaletas + infoMantenimiento;
    ui->textEdit->setText(acumTerminal.c_str());
    infoAvion = "";
    infoEscritorios = "";
    infoColaPasajeros = "";
    infoMaletas = "";
    infoMantenimiento = "";
}

void vstMain::verificarColaEsperaEscritorio()
{
    NodoEscritorio  *tmpEscritorio = lstDbleEscritorio->primero;
    infoEscritorios += "---------------------Escritorios de Registro---------------------\n";
    while(tmpEscritorio!=NULL)
    {
        if(tmpEscritorio->lstPasajeros->primero !=NULL)
        {
            if(tmpEscritorio->lstPasajeros->primero->valor->NoTurnosRegistro == 0)
            {


                if(tmpEscritorio->lstPasajeros->primero!=NULL)
                {
                    string letra;
                    letra += tmpEscritorio->valor->letra;                   
                    infoEscritorios += "Escritorio de Registro " + letra + ": \n";
                    infoEscritorios += "Pasajero Atendido: "+to_string(tmpEscritorio->lstPasajeros->primero->valor->idPasajero)+"\n";
                    infoEscritorios += "Turnos Rerstantes: "+to_string(tmpEscritorio->lstPasajeros->primero->valor->NoTurnosRegistro)+"\n";
                    infoEscritorios += "CantidadDocumentos:"+to_string(tmpEscritorio->lstPasajeros->primero->valor->NoDocumetos)+"\n\n";

                }
                verificarDocumento(tmpEscritorio);
                verificarMaletas(tmpEscritorio->lstPasajeros->primero->valor->NoMaletas);
                tmpEscritorio->lstPasajeros->desencolarSimple();

            }
            else
            {
                string letra;
                letra += tmpEscritorio->valor->letra;
                tmpEscritorio->lstPasajeros->primero->valor->NoTurnosRegistro--;
                infoEscritorios += "Escritorio de Registro " + letra + ": \n";
                infoEscritorios += "Pasajero Atendido: "+to_string(tmpEscritorio->lstPasajeros->primero->valor->idPasajero)+"\n";
                infoEscritorios += "Turnos Rerstantes: "+to_string(tmpEscritorio->lstPasajeros->primero->valor->NoTurnosRegistro)+"\n";
                infoEscritorios += "CantidadDocumentos:"+to_string(tmpEscritorio->lstPasajeros->primero->valor->NoDocumetos)+"\n\n";
            }
        }
        else
        {
            string letra;
            letra += tmpEscritorio->valor->letra;
            infoEscritorios  += "Escritorio de Registro " + letra + ": Vacio \n\n";
        }
        tmpEscritorio = tmpEscritorio->siguiente;
    }
}

void vstMain::verificarMaletas(int cant)
{
    circularEquipaje->quitarCircDoble(cant);
}


vstMain::~vstMain()
{
    delete ui;
}

void vstMain::on_btnSiguiente_clicked()
{


    logica();
    generarGrafo();
    actualizarConsola();
    QGraphicsScene *scene  = new QGraphicsScene();
    QImage image("estructuras.png");
    QGraphicsPixmapItem *img = new QGraphicsPixmapItem(QPixmap::fromImage(image));
    scene->addItem(img);
    ui->graphicsView->setScene(scene);

}
