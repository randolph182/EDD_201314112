#-------------------------------------------------
#
# Project created by QtCreator 2017-12-08T03:40:57
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = EDD_Practica1
TEMPLATE = app


SOURCES += main.cpp\
        vstmain.cpp \
    nodo.cpp \
    lista.cpp \
    avion.cpp \
    pasajero.cpp \
    escritorio.cpp \
    equipaje.cpp \
    mantenimiento.cpp \
    documento.cpp \
    grafo.cpp \
    vstconfiguracion.cpp

HEADERS  += vstmain.h \
    nodo.h \
    lista.h \
    avion.h \
    pasajero.h \
    escritorio.h \
    equipaje.h \
    mantenimiento.h \
    documento.h \
    grafo.h \
    vstconfiguracion.h

FORMS    += vstmain.ui \
    vstconfiguracion.ui
