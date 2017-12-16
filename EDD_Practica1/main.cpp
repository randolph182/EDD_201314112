#include "vstmain.h"
#include <QApplication>
#include "vstconfiguracion.h"

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    //vstMain w;
    vstConfiguracion w;
    w.show();

    return a.exec();
}
