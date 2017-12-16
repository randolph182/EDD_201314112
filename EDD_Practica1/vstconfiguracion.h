#ifndef VSTCONFIGURACION_H
#define VSTCONFIGURACION_H

#include <QDialog>

namespace Ui {
class vstConfiguracion;
}

class vstConfiguracion : public QDialog
{
    Q_OBJECT

public:
    explicit vstConfiguracion(QWidget *parent = 0);
    ~vstConfiguracion();

private slots:
    void on_btnConfigurar_clicked();

private:
    Ui::vstConfiguracion *ui;
};

#endif // VSTCONFIGURACION_H
