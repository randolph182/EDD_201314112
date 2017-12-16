#ifndef VSTMAIN_H
#define VSTMAIN_H

#include <QMainWindow>
#include "avion.h"
#include "pasajero.h"
#include "equipaje.h"
#include "grafo.h"
#include "escritorio.h"
#include "mantenimiento.h"
#include "equipaje.h"
#include "documento.h"

using namespace std;
namespace Ui {
class vstMain;
}

class vstMain : public QMainWindow
{
    Q_OBJECT

public:
    explicit vstMain(QWidget *parent = 0);
    int NoAviones;
    int NoTurnos;
    int NoEscritorios;
    int NoMantenimiento;
    string acumTerminal = "";
    string infoAvion = "";
    string infoEscritorios = "";
    string infoMantenimiento = "";
    string infoMaletas = "";
    string infoColaPasajeros = "";

    int contTurno =0;
    ListaAvion *colaAvion;
    ListaPasajero *colaPasajero;
    ListaEquipaje *circularEquipaje;
    ListaEscritorio *lstDbleEscritorio;
    ListaMantenimiento *lstSmpMantenimiento;
    ListaEquipaje *lstCircDobEquipaje;
    ListaDocumento *lstPilaDoc;

    void configuracionInicial(int noAviones,int noTurnos, int noEscritorios, int noMantenimiento);
    void generarGrafo();
    void creacionEstruct();
    void logica();
    void logicaAvion();
    void verificarColaAvion();
    void verificarColaMant();
    void verificarColaEsperaEscritorio();
    void verificarMaletas(int cant);

    void insertAvionMantenimiento(Avion *nuevo);
    void insertColaEsperaPasaje(Avion *avion);
    void insertPasajeroEscritorio();
    void insertMaletas(Pasajero *maletaPasajero);
    void insertDocumento();
    void verificarDocumento(NodoEscritorio *actual);

    void actualizarConsola();

    ~vstMain();

private slots:
    void on_btnSiguiente_clicked();

private:
    Ui::vstMain *ui;
};

#endif // VSTMAIN_H
