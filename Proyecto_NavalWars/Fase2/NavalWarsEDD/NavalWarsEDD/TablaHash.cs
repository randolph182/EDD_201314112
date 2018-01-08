using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavalWarsEDD
{
    public class NodoHash
    {
        public Usuario infoUsuario;
        int llave;
        public NodoHash(int llv,Usuario infoUsuario)
        {
            this.llave = llv;
            this.infoUsuario = infoUsuario;
        }
        public NodoHash() { }
    }
    public class TablaHash
    {
        public int tamanio;
        public NodoHash[] elementos;
        public double factorCarga;
        public double elementosUsados;

        public TablaHash(int tamanio)
        {
            this.tamanio = tamanio;
            this.elementos = new NodoHash[tamanio];
            this.factorCarga = 0;
            this.elementosUsados = 0;
            /* inicializando los elementos */
            for (int i = 0; i < tamanio; i++)
            {
                elementos[i] = null;
            }
        }

        public void insertarFromABB(ref NodoUsuario raiz)
        {
            if(raiz != null)
            {
                insertarFromABB(ref raiz.izquierda);
                insertar(raiz.informacion);
                insertarFromABB(ref raiz.derecha);
            }
        }
        public void insertar(Usuario nuevo)
        {
            
            factorCarga = (Convert.ToDouble(elementosUsados) / Convert.ToDouble(tamanio)) * 100;//para sacar el porcentaje de carga

            if(factorCarga < 50 && factorCarga >=0) //significa que posee el 50% de ocupacion maximo
            {
                int llave = getLLv(nuevo.nickName, tamanio);
                insertar(nuevo, llave);
                elementosUsados++;
            }
            else //aplicacion del rehashing
            {
                NodoHash []tmpElementos = elementos;
                /* aumentamos el tamanio a un numero impar*/
                this.tamanio = tamanio + 2;
                elementos = new NodoHash[tamanio];
                elementosUsados = 0;
                factorCarga = 0;
                insertar(nuevo);
                for (int i = 0; i < tmpElementos.Count(); i++)
                {
                    if(tmpElementos[i] != null)
                        insertar(tmpElementos[i].infoUsuario);
                }
            }
        }



        public void insertar(Usuario nuevo , int llv)
        {
            NodoHash nuevoNodo = new NodoHash(llv, nuevo);
            if(elementos[llv] == null) //comprobando si no esta ocupada la posicion
            {
                elementos[llv] = nuevoNodo;
            }
            else /* Aplicacion de la resolucion de Coliciiones por el metodo de Exploracio Cuadratica*/
            {
                int i = 0;
                bool teoriaRestos = false;
                while( i != tamanio)
                {
                    int llvNueva = getNuevaLLv(llv, i);
                    if (llvNueva >= tamanio)
                    {
                        teoriaRestos = true;
                        break;
                    }
                    else if (elementos[llvNueva] == null)
                    {
                        elementos[llvNueva] = nuevoNodo;
                        break;
                    }
                    i++;    
                }
                if(teoriaRestos)
                {
                    i = 0;
                    while (i != tamanio)
                    {
                        if (elementos[i] == null)
                        {
                            elementos[i] = nuevoNodo;
                            break;
                        }
                        i++;
                    }
                }
            }
        }

        public int getNuevaLLv(int pos, int i)
        {
            return pos + i ^ 2;
        }

        public int getLLv(String id, int tamanioTabla)
        { 
            /*obtengo el tamanio del id pero lo divido en 3 para luego hace la suma del resultado*/
            int cocienteId = id.Length / 3;
            int suma = 0;
            for (int j = 0; j < cocienteId; j++)
            {
                char[] elem = id.Substring(j * 3, 3).ToCharArray(); /* voy obteniendo elementos del string de 3 en 3*/
                int mult = 1;
                /* conversion de los digitos a ACII*/
                for(int k = 0; k < elem.Length; k++)
                {
                    suma += elem[k] * mult;
                    mult *= 256;
                }
            }

            char[] elem2 = id.Substring(cocienteId * 3).ToCharArray(); /* verifico si sobro alguno de los elementos del string*/
            int mult2 = 1;
            for (int k = 0; k < elem2.Length; k++)
            {
                suma += elem2[k] *mult2;
                mult2 *= 256;
            }
            return (Math.Abs(suma) % tamanioTabla); //esta es la funcion modular h(x) = x mod M.
            /* el math.abs sirve para sacar el absoluto del dato ya que si se da el caso de que sea negativo*/
        }

        public void getAcumGrafo(ref string acum)
        {
            string enlace = "";
            string encabezado = "";
            acum += "node100000 [label= \"";
            for (int i = 0; i < tamanio; i++)
            {
                
                if(elementos[i] != null)
                {
                    acum += "<f" + i.ToString() + "> llave: " + i.ToString() + "\\n\\n\\n\\n|";
                    Usuario tmp = elementos[i].infoUsuario;
                   // acum += "<f" + i.ToString() + "> |";
                    encabezado += "node" + tmp.GetHashCode().ToString();
                    encabezado +="[label=\"{<n>" + "nickname: "+tmp.nickName +"\\n Password: "+tmp.password+"\\n Email: "+tmp.email+ "}\"];\n";
                    enlace += "node100000:f" + i.ToString() + " -> node" + tmp.GetHashCode().ToString() + ":n;\n";
                }
                    
            }                
            acum += "\",height=2.5]; \n node [width = 1.5];\n\n";

            acum += encabezado + enlace;
        }

    }
}