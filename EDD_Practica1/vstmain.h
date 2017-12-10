#ifndef VSTMAIN_H
#define VSTMAIN_H

#include <QMainWindow>
#include "avion.h"
#include "pasajero.h"
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
    ListaAvion *colaAvion;
    ListaPasajero *colaPasajero;
    ~vstMain();

private slots:
    void on_btnSiguiente_clicked();

private:
    Ui::vstMain *ui;
};

#endif // VSTMAIN_H
