#include "vstmain.h"
#include "ui_vstmain.h"

vstMain::vstMain(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::vstMain)
{
    ui->setupUi(this);
}

vstMain::~vstMain()
{
    delete ui;
}
