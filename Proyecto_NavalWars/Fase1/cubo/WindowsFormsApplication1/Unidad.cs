using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Unidad
    {
        public int nivel;
        public int tipo;
        public int movimiento;
        public int alcanceInicial;
        public int alcanceFinal;
        public int danio;
        public int vida;

        public Unidad(int nivel, int tipoUnidad)
        {
            switch (tipoUnidad)
            {
                case 0: //Submarino
                    this.nivel = nivel;
                    this.tipo = 0;
                    this.movimiento = 5;
                    this.alcanceInicial = 1;
                    this.alcanceFinal = 1;
                    this.danio = 2;
                    this.vida = 10;
                break;

                case 1: // Barco de tipo Crucero
                    this.nivel = nivel;
                    this.tipo = 1;
                    this.movimiento = 6;
                    this.alcanceInicial = 1;
                    this.alcanceFinal = 1;
                    this.danio = 3;
                    this.vida = 15;
                break;

                case 2: //Barco tipo Fragata
                    this.nivel = nivel;
                    this.tipo = 2;
                    this.movimiento = 5;
                    this.alcanceInicial = 2;
                    this.alcanceFinal = 6;
                    this.danio = 3;
                    this.vida = 10;
                break;

                case 3: //Avion tipo Helicoptero de combate
                     this.nivel = nivel;
                    this.tipo = 3;
                    this.movimiento = 9;
                    this.alcanceInicial = 1;
                    this.alcanceInicial = 1;
                    this.danio = 3;
                    this.vida = 15;

                break;

                case 4: //Avion tipo Caza
                this.nivel = nivel;
                this.tipo = 4;
                this.movimiento = 9;
                this.alcanceInicial = 1;
                this.alcanceInicial = 1;
                this.danio = 2;
                this.vida = 20;

                break;

                case 5: //Avion tipo Bombardero
                this.nivel = nivel;
                this.tipo = 5;
                this.movimiento = 7;
                this.alcanceInicial = 0;
                this.alcanceInicial = 0;
                this.danio = 5;
                this.vida = 10;

                break;

                case 6: //NeoSatelite 
                this.nivel = nivel;
                this.tipo = 6;
                this.movimiento = 6;
                this.alcanceInicial = 0;
                this.alcanceInicial = 0;
                this.danio = 2;
                this.vida = 10;

                break;

                default:
                break;
            }
        }
    }
}
