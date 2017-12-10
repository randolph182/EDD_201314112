#ifndef VSTMAIN_H
#define VSTMAIN_H

#include <QMainWindow>

namespace Ui {
class vstMain;
}

class vstMain : public QMainWindow
{
    Q_OBJECT

public:
    explicit vstMain(QWidget *parent = 0);
    ~vstMain();

private:
    Ui::vstMain *ui;
};

#endif // VSTMAIN_H
