using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavalWarsEDD
{
    /* para la creacion de una nueva unidad 
       cada unidad tiene un identificador de tipo entero que por medioo de ese 
        identificador se hace un switch y se llenan los campos que le corresponden a ese tipo de nave
        cuando tipoUnidad :
     
     *   0 =    hacer referencia a los submarinos 
     *   1 =    Barco tipoCrucero
     *   2 =    Barco tipo Fragata
     *   3 =    Avion tipo helicoptero de combate
     *   4 =    avion tipo Caza
     *   5 =    Avion tipo Bombardero
     *   6 =    hacer referencia a NeoSatelite
                */
    public class Unidad
    {
        public int nivel;
        public int tipoUnidad;
        public int movimiento;
        public int alcanceInicial;
        public int alcanceFinal;
        public int danio;
        public int vida;
        public int fila;
        public int columna;
        public string idUnidad;


        public Unidad(int nivel, int tipoUnidad, string idUnidad)
        {
            switch (tipoUnidad)
            {
                case 0: //submarinos
                    this.nivel = nivel;
                    this.tipoUnidad = 0;
                    this.idUnidad = idUnidad;
                    this.movimiento = 5;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 1;
                    this.danio = 2;
                    this.vida = 10;
                    break;

                case 1: // Barco tipo Crucero
                    this.nivel = nivel;
                    this.tipoUnidad = 1;
                    this.idUnidad = idUnidad;
                    this.movimiento = 6;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 1;
                    this.danio = 3;
                    this.vida = 15;
                    break;

                case 2: // Barco tipo Fragata
                    this.nivel = nivel;
                    this.tipoUnidad = 2;
                    this.idUnidad = idUnidad;
                    this.movimiento = 5;
                    this.alcanceInicial = 2;
                    this.alcanceFinal = 6;
                    this.danio = 3;
                    this.vida = 10;
                    break;

                case 3: // Avion tipoi Helicomptero de Combate
                    this.nivel = nivel;
                    this.tipoUnidad = 3;
                    this.idUnidad = idUnidad;
                    this.movimiento = 9;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 1;
                    this.danio = 3;
                    this.vida = 15;
                    break;

                case 4: // Avion tipo Caza
                    this.nivel = nivel;
                    this.tipoUnidad = 4;
                    this.idUnidad = idUnidad;
                    this.movimiento = 9;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 1;
                    this.danio = 2;
                    this.vida = 20;
                    break;


                case 5: // Avion tipo Bombardero
                    this.nivel = nivel;
                    this.tipoUnidad = 5;
                    this.idUnidad = idUnidad;
                    this.movimiento = 7;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 0;
                    this.danio = 5;
                    this.vida = 10;
                    break;

                case 6: // NeoSatelite
                    this.nivel = nivel;
                    this.tipoUnidad = 6;
                    this.idUnidad = idUnidad;
                    this.movimiento = 6;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 0;
                    this.danio = 2;
                    this.vida = 10;
                    break;

                default:
                    break;
            }
        }

        public Unidad(int fila, int columna, int nivel, int tipoUnidad, string idUnidad)
        {
            switch (tipoUnidad)
            {
                case 0: //submarinos
                    this.fila = fila;
                    this.columna = columna;
                    this.nivel = nivel;
                    this.tipoUnidad = 0;
                    this.idUnidad = idUnidad;
                    this.movimiento = 5;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 1;
                    this.danio = 2;
                    this.vida = 10;
                    break;

                case 1: // Barco tipo Crucero
                    this.fila = fila;
                    this.columna = columna;
                    this.nivel = nivel;
                    this.tipoUnidad = 1;
                    this.idUnidad = idUnidad;
                    this.movimiento = 6;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 1;
                    this.danio = 3;
                    this.vida = 15;
                    break;

                case 2: // Barco tipo Fragata
                    this.fila = fila;
                    this.columna = columna;
                    this.nivel = nivel;
                    this.tipoUnidad = 2;
                    this.idUnidad = idUnidad;
                    this.movimiento = 5;
                    this.alcanceInicial = 2;
                    this.alcanceFinal = 6;
                    this.danio = 3;
                    this.vida = 10;
                    break;

                case 3: // Avion tipoi Helicomptero de Combate
                    this.fila = fila;
                    this.columna = columna;
                    this.nivel = nivel;
                    this.tipoUnidad = 3;
                    this.idUnidad = idUnidad;
                    this.movimiento = 9;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 1;
                    this.danio = 3;
                    this.vida = 15;
                    break;

                case 4: // Avion tipo Caza
                    this.nivel = nivel;
                    this.tipoUnidad = 4;
                    this.idUnidad = idUnidad;
                    this.movimiento = 9;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 1;
                    this.danio = 2;
                    this.vida = 20;
                    break;


                case 5: // Avion tipo Bombardero
                    this.fila = fila;
                    this.columna = columna;
                    this.nivel = nivel;
                    this.tipoUnidad = 5;
                    this.idUnidad = idUnidad;
                    this.movimiento = 7;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 0;
                    this.danio = 5;
                    this.vida = 10;
                    break;

                case 6: // NeoSatelite
                    this.fila = fila;
                    this.columna = columna;
                    this.nivel = nivel;
                    this.tipoUnidad = 6;
                    this.idUnidad = idUnidad;
                    this.movimiento = 6;
                    this.alcanceInicial = 0;
                    this.alcanceFinal = 0;
                    this.danio = 2;
                    this.vida = 10;
                    break;

                default:
                    break;
            }
        }


    }
}