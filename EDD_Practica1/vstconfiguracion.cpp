#include "vstconfiguracion.h"
#include "ui_vstconfiguracion.h"
#include "vstmain.h"

vstConfiguracion::vstConfiguracion(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::vstConfiguracion)
{
    ui->setupUi(this);
    ui->lineEditAviones->setText("1");
    ui->lineEditEscritorios->setText("4");
    ui->lineEditMantenimiento->setText("2");
    ui->lineEditTurnos->setText("20");
}

vstConfiguracion::~vstConfiguracion()
{
    delete ui;
}

void vstConfiguracion::on_btnConfigurar_clicked()
{
    vstMain *nuevo = new vstMain();

    int noAviones = atoi(ui->lineEditAviones->text().toStdString().c_str());
    int noTurnos = atoi(ui->lineEditTurnos->text().toStdString().c_str());
    int noEscritorios = atoi(ui->lineEditEscritorios->text().toStdString().c_str());
    int noMantenimiento = atoi(ui->lineEditMantenimiento->text().toStdString().c_str());
//    nuevo->NoAviones = noAviones;
//    nuevo->NoTurnos = noTurnos;
//    nuevo->NoMantenimiento = noMantenimiento;
//    nuevo->NoEscritorios = noEscritorios;
    nuevo->configuracionInicial(noAviones,noTurnos,noEscritorios,noMantenimiento);
    nuevo->show();
    this->hide();
}
