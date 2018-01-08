using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NavalWarsEDD
{
    public class NodoOrtogonal
    {
        public NodoOrtogonal izquierda;
        public NodoOrtogonal derecha;
        public NodoOrtogonal arriba;
        public NodoOrtogonal abajo;
        public NodoOrtogonal adelante;
        public NodoOrtogonal atras;

        public int fila;
        public int columna;
        public Unidad unidad;
        public NodoOrtogonal(int fila, int columna, ref Unidad valor)
        {
            this.fila = fila;
            this.columna = columna;
            this.unidad = valor;
            this.izquierda = null;
            this.derecha = null;
            this.arriba = null;
            this.abajo = null;
            this.adelante = null;
            this.atras = null;
        }
    }
    public class Encabezado
    {
        public int id;
        public Encabezado siguiente;
        public Encabezado anterior;
        public NodoOrtogonal accesoNodo;

        public Encabezado(int id)
        {
            this.id = id;
            this.siguiente = null;
            this.anterior = null;
            this.accesoNodo = null;
        }

    }

    public class ListaEncabezado
    {
        public Encabezado primero;
        int size;
        public void insertar(ref Encabezado nuevo)
        {
            if (primero == null)
            {
                primero = nuevo;
                size++;
            }
            else
            {
                if (nuevo.id < primero.id) //insercion al inicio 
                {
                    nuevo.siguiente = primero;
                    primero.anterior = nuevo;
                    primero = nuevo;
                    size++;
                }
                else
                {
                    Encabezado tmp = primero;
                    while (tmp.siguiente != null)
                    {
                        if (nuevo.id < tmp.siguiente.id)
                        {
                            nuevo.siguiente = tmp.siguiente;
                            tmp.siguiente.anterior = nuevo;
                            tmp.siguiente = nuevo;
                            nuevo.anterior = tmp;
                            size++;
                            break;
                        }
                        tmp = tmp.siguiente;
                    }
                    if (tmp.siguiente == null)
                    {
                        tmp.siguiente = nuevo;
                        nuevo.anterior = tmp;
                        size++;
                    }
                }

            }
        }
        public Encabezado buscarEncabezado(int id)
        {
            if (primero != null)
            {
                Encabezado tmp = primero;
                while (tmp != null)
                {
                    if (tmp.id == id)
                        return tmp;
                    tmp = tmp.siguiente;
                }

            }
            return null;
        }
        public bool eliminar(int id)
        {
            if (primero != null)
            {
                if (primero.id == id)
                {
                    if (primero.siguiente != null)
                    {
                        primero.siguiente.anterior = null;
                        primero = primero.siguiente;
                        size--;
                        return true;
                    }
                    else
                    {
                        primero = null;
                        return true;
                    }


                }
                else
                {
                    Encabezado tmp = primero;
                    while (tmp.siguiente != null)
                    {
                        if (tmp.id == id)
                        {
                            Encabezado tmp2 = tmp.anterior;
                            tmp2.siguiente = tmp.siguiente;
                            tmp.siguiente.anterior = tmp2;
                            size--;
                            return true;
                        }
                        tmp = tmp.siguiente;
                    }
                    if (tmp.siguiente == null)
                    {
                        if (tmp.id == id)
                        {
                            tmp.anterior.siguiente = null;
                            tmp.anterior = null;
                            size--;
                            return true;

                        }
                    }
                }
            }
            return false;
        }
    }



    public class Matriz
    {
                public ListaEncabezado ncbzdoFilas;
        public ListaEncabezado ncbzdoColumnas;
        public Matriz()
        {
            this.ncbzdoFilas = new ListaEncabezado();
            this.ncbzdoColumnas = new ListaEncabezado();
        }

        public void insertar(int fila, string columna, ref Unidad nuevaUnidad)
        {
            int col = Encoding.ASCII.GetBytes(columna)[0]; //conversion de string a entero en codigo ascci

            NodoOrtogonal nuevoNodo = new NodoOrtogonal(fila, col, ref nuevaUnidad);
            Encabezado encabezadoFila = ncbzdoFilas.buscarEncabezado(fila);
            if (encabezadoFila == null)
            {
                encabezadoFila = new Encabezado(fila);
                ncbzdoFilas.insertar(ref encabezadoFila);
                encabezadoFila.accesoNodo = nuevoNodo;
            }
            else
            {
                /* Pregunto si hay un nodo en el mismo nivel que el nuevo que se va a insertar para ubicarlo posteriormente*/
                NodoOrtogonal nodoEncontrado = existeNodoEnNivel(ref encabezadoFila.accesoNodo, nuevoNodo.unidad.nivel);
                /*  El nuevo nodo esta por delante de la columna del nodoAcceso de la cabecera por tanto 
                    es una insercion adelante*/

                if (nuevoNodo.columna < encabezadoFila.accesoNodo.columna)
                {
                    if (nodoEncontrado != null) //esto significa que se encontro un nivel proximo enlasable por tanto se enlaza
                    {
                        nodoEncontrado.izquierda = nuevoNodo;
                        nuevoNodo.derecha = nodoEncontrado;
                        encabezadoFila.accesoNodo = nuevoNodo;
                    }
                    else
                    {
                        nuevoNodo.derecha = encabezadoFila.accesoNodo;
                        encabezadoFila.accesoNodo.izquierda = nuevoNodo;
                        encabezadoFila.accesoNodo = nuevoNodo;
                    }
                }
                else if (encabezadoFila.accesoNodo.columna == nuevoNodo.columna) //estan en la misma columna
                {
                    /* aca el nodoEncotrado tienen que ser null proque si es distinto que null estan en la misma posciion
                      ya que entranron a esta sentencia if por la misma columna*/
                    if (nodoEncontrado == null)
                    {
                        /* hacemos un enlace entre niveles ya que tenemos ventaja que estan en la misma columna*/
                        bool enlazo = enlazarEntreNiveles(ref encabezadoFila.accesoNodo, ref nuevoNodo);
                        if (enlazo) /* pregunto si el enlace fue exitoso entre columnas*/
                        {
                            /* con el NodoCandidato solo es aplicable cuando hay un enlace en lamisma columna 
                             * por tanto me interesa moverme hacia la derecha
                             * Estructura:
                              buscarNodoCandidatoFilas(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo,int ladoZ,int ladoX)*/
                            buscar_enlazarNodoCandidatoFila(ref nuevoNodo);
                            if (nuevoNodo.unidad.nivel == 1)
                                encabezadoFila.accesoNodo = nuevoNodo;
                            else if (nuevoNodo.unidad.nivel < encabezadoFila.accesoNodo.unidad.nivel && encabezadoFila.accesoNodo.unidad.nivel != 1)
                                encabezadoFila.accesoNodo = nuevoNodo;
                        }
                    }
                    else
                    {
                        //MessageBox.Show("El elemento ya existe");
                        return;
                    }
                }
                else if (nuevoNodo.unidad.nivel == encabezadoFila.accesoNodo.unidad.nivel) //si estan al mismo nivel
                {
                    //verificar  que no existe un nodo en la misma posicion  que le corresponde pero que ya esta
                    int contadorX = 0;
                    NodoOrtogonal posicionOcupada = verificarExistenciaPosNodoFila(ref encabezadoFila.accesoNodo, ref nuevoNodo, ref encabezadoFila.accesoNodo, ref contadorX, ref contadorX);
                    if (posicionOcupada == null)
                    {
                        if (enlazarIzqDer(ref encabezadoFila.accesoNodo, ref nuevoNodo))
                        {
                            /*--------------------------------------<VERIFICACION ENLACE ENTRE NIVELES>-----------------------*/
                            verificarEnlaceNivelesIzqDer_Adelante(ref encabezadoFila.accesoNodo, ref nuevoNodo, ref encabezadoFila.accesoNodo);
                            verificarEnlaceNivelesIzqDer_Atras(ref encabezadoFila.accesoNodo, ref nuevoNodo, ref encabezadoFila.accesoNodo);
                            /*--------------------------------------</VERIFICACION ENLACE ENTRE NIVELES>-----------------------*/
                        }
                    }
                    else
                    {
                        bool banderaEnlace = false;
                        if (posicionOcupada.unidad.nivel != nuevoNodo.unidad.nivel)
                            banderaEnlace = reenlazarPosicionOcupadaFilas(ref posicionOcupada, ref nuevoNodo); /* verificar si la posicion ocupada debe ser rrenlazada*/

                        if (posicionOcupada.columna == nuevoNodo.columna && posicionOcupada.unidad.nivel == nuevoNodo.unidad.nivel)
                        {
                           // MessageBox.Show("La posicion ya existe");
                            return;
                        }
                        if (!banderaEnlace)
                        {
                            /* hacemos un enlace entre niveles ya que tenemos ventaja que estan en la misma columna*/
                            bool enlazo = enlazarEntreNiveles(ref posicionOcupada, ref nuevoNodo);
                            if (enlazo) /* pregunto si el enlace fue exitoso entre columnas*/
                            {
                                buscar_enlazarNodoCandidatoFila(ref nuevoNodo);
                            }
                        }

                    }

                }
                else //el nuevo nodo esta en medio.... Que nivel?... saber....
                {
                    if (nodoEncontrado != null) //encontro el que dirige el nivel  del lado filas donde estara en nuevoNodo
                    {
                        int contadorX = 0;
                        NodoOrtogonal posicionOcupada = verificarExistenciaPosNodoFila(ref nodoEncontrado, ref nuevoNodo, ref nodoEncontrado, ref contadorX, ref contadorX);
                        if (posicionOcupada == null)
                        {
                            if (enlazarIzqDer(ref nodoEncontrado, ref nuevoNodo))
                            {
                                if (nodoEncontrado.adelante != null)
                                    verificarEnlaceNivelesIzqDer_Adelante(ref nodoEncontrado, ref nuevoNodo, ref nodoEncontrado);
                                if (nodoEncontrado.atras != null)
                                    verificarEnlaceNivelesIzqDer_Atras(ref nodoEncontrado, ref nuevoNodo, ref nodoEncontrado);
                            }
                        }
                        else
                        {
                            bool banderaEnlace = false;
                            if (posicionOcupada.unidad.nivel != nuevoNodo.unidad.nivel)
                                banderaEnlace = reenlazarPosicionOcupadaFilas(ref posicionOcupada, ref nuevoNodo); /* verificar si la posicion ocupada debe ser rrenlazada*/

                            if (posicionOcupada.columna == nuevoNodo.columna && posicionOcupada.unidad.nivel == nuevoNodo.unidad.nivel)
                            {
                               // MessageBox.Show("La posicion ya existe");
                                return;
                            }
                            if (!banderaEnlace)
                            {
                                bool enlazo = enlazarEntreNiveles(ref posicionOcupada, ref nuevoNodo);
                                if (enlazo) /* pregunto si el enlace fue exitoso entre columnas*/
                                {
                                    buscar_enlazarNodoCandidatoFila(ref nuevoNodo);
                                }
                            }
                        }
                    }
                    else /* si Nodo encontrado es null significa que nadi dirige ese nivel de lado de filas*/
                    {
                        int contadorX = 0;
                        NodoOrtogonal posicionOcupada = verificarExistenciaPosNodoFila(ref encabezadoFila.accesoNodo, ref nuevoNodo, ref  encabezadoFila.accesoNodo, ref contadorX, ref contadorX);
                        if (posicionOcupada == null)
                        {
                            if (enlazarIzqDer(ref encabezadoFila.accesoNodo, ref nuevoNodo))
                            {
                                /*-------------------------------<BuscandoEnlaceMasProximoIzqDer>-----------------------------------------------*/
                                if (nuevoNodo.izquierda != null)
                                    encontrarEnlaceIzq(ref nuevoNodo.izquierda, ref nuevoNodo, ref nuevoNodo);
                                if (nuevoNodo.derecha != null)
                                    encontrarEnlaceDer(ref nuevoNodo.derecha, ref nuevoNodo, ref nuevoNodo);
                                /*-------------------------------</BuscandoEnlaceMasProximoIzqDer>-----------------------------------------------*/
                                /*-------------------------------<BuscandoEnlaceEntreNiveles>-----------------------------------------------*/
                                if (encabezadoFila.accesoNodo.adelante != null)
                                    verificarEnlaceNivelesIzqDer_Adelante(ref encabezadoFila.accesoNodo, ref nuevoNodo, ref encabezadoFila.accesoNodo);
                                if (encabezadoFila.accesoNodo.atras != null)
                                    verificarEnlaceNivelesIzqDer_Atras(ref encabezadoFila.accesoNodo, ref nuevoNodo, ref encabezadoFila.accesoNodo);
                                /*-------------------------------</BuscandoEnlaceEntreNiveles>-----------------------------------------------*/
                            }
                        }
                        else /* si posicion Ocupada es distinta de null significa que alguien tiene esa posicion pero es de distinto nivel*/
                        {
                            bool enlazo = enlazarEntreNiveles(ref posicionOcupada, ref nuevoNodo);
                            if (enlazo) /* pregunto si el enlace fue exitoso entre columnas*/
                            {
                                buscar_enlazarNodoCandidatoFila(ref nuevoNodo);
                            }
                        }
                    }

                }

            }

            /*-------------------------------------------------- Inicio del analisis de Insercion de COLUMNAS ------------------------------------------*/
            Encabezado encabezadoCol = ncbzdoColumnas.buscarEncabezado(col);
            if (encabezadoCol == null)
            {
                encabezadoCol = new Encabezado(col);
                ncbzdoColumnas.insertar(ref encabezadoCol);
                encabezadoCol.accesoNodo = nuevoNodo;
            }
            else
            {
                NodoOrtogonal nodoEncontrado = existeNodoEnNivel(ref encabezadoCol.accesoNodo, nuevoNodo.unidad.nivel);

                if (nuevoNodo.fila < encabezadoCol.accesoNodo.fila) //si el nuevo nodo es menor que el que se tiene acceso
                {
                    if (nodoEncontrado != null) //esto significa que se encontro un nivel proximo enlasable por tanto se enlaza
                    {
                        nodoEncontrado.arriba = nuevoNodo;
                        nuevoNodo.abajo = nodoEncontrado;
                        encabezadoCol.accesoNodo = nuevoNodo;
                    }
                    else
                    {
                        nuevoNodo.abajo = encabezadoCol.accesoNodo;
                        encabezadoCol.accesoNodo.arriba = nuevoNodo;
                        encabezadoCol.accesoNodo = nuevoNodo;
                    }

                }
                else if (encabezadoCol.accesoNodo.fila == nuevoNodo.fila) //estan en la misma Fila
                {
                    if (nodoEncontrado == null) //si nodoEncontrado != null es porque ya fue agregado por las filas
                    {
                        buscar_enlazarNodoCandidatoCol(ref nuevoNodo);
                    }
                    else
                    {
                        buscar_enlazarNodoCandidatoCol(ref nuevoNodo);
                        if (nuevoNodo.unidad.nivel == 1)
                            encabezadoCol.accesoNodo = nuevoNodo;
                        else if (nuevoNodo.unidad.nivel < encabezadoCol.accesoNodo.unidad.nivel && encabezadoCol.accesoNodo.unidad.nivel != 1)
                            encabezadoCol.accesoNodo = nuevoNodo;
                    }

                }
                else if (nuevoNodo.unidad.nivel == encabezadoCol.accesoNodo.unidad.nivel) //estan en el mismo nivel
                {
                    int contadorY = 0;
                    NodoOrtogonal posicionOcupada = verificarExistenciaPosNodoCol(ref encabezadoCol.accesoNodo, ref nuevoNodo, ref encabezadoCol.accesoNodo, ref contadorY, ref contadorY);
                    if (posicionOcupada == null || posicionOcupada == nuevoNodo)
                    {
                        enlazarArribaAbajo(ref encabezadoCol.accesoNodo, ref nuevoNodo);
                    }
                    else
                    {
                        bool banderaEnlace = false;
                        if (posicionOcupada.unidad.nivel != nuevoNodo.unidad.nivel)
                            banderaEnlace = reenlazarPosicionOcupadaColumnas(ref posicionOcupada, ref nuevoNodo);

                        if (posicionOcupada.fila == nuevoNodo.fila && posicionOcupada.unidad.nivel == nuevoNodo.unidad.nivel)
                        {
                            //MessageBox.Show("La posicion ya existe");
                            return;
                        }
                        if (!banderaEnlace)
                        {
                            buscar_enlazarNodoCandidatoCol(ref nuevoNodo);
                        }

                    }
                }
                else
                {
                    if (nodoEncontrado != null)
                    {
                        int contadorY = 0;
                        NodoOrtogonal posicionOcupada = verificarExistenciaPosNodoCol(ref nodoEncontrado, ref nuevoNodo, ref nodoEncontrado, ref contadorY, ref contadorY);
                        if (posicionOcupada == null || posicionOcupada == nuevoNodo)
                        {
                            enlazarArribaAbajo(ref nodoEncontrado, ref nuevoNodo);
                        }
                        else
                        {
                            bool banderaEnlace = false;
                            if (posicionOcupada.unidad.nivel != nuevoNodo.unidad.nivel)
                                banderaEnlace = reenlazarPosicionOcupadaColumnas(ref posicionOcupada, ref nuevoNodo);

                            if (posicionOcupada.fila == nuevoNodo.fila && posicionOcupada.unidad.nivel == nuevoNodo.unidad.nivel)
                            {
                                //MessageBox.Show("La posicion ya existe");
                                return;
                            }
                            if (!banderaEnlace)
                            {
                                buscar_enlazarNodoCandidatoCol(ref nuevoNodo);
                            }
                        }
                    }
                    else
                    {
                        int contadorY = 0;
                        NodoOrtogonal posicionOcupada = verificarExistenciaPosNodoCol(ref encabezadoCol.accesoNodo, ref nuevoNodo, ref encabezadoCol.accesoNodo, ref contadorY, ref contadorY);
                        if (posicionOcupada == null || posicionOcupada == nuevoNodo)
                        {
                            if (enlazarArribaAbajo(ref encabezadoCol.accesoNodo, ref nuevoNodo))
                            {
                                if (nuevoNodo.arriba != null)
                                    encontrarEnlaceAba(ref nuevoNodo.arriba, ref nuevoNodo, ref nuevoNodo);
                                if (nuevoNodo.abajo != null)
                                    encontrarEnlaceAjo(ref nuevoNodo.abajo, ref nuevoNodo, ref nuevoNodo);
                            }
                        }
                        else
                        {
                            if (posicionOcupada.fila == nuevoNodo.fila && posicionOcupada.unidad.nivel == nuevoNodo.unidad.nivel)
                            {
                                //MessageBox.Show("La posicion ya existe");
                                return;
                            }
                            else
                            {

                            }
                            buscar_enlazarNodoCandidatoCol(ref nuevoNodo);
                        }
                    }
                }
            }
        }
         public void buscar_enlazarNodoCandidatoCol(ref NodoOrtogonal nuevoNodo)
        {
            /*abajo*/
            NodoOrtogonal NodoCandidato = null;
            NodoCandidato = buscarNodoCandidatoCol(ref nuevoNodo.adelante, ref nuevoNodo, 0, 0);
            if (NodoCandidato == null)
                NodoCandidato = buscarNodoCandidatoCol(ref nuevoNodo.atras, ref nuevoNodo, 1, 0);

            if (NodoCandidato != null) //encontro un nodo con el cual puede enlazarse  en el mismo nivel
            {
                bool bandera = true;
                if (NodoCandidato.abajo != null)
                    if (NodoCandidato.abajo == nuevoNodo)
                        bandera = false;
                if (NodoCandidato.arriba != null)
                    if (NodoCandidato.arriba == nuevoNodo)
                        bandera = false;
                if(bandera)
                {
                    romperEnlaceNodoCol(ref NodoCandidato, ref nuevoNodo); //quita los enlaces de sus laterales Izq o Der para enlazarse sin problemas con el nuevo
                    nuevoNodo.abajo = NodoCandidato;
                    NodoCandidato.arriba = nuevoNodo;
                }

            }
            /*arriba*/
            NodoOrtogonal NodoCandidatoAba = null;
            NodoCandidatoAba = buscarNodoCandidatoCol(ref nuevoNodo.adelante, ref nuevoNodo, 0, 1);
            if (NodoCandidatoAba == null)
                NodoCandidatoAba = buscarNodoCandidatoCol(ref nuevoNodo.atras, ref nuevoNodo, 1, 1);
            //NodoOrtogonal NodoCandidatoIzq = buscarNodoProximo(ref posicionOcupada.izquierda, ref nuevoNodo, ref posicionOcupada);
            if (NodoCandidatoAba != null)
            {
                bool bandera = true;
                if (NodoCandidatoAba.abajo != null)
                    if (NodoCandidatoAba.abajo == nuevoNodo)
                        bandera = false;
                if (NodoCandidatoAba.arriba != null)
                    if (NodoCandidatoAba.arriba == nuevoNodo)
                        bandera = false;
                if(bandera)
                {
                    romperEnlaceNodoCol(ref NodoCandidatoAba, ref nuevoNodo);
                    nuevoNodo.arriba = NodoCandidatoAba;
                    NodoCandidatoAba.abajo = nuevoNodo;
                }

            }
        }
        public void buscar_enlazarNodoCandidatoFila(ref NodoOrtogonal nuevoNodo)
        {
            /*Derecha*/
            NodoOrtogonal NodoCandidato = null;
            NodoCandidato = buscarNodoCandidatoFilas(ref nuevoNodo.adelante, ref nuevoNodo, 0, 0);
            if (NodoCandidato == null)
                NodoCandidato = buscarNodoCandidatoFilas(ref nuevoNodo.atras, ref nuevoNodo, 1, 0);
            if (NodoCandidato != null) //encontro un nodo con el cual puede enlazarse  en el mismo nivel
            {
                bool banderaDer = true;
                if (NodoCandidato.izquierda != null)
                    if (NodoCandidato.izquierda == nuevoNodo)
                        banderaDer = false;
                if (NodoCandidato.derecha != null)
                    if (NodoCandidato.derecha == nuevoNodo)
                        banderaDer = false;
                if(banderaDer)
                {
                    romperEnlacesNodoFila(ref NodoCandidato, ref nuevoNodo); //quita los enlaces de sus laterales Izq o Der para enlazarse sin problemas con el nuevo
                    nuevoNodo.derecha = NodoCandidato;
                    NodoCandidato.izquierda = nuevoNodo;
                }

            }
            /*Izquierda*/
            NodoOrtogonal NodoCandidatoIzq = null;
            NodoCandidatoIzq = buscarNodoCandidatoFilas(ref nuevoNodo.adelante, ref nuevoNodo, 0 , 1);
            if (NodoCandidatoIzq == null)
                NodoCandidatoIzq = buscarNodoCandidatoFilas(ref nuevoNodo.atras, ref nuevoNodo, 1, 1);
            //NodoOrtogonal NodoCandidatoIzq = buscarNodoProximo(ref posicionOcupada.izquierda, ref nuevoNodo, ref posicionOcupada);
            if (NodoCandidatoIzq != null)
            {
                bool banderaIzq = true;
                if(NodoCandidatoIzq.izquierda != null)
                    if (NodoCandidatoIzq.izquierda == nuevoNodo)
                        banderaIzq = false;
                if (NodoCandidatoIzq.derecha != null)
                    if (NodoCandidatoIzq.derecha == nuevoNodo)
                        banderaIzq = false;
                if(banderaIzq)
                {
                    romperEnlacesNodoFila(ref NodoCandidatoIzq, ref nuevoNodo);
                    nuevoNodo.izquierda = NodoCandidatoIzq;
                    NodoCandidatoIzq.derecha = nuevoNodo;
                }

            }
        }
        public bool reenlazarPosicionOcupadaColumnas(ref NodoOrtogonal posicionOcupada, ref NodoOrtogonal nuevoNodo)
        {
            bool accionar = false;
            if (posicionOcupada.arriba != null && posicionOcupada.abajo != null)
                if (posicionOcupada.arriba.unidad.nivel == nuevoNodo.unidad.nivel || posicionOcupada.abajo.unidad.nivel == nuevoNodo.unidad.nivel)
                    accionar = true;
            else if (posicionOcupada.arriba != null)
                if (posicionOcupada.arriba.unidad.nivel == nuevoNodo.unidad.nivel)
                    accionar = true;
            else if (posicionOcupada.abajo != null)
                if (posicionOcupada.abajo.unidad.nivel == nuevoNodo.unidad.nivel)
                    accionar = true;
            if (accionar)
            {
                Unidad nueva = new Unidad(posicionOcupada.unidad.nivel, posicionOcupada.unidad.tipoUnidad, posicionOcupada.unidad.idUnidad);
                int f = posicionOcupada.fila;
                int c = posicionOcupada.columna;
                posicionOcupada.unidad = nuevoNodo.unidad;
                posicionOcupada.fila = nuevoNodo.fila;
                posicionOcupada.columna = nuevoNodo.columna;
                string conversion = Convert.ToChar(c).ToString();
                insertar(f, conversion, ref nueva);
                return true;
            }
            return false;
        }
        public bool reenlazarPosicionOcupadaFilas(ref NodoOrtogonal posicionOcupada, ref NodoOrtogonal nuevoNodo)
        {
            bool accionar = false  ;
            if(posicionOcupada.izquierda != null && posicionOcupada.derecha != null)
                if (posicionOcupada.izquierda.unidad.nivel == nuevoNodo.unidad.nivel || posicionOcupada.derecha.unidad.nivel == nuevoNodo.unidad.nivel)
                    accionar = true;
            else if (posicionOcupada.izquierda != null)
                if (posicionOcupada.izquierda.unidad.nivel == nuevoNodo.unidad.nivel)
                    accionar = true;
            else if(posicionOcupada.derecha != null)
                if (posicionOcupada.derecha.unidad.nivel == nuevoNodo.unidad.nivel)
                    accionar = true;
            if(accionar)
            {
                Unidad nueva = new Unidad(posicionOcupada.unidad.nivel, posicionOcupada.unidad.tipoUnidad, posicionOcupada.unidad.idUnidad);
                int f = posicionOcupada.fila;
                int c = posicionOcupada.columna;
                posicionOcupada.unidad = nuevoNodo.unidad;
                posicionOcupada.fila = nuevoNodo.fila;
                posicionOcupada.columna = nuevoNodo.columna;
                string conversion = Convert.ToChar(c).ToString();
                insertar(f, conversion, ref nueva);
                return true;
            }
            return false;
        }
        public bool encontrarEnlaceAba(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo, ref NodoOrtogonal nodoAnterior)
        {
            if (actual != null)
            {
                int ladoZ = verificarLadoNivel(ref actual, ref nuevo);
                int ladoY = verificarLadoArribaAbajo(ref actual, ref nuevo);
                NodoOrtogonal nodoUltimo = null;
                if (ladoZ == 0) //el nuevo esta hacia atras
                {
                    if (actual.atras == null && actual.unidad.nivel != nodoAnterior.unidad.nivel) //por sinose mueve sobre elmismo nivel
                        nodoUltimo = actual;
                    else if (actual.atras != nodoAnterior)
                    {
                        bool encontro = encontrarEnlaceAba(ref actual.atras, ref nuevo, ref actual);
                        if (encontro)
                            return true;
                    }
                }
                else if (ladoZ == 1) //el nuevo esta hacia adelante
                {
                    if (actual.adelante == null && actual.unidad.nivel != nodoAnterior.unidad.nivel) //por sinose mueve sobre elmismo nivel
                        nodoUltimo = actual;
                    else if (actual.adelante != nodoAnterior)
                    {
                        bool encontro = encontrarEnlaceAba(ref actual.adelante, ref nuevo, ref actual);
                        if (encontro)
                            return true;
                    }
                }
                else if (ladoZ == 2) //estan en el mismo nivel
                {
                    if(nuevo.arriba != actual)
                    {
                        nuevo.arriba.abajo = null;
                        nuevo.arriba = null;
                        if (enlazarArribaAbajo(ref actual, ref nuevo))
                            return true;
                    }
                    return false;
                }

                if (nodoUltimo != null)
                {
                    if (nuevo.arriba != null)
                    {
                        if (nodoUltimo.unidad.nivel < nuevo.arriba.unidad.nivel)
                        {
                            if(nuevo.arriba != actual)
                            {
                                /* rompemos sus enlaces para poder ser re-insertado nuevamente*/
                                nuevo.arriba.abajo = null;
                                nuevo.arriba = null;
                                if (enlazarArribaAbajo(ref nodoUltimo, ref nuevo))
                                    return true;
                            }
                            return false;

                        }
                    }
                    else return false;
                }
                if (ladoY == 0) //el nuevo esta hacia la abajo
                    encontrarEnlaceIzq(ref actual.arriba, ref nuevo, ref actual);
            }
            return false;
        }

        public bool encontrarEnlaceAjo(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo,ref NodoOrtogonal nodoAnterior)
        {
            if(actual != null)
            {
                int ladoZ = verificarLadoNivel(ref actual, ref nuevo);
                int ladoY = verificarLadoArribaAbajo(ref actual, ref nuevo);
                NodoOrtogonal nodoUltimo = null;
                if (ladoZ == 0) //el nuevo esta hacia atras
                {
                    if (actual.atras == null && actual.unidad.nivel != nodoAnterior.unidad.nivel) //por sinose mueve sobre elmismo nivel
                        nodoUltimo = actual;
                    else
                        return encontrarEnlaceAjo(ref actual.atras, ref nuevo, ref actual);
                }
                else if (ladoZ == 1) //el nuevo esta hacia adelante
                {
                    if (actual.adelante == null && actual.unidad.nivel != nodoAnterior.unidad.nivel) //por sinose mueve sobre elmismo nivel
                        nodoUltimo = actual;
                    else
                        return encontrarEnlaceAjo(ref actual.adelante, ref nuevo, ref actual);
                }
                else if (ladoZ == 2) //estan en el mismo nivel
                {
                    if(nuevo.abajo != actual)
                    {
                        nuevo.abajo.arriba = null;
                        nuevo.abajo = null;
                        if (enlazarArribaAbajo(ref actual, ref nuevo))
                            return true;
                    }
                    return false;

                }
                if (nodoUltimo != null)
                {
                    if (nuevo.abajo != null)
                    {
                        if (nodoUltimo.unidad.nivel < nuevo.abajo.unidad.nivel)
                        {
                            /* rompemos sus enlaces para poder ser re-insertado nuevamente*/
                            if(nuevo.abajo != actual)
                            {
                                nuevo.abajo.arriba = null;
                                nuevo.abajo = null;
                                if (enlazarArribaAbajo(ref nodoUltimo, ref nuevo))
                                    return true;
                            }
                            return false;
                        }
                    }
                    else return false;
                }
                if (ladoY == 1) //el nuevo esta hacia la arriba
                    return encontrarEnlaceDer(ref actual.abajo, ref nuevo, ref actual);
            }
            return false;
        }

        public bool encontrarEnlaceIzq(ref NodoOrtogonal actual,ref NodoOrtogonal nuevo, ref NodoOrtogonal nodoAnterior)
        {
            if(actual != null)
            {
                int ladoZ = verificarLadoNivel(ref actual, ref nuevo);
                int ladoX = verificarLadoIzqDer(ref actual, ref nuevo);
                NodoOrtogonal nodoUltimo = null;
                if (ladoZ == 0) //el nuevo esta hacia abajo
                {
                    if(actual.atras == null  && actual.unidad.nivel != nodoAnterior.unidad.nivel) //por sinose mueve sobre elmismo nivel
                        nodoUltimo = actual;
                    else if(actual.atras != nodoAnterior)
                    {
                        bool encontro = encontrarEnlaceIzq(ref actual.atras,ref nuevo, ref actual);
                        if(encontro)
                            return true;
                    }
                }
                else if(ladoZ == 1) //el nuevo esta hacia arriba
                {
                    if (actual.adelante == null && actual.unidad.nivel != nodoAnterior.unidad.nivel) //por sinose mueve sobre elmismo nivel
                        nodoUltimo = actual;
                    else if(actual.adelante != nodoAnterior)
                    {
                        bool encontro = encontrarEnlaceIzq(ref actual.adelante, ref nuevo, ref actual);
                        if (encontro)
                            return true;
                    }
                }
                else if(ladoZ == 2) //estan en el mismo nivel
                {
                    if(nuevo.izquierda != actual)
                    {
                        nuevo.izquierda.derecha = null;
                        nuevo.izquierda = null;
                        if (enlazarIzqDer(ref actual, ref nuevo))
                            return true;
                    }
                     return false;
                }

                if(nodoUltimo != null)
                {
                    if (nuevo.izquierda != null)
                    {
                        if (nodoUltimo.unidad.nivel < nuevo.izquierda.unidad.nivel)
                        {
                            /* rompemos sus enlaces para poder ser re-insertado nuevamente*/
                            if(actual.izquierda != actual)
                            {
                                nuevo.izquierda.derecha = null;
                                nuevo.izquierda = null;
                                if (enlazarIzqDer(ref nodoUltimo, ref nuevo))
                                    return true;
                            }
                            return false;
                        }
                    }
                    else return false;
                }
                if (ladoX == 0) //el nuevo esta hacia la derecha
                    encontrarEnlaceIzq(ref actual.izquierda, ref nuevo, ref actual);
            }
            return false;
        }

        public bool encontrarEnlaceDer(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo, ref NodoOrtogonal nodoAnterior)
        {
            if (actual != null)
            {
                int ladoZ = verificarLadoNivel(ref actual, ref nuevo);
                int ladoX = verificarLadoIzqDer(ref actual, ref nuevo);
                NodoOrtogonal nodoUltimo = null;
                if (ladoZ == 0) //el nuevo esta hacia abajo
                {
                    if (actual.atras == null && actual.unidad.nivel != nodoAnterior.unidad.nivel) //por sinose mueve sobre elmismo nivel
                        nodoUltimo = actual;
                    else
                        return encontrarEnlaceDer(ref actual.atras, ref nuevo, ref actual);
                }
                else if (ladoZ == 1) //el nuevo esta hacia arriba
                {
                    if (actual.adelante == null && actual.unidad.nivel != nodoAnterior.unidad.nivel) //por sinose mueve sobre elmismo nivel
                        nodoUltimo = actual;
                    else
                        return encontrarEnlaceDer(ref actual.adelante, ref nuevo, ref actual);
                }
                else if (ladoZ == 2) //estan en el mismo nivel
                {
                    if(nuevo.derecha != actual)
                    {
                        nuevo.derecha.izquierda = null;
                        nuevo.derecha = null;
                        if (enlazarIzqDer(ref actual, ref nuevo))
                            return true;
                    }
                    return false;
                }

                if (nodoUltimo != null)
                {
                    if (nuevo.derecha != null)
                    {
                        if (nodoUltimo.unidad.nivel < nuevo.derecha.unidad.nivel)
                        {
                            /* rompemos sus enlaces para poder ser re-insertado nuevamente*/
                            if(nuevo.derecha != actual)
                            {
                                nuevo.derecha.izquierda = null;
                                nuevo.derecha = null;
                                if (enlazarIzqDer(ref nodoUltimo, ref nuevo))
                                    return true;
                            }
                            return false;
                        }
                    }
                    else return false;
                }
                if (ladoX == 1) //el nuevo esta hacia la Derecha
                    return encontrarEnlaceDer(ref actual.derecha, ref nuevo, ref actual);
            }
            return false;
        }
        
        public bool enlazarArribaAbajo(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo)
        {
            int ladoY = verificarLadoArribaAbajo(ref actual, ref nuevo);
            if (ladoY == 0) //hacia abajo
            {
                NodoOrtogonal tmpAjo = actual;
                while (tmpAjo.abajo != null)
                {
                    if (nuevo.fila < tmpAjo.abajo.fila)
                    {
                        nuevo.abajo = tmpAjo.abajo;
                        tmpAjo.abajo.arriba = nuevo;
                        tmpAjo.abajo = nuevo;
                        nuevo.arriba = tmpAjo;
                        return  true;
                    }
                    tmpAjo = tmpAjo.abajo;
                }
                if (tmpAjo.abajo == null)
                {
                    tmpAjo.abajo = nuevo;
                    nuevo.arriba = tmpAjo;
                    return true;
                }
            }
            else if (ladoY == 1)
            {
                NodoOrtogonal tmpAba = actual;
                while (tmpAba.arriba != null)
                {
                    if (nuevo.fila > tmpAba.arriba.fila)
                    {
                        nuevo.arriba = tmpAba.arriba;
                        tmpAba.arriba.abajo = nuevo;
                        tmpAba.arriba = nuevo;
                        nuevo.abajo = tmpAba;
                        return true;
                    }
                    tmpAba = tmpAba.arriba;
                }
                if (tmpAba.arriba == null)
                {
                    tmpAba.arriba = nuevo;
                    nuevo.abajo = tmpAba;
                    return true;
                }
            }
            return false;
        }
        public NodoOrtogonal verificarExistenciaPosNodoCol(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo, ref NodoOrtogonal nodoAnterior,ref int ladoYanterior,ref int contadorY )
        {
            if(actual != null)
            {
                if (contadorY == 6)
                    return null;
                int ladoY = verificarLadoArribaAbajo(ref actual, ref nuevo);
                if (ladoY != ladoYanterior)
                    contadorY++;
                if(actual.adelante != null && actual.adelante != nodoAnterior)
                {
                    NodoOrtogonal posNodo = verificarExistenciaPosNodoCol(ref actual.adelante, ref nuevo, ref actual,ref ladoY,ref contadorY);
                    if (posNodo != null)
                        return posNodo;
                }
                if (ladoY == 0) //abajo
                {
                    if (actual.abajo != null && actual.abajo != nodoAnterior)
                    {
                        NodoOrtogonal posNodo = verificarExistenciaPosNodoCol(ref actual.abajo, ref nuevo, ref actual, ref ladoY, ref contadorY);
                        if (posNodo != null)
                            return posNodo;
                    }
                }
                else if (ladoY == 1) //arriba
                {
                    if (actual.arriba != null && actual.arriba != nodoAnterior)
                    {
                        NodoOrtogonal posNodo = verificarExistenciaPosNodoCol(ref actual.arriba, ref nuevo, ref actual, ref ladoY, ref contadorY);
                        if (posNodo != null)
                            return posNodo;
                    }
                }
                else if (ladoY == 2) //esta en la misma fila
                    return actual;

                if(actual.atras != null && actual.atras != nodoAnterior)
                {
                    NodoOrtogonal posNodo = verificarExistenciaPosNodoCol(ref actual.atras, ref nuevo, ref actual, ref ladoY, ref contadorY);
                    if (posNodo != null)
                        return posNodo;
                }
            }
            return null;
        }

        public void romperEnlaceNodoCol(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo)
        {
            if (actual.arriba != null)
            {
                if (actual.arriba.unidad.nivel != nuevo.unidad.nivel)
                {
                    actual.arriba.abajo = null;
                    actual.arriba = null;
                }
            }
            if (actual.abajo != null)
            {
                if (actual.abajo.unidad.nivel != nuevo.unidad.nivel)
                {
                    actual.abajo.arriba = null;
                    actual.abajo = null;
                }
            }
        }

        public NodoOrtogonal buscarNodoCandidatoCol(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo,   int ladoZ,  int ladoY)
        {
            if(actual != null)
            {
                NodoOrtogonal candidato = null;
                int contadorZ = 0;
                if (ladoY == 0) //hacia abajo
                {
                    candidato = buscarNodoProximoCol(ref actual.abajo, ref nuevo, ref actual,ref ladoZ, ref contadorZ);
                    if (candidato != null)
                        return candidato;
                }
                else if (ladoY == 1) //hacia la arriba
                {
                    candidato = buscarNodoProximoCol(ref actual.arriba, ref nuevo, ref actual, ref ladoZ, ref contadorZ);
                    if (candidato != null)
                        return candidato;
                }
                if (ladoZ == 0) //el  nuevo elemento esta hacia atras pero debo moverme hacia adelante
                    return buscarNodoCandidatoCol(ref actual.adelante, ref nuevo, ladoZ, ladoY);
                else if (ladoZ == 1) //el nuevo elemento esta hacia adleante pero debo moverme hacia atras
                    return buscarNodoCandidatoCol(ref actual.atras, ref nuevo, ladoZ, ladoY);
            }
            return null;
        }


        public NodoOrtogonal buscarNodoProximoCol(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo, ref  NodoOrtogonal nodoAnterior, ref int ladoZAnterior, ref int contadorZ)
        {
            if (actual != null)
            {
                if (contadorZ == 5)
                    return null;
                int ladoNivel = verificarLadoNivel(ref actual, ref nuevo);
                int ladoY = verificarLadoArribaAbajo(ref actual, ref nuevo);
                if (ladoNivel != ladoZAnterior)
                    contadorZ++;
                if (contadorZ == 5)
                    return null;
                if (ladoNivel == 2) //estan en el mismo nivel
                {
                    if (ladoY == 0) //movimiento hacia abajo
                    {
                        if(actual.abajo != null && actual.abajo.fila > nuevo.columna)
                        {
                            nuevo.abajo = actual.abajo;
                            actual.abajo.arriba = nuevo;
                            actual.abajo = nuevo;
                            nuevo.arriba = actual;
                            return actual;    
                        }
                        if (actual.abajo != null && actual.abajo.fila != nuevo.fila)
                        {
                            if (actual.abajo.unidad.nivel != nuevo.unidad.nivel)
                                return actual;
                            else
                                return buscarNodoProximoCol(ref actual.abajo, ref nuevo, ref actual,ref ladoNivel, ref contadorZ);
                        }
                        return actual;
                    }
                    else if (ladoY == 1) //movimiento hacia arriba
                    {
                        if(actual.arriba != null && actual.arriba.fila < nuevo.fila)
                        {
                            nuevo.arriba = actual.arriba;
                            actual.arriba.abajo = nuevo;
                            actual.arriba = nuevo;
                            nuevo.abajo = actual;
                            return actual;
                        }
                        if (actual.arriba != null && actual.arriba.fila != nuevo.fila)
                        {
                            if (actual.arriba.unidad.nivel != nuevo.unidad.nivel)
                                return actual;
                            else
                                return buscarNodoProximoCol(ref actual.arriba, ref nuevo, ref actual, ref ladoNivel, ref contadorZ);
                        }
                        else
                            return actual;
                    }
                    else if (ladoY == 2)
                        return null;
                }

                if (ladoY == 0)//movimiento hacia abajo
                {
                    if (actual.arriba != null && actual.arriba.fila != nuevo.fila)
                    {
                        if (actual.arriba != nodoAnterior)
                        {
                            NodoOrtogonal tmpAba = buscarNodoProximoCol(ref actual.arriba, ref nuevo, ref actual, ref ladoNivel, ref contadorZ);
                            if (tmpAba != null)
                                return tmpAba;
                        }
                    }
                    /*--------------------------------------- <COMPARACION NIVELES > ----------------------------*/
                    if(ladoNivel == 0)
                    {
                        if (actual.atras != null)
                        {
                            if (actual.atras.unidad.nivel != nodoAnterior.unidad.nivel)
                            {
                                NodoOrtogonal tmpAtras = buscarNodoProximoCol(ref actual.atras, ref nuevo, ref actual, ref ladoNivel, ref contadorZ);
                                if (tmpAtras != null)
                                    return tmpAtras;
                            }
                        }
                    }
                    else if(ladoNivel == 1)
                    {
                        if (actual.adelante != null)
                        {
                            if (actual.adelante.unidad.nivel != nodoAnterior.unidad.nivel)
                            {
                                NodoOrtogonal tmpAtras = buscarNodoProximoCol(ref actual.adelante, ref nuevo, ref actual, ref ladoNivel, ref contadorZ);
                                if (tmpAtras != null)
                                    return tmpAtras;
                            }
                        }
                    }
                    /*--------------------------------------- </COMPARACION NIVELES > ----------------------------*/
                    if (actual.abajo != null && actual.abajo.fila != nuevo.fila)
                    {
                        NodoOrtogonal tmpAjo = null;
                        if (actual.abajo != nodoAnterior)
                        {
                            tmpAjo = buscarNodoProximoCol(ref actual.abajo, ref nuevo, ref actual, ref ladoNivel, ref contadorZ);
                            if (tmpAjo != null)
                                return tmpAjo;
                        }
                    }
                    return null;
                }
                else if (ladoY == 1) //movimiento hacia arriba
                {
                    if (actual.abajo != null && actual.abajo.fila != nuevo.fila)
                    {
                        if (actual.abajo != nodoAnterior)
                        {
                            NodoOrtogonal tmpAjo = buscarNodoProximoCol(ref actual.abajo, ref nuevo, ref actual, ref ladoNivel, ref contadorZ);
                            if (tmpAjo != null)
                                return tmpAjo;
                        }
                    }
                    /*--------------------------------------- <COMPARACION NIVELES > ----------------------------*/
                    if (ladoNivel == 0)
                    {
                        if (actual.atras != null)
                        {
                            if (actual.atras.unidad.nivel != nodoAnterior.unidad.nivel)
                            {
                                NodoOrtogonal tmpAtras = buscarNodoProximoCol(ref actual.atras, ref nuevo, ref actual, ref ladoNivel, ref contadorZ);
                                if (tmpAtras != null)
                                    return tmpAtras;
                            }
                        }
                    }
                    else if (ladoNivel == 1)
                    {
                        if (actual.adelante != null)
                        {
                            if (actual.adelante.unidad.nivel != nodoAnterior.unidad.nivel)
                            {
                                NodoOrtogonal tmpAtras = buscarNodoProximoCol(ref actual.adelante, ref nuevo, ref actual, ref ladoNivel, ref contadorZ);
                                if (tmpAtras != null)
                                    return tmpAtras;
                            }
                        }
                    }
                    /*--------------------------------------- </COMPARACION NIVELES > ----------------------------*/
                    if (actual.arriba != null && actual.arriba.fila != nuevo.fila)
                    {
                        if (actual.arriba != nodoAnterior)
                        {
                            NodoOrtogonal tmpAba = buscarNodoProximoCol(ref actual.arriba, ref nuevo, ref actual, ref ladoNivel, ref contadorZ);
                            if (tmpAba != null)
                                return tmpAba;
                        }
                    }
                    return null;
                }
                else if (ladoY == 2) //estan en la misma fila
                    return null;

            }
            return null;
        }

        public int verificarLadoArribaAbajo(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo)
        {
            /* si  retorn 1 significa que se deber recorrer hacia la Arriba
            *  si retorna 0 debe recorrer hacia la abajo
            *  si  retorna 2 significa que estan en el mismo nivel
            */
                if (nuevo.fila < actual.fila)
                    return 1;
                else if (nuevo.fila > actual.fila)
                    return 0;
                else
                    return 2;


        }

        public bool verificarEnlaceNivelesIzqDer_Atras(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo, ref NodoOrtogonal nodoAnterior)
        {
            if (actual != null)
            {
                int ladoLateral = verificarLadoIzqDer(ref actual, ref nuevo);
                if (ladoLateral == 0) //significa que el nuevo esta  a la derecha
                {
                    if (actual.atras != null)
                    {
                        bool huboEnlace = verificarEnlaceNivelesIzqDer_Atras(ref actual.atras, ref nuevo, ref actual);
                        if (huboEnlace != false)
                            return huboEnlace;
                    }
                    if (actual.derecha != null)
                    {
                        if (actual.derecha != nodoAnterior)
                        {
                            bool huboEnlace = verificarEnlaceNivelesIzqDer_Atras(ref actual.derecha, ref nuevo, ref actual);
                            if (huboEnlace != false)
                                return huboEnlace;
                        }
                    }

                    return false;
                }
                else if (ladoLateral == 1) //significa que el nuevo esta a la izquierda
                {
                    if (actual.atras != null)
                    {
                        bool huboEnlace = verificarEnlaceNivelesIzqDer_Atras(ref actual.atras, ref nuevo, ref actual);
                        if (huboEnlace != false)
                            return huboEnlace;
                    }
                    if (actual.izquierda != null)
                    {
                        if (actual.izquierda != nodoAnterior)
                        {
                            bool huboEnlace = verificarEnlaceNivelesIzqDer_Atras(ref actual.izquierda, ref nuevo, ref actual);
                            if (huboEnlace != false)
                                return huboEnlace;
                        }
                    }
                    return false;
                }
                else if (ladoLateral == 2) //significa  que el nuevo como el actual estan en la misma columna
                {
                    if (actual.unidad.nivel != nuevo.unidad.nivel)
                    {
                        bool enlazo = enlazarEntreNiveles(ref actual, ref nuevo);
                        if (enlazo)
                            return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public bool verificarEnlaceNivelesIzqDer_Adelante(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo, ref NodoOrtogonal nodoAnterior)
        {
            if (actual != null)
            {
                int ladoLateral = verificarLadoIzqDer(ref actual, ref nuevo);
                if (ladoLateral == 0) //significa que el nuevo esta  a la derecha
                {
                    if (actual.adelante != null)
                    {
                        bool huboEnlace = verificarEnlaceNivelesIzqDer_Adelante(ref actual.adelante, ref nuevo, ref actual);
                        if (huboEnlace != false)
                            return huboEnlace;
                    }
                    if (actual.derecha != null)
                    {
                        if (actual.derecha != nodoAnterior)
                        {
                            bool huboEnlace = verificarEnlaceNivelesIzqDer_Adelante(ref actual.derecha, ref nuevo, ref actual);
                            if (huboEnlace != false)
                                return huboEnlace;
                        }
                    }
                    return false;
                }
                else if (ladoLateral == 1) //significa que el nuevo esta a la izquierda
                {
                    if (actual.adelante != null)
                    {
                        bool huboEnlace = verificarEnlaceNivelesIzqDer_Adelante(ref actual.adelante, ref nuevo, ref actual);
                        if (huboEnlace != false)
                            return huboEnlace;
                    }
                    if (actual.izquierda != null)
                    {
                        if (actual.izquierda != nodoAnterior)
                        {
                            bool huboEnlace = verificarEnlaceNivelesIzqDer_Adelante(ref actual.izquierda, ref nuevo, ref actual);
                            if (huboEnlace != false)
                                return huboEnlace;
                        }
                    }
                    return false;
                }
                else if (ladoLateral == 2) //significa  que el nuevo como el actual estan en la misma columna
                {
                    if (actual.unidad.nivel != nuevo.unidad.nivel)
                    {
                        bool enlazo = enlazarEntreNiveles(ref actual, ref nuevo);
                        if (enlazo)
                            return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public NodoOrtogonal verificarExistenciaPosNodoFila(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo,ref NodoOrtogonal nodoAnterior,ref  int ladoXanterior, ref int contadorX)
        {
            if(actual  != null)
            {
                if (contadorX == 7)
                    return null;
                int ladoX = verificarLadoIzqDer(ref actual, ref nuevo);
                if (ladoX != ladoXanterior)
                    contadorX++;

                if (actual.adelante != null && actual.adelante != nodoAnterior)
                {
                    NodoOrtogonal posNodo = verificarExistenciaPosNodoFila(ref actual.adelante, ref nuevo, ref actual, ref ladoX, ref contadorX);
                    if (posNodo != null)
                        return posNodo;
                }
                if(ladoX == 0) //derecha
                {
                    if (actual.derecha != null && actual.derecha != nodoAnterior)
                    {
                        NodoOrtogonal posNodo = verificarExistenciaPosNodoFila(ref actual.derecha, ref nuevo, ref actual, ref ladoX, ref contadorX);
                        if (posNodo != null)
                            return posNodo;
                    }
                }
                else if(ladoX ==1) //ladoIzquierda
                {
                    if (actual.izquierda != null && actual.izquierda != nodoAnterior)
                    {
                        NodoOrtogonal posNodo = verificarExistenciaPosNodoFila(ref actual.izquierda, ref nuevo, ref actual, ref ladoX, ref contadorX);
                        if (posNodo != null)
                            return posNodo;
                    }
                }
                else if(ladoX ==2) //estan en la misma columna
                    return actual;
                    
                if(actual.atras != null && actual.atras != nodoAnterior)
                {
                    NodoOrtogonal posNodo = verificarExistenciaPosNodoFila(ref actual.atras, ref nuevo, ref actual, ref ladoX, ref contadorX);
                    if (posNodo != null)
                        return posNodo;
                }
            }
            return null;
        }
        public void romperEnlacesNodoFila(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo)
        {
            if (actual.izquierda != null)
            {
                if (actual.izquierda.unidad.nivel != nuevo.unidad.nivel)//si los niveles son distintos
                {
                    actual.izquierda.derecha = null;
                    actual.izquierda = null;
                }

            }
            if (actual.derecha != null)
            {
                if (actual.derecha.unidad.nivel != nuevo.unidad.nivel)
                {
                    actual.derecha.izquierda = null;
                    actual.derecha = null;
                }

            }
        }


        public NodoOrtogonal buscarNodoCandidatoFilas(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo,int ladoZ,int ladoX)
        {
            if(actual != null)
            {
                NodoOrtogonal candidato = null;
                int contadorZ = 0;
                if (ladoX == 0) //hacia la derecha
                {
                    candidato = buscarNodoProximo(ref actual.derecha, ref nuevo, ref actual,ref ladoZ,ref contadorZ);
                    if (candidato != null)
                        return candidato;
                }
                else if (ladoX == 1) //hacia la izquierda
                {
                    candidato = buscarNodoProximo(ref actual.izquierda, ref nuevo, ref actual,ref ladoZ,ref contadorZ);
                    if (candidato != null)
                        return candidato;
                }
                if (ladoZ == 0) //el  nuevo elemento esta hacia atras pero debo moverme hacia adelante
                    return buscarNodoCandidatoFilas(ref actual.adelante, ref nuevo, ladoZ,ladoX);
                else if (ladoZ == 1) //el nuevo elemento esta hacia adleante pero debo moverme hacia atras
                    return buscarNodoCandidatoFilas(ref actual.atras, ref nuevo, ladoZ,ladoX);
            }
            return null;
        }


        /*Aplicacable sono cuando se hacen enlaces entreNiles pero de columnas*/
        public NodoOrtogonal buscarNodoProximo(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo, ref NodoOrtogonal nodoAnterior, ref int ladoZAnterior,ref int contadorZ)
        {
            if (actual != null)
            {
                if (contadorZ == 5) //si hay cambios  de parte de Z romper porque puede que sea un ciclo
                    return null;
                 int ladoZ = verificarLadoNivel(ref actual, ref nuevo);
                 int ladoX = verificarLadoIzqDer(ref actual, ref nuevo);
                 if (ladoZ != ladoZAnterior)
                     contadorZ++;

                 ladoX = verificarLadoIzqDer(ref actual, ref nuevo);

                if (ladoZ == 2 ) //estan sobre el mismo nivel
                {
                    //ladoX = verificarLadoIzqDer(ref actual, ref nuevo);
                    if (ladoX == 0) //devo moverme hacia la derecha
                    {

                        if (actual.derecha != null && actual.derecha.columna > nuevo.columna) //hay ciclo
                        {/*por tanto hay que hacer una insercion al medio  y verificar si no fue insertado previamente*/
                            nuevo.derecha = actual.derecha;
                            actual.derecha.izquierda = nuevo;
                            actual.derecha = nuevo;
                            nuevo.izquierda = actual;
                            return actual;
                        }
                        else if (actual.derecha != null && actual.derecha.columna != nuevo.columna)
                            if (actual.derecha.unidad.nivel != nuevo.unidad.nivel) //si el nodo candidato der es distinto que el nivel que debe ser
                                return actual;
                            else
                                return buscarNodoProximo(ref actual.derecha, ref nuevo, ref actual,ref ladoZ,ref contadorZ);
                        else
                            return actual;
                    }
                    else if (ladoX == 1) //devo moverme hacia la izquierda
                    {
                        if (actual.izquierda != null && actual.izquierda.columna < nuevo.columna) //ciclo insercion al medio
                        {
                            nuevo.izquierda = actual.izquierda;
                            actual.izquierda.derecha = nuevo;
                            actual.izquierda = nuevo;
                            nuevo.derecha = actual;
                            return actual;
                        }
                        if (actual.izquierda != null && actual.izquierda.columna != nuevo.columna)
                        {
                            if (actual.izquierda.unidad.nivel != nuevo.unidad.nivel) //si el nodo candidato Izq es distinto que el nivel que debe ser
                                return actual;
                            else
                                return buscarNodoProximo(ref actual.izquierda, ref nuevo, ref actual, ref ladoZ,ref  contadorZ);
                        }
                        else
                            return actual;
                    }
                    else if (ladoX == 2) //estan sobre la misma columna
                        return null;
                }
                if (ladoX == 0) //esta hacia la derecha 
                {
                    /*no permite que colisione con la columna de nuevo ademas de preguntar si izq es null*/
                    if (actual.izquierda != null && actual.izquierda.columna != nuevo.columna)
                    {
                        if (actual.izquierda != nodoAnterior)
                        {
                            NodoOrtogonal tmpIzq = buscarNodoProximo(ref actual.izquierda, ref nuevo, ref actual,ref ladoZ,ref contadorZ);
                            if (tmpIzq != null)
                                return tmpIzq;
                        }
                    }
                    /*--------------------------------------- <COMPARACION NIVELES > ----------------------------*/
                    if (ladoZ == 0)
                    {
                        if (actual.atras != null)
                        {
                            if (actual.atras.unidad.nivel != nodoAnterior.unidad.nivel)
                            {
                                NodoOrtogonal tmpAtras = buscarNodoProximo(ref actual.atras, ref nuevo, ref actual, ref ladoZ, ref contadorZ);
                                if (tmpAtras != null)
                                    return tmpAtras;
                            }
                        }
                    }
                    else if (ladoZ == 1)
                    {
                        if (actual.adelante != null)
                        {
                            if (actual.adelante.unidad.nivel != nodoAnterior.unidad.nivel)
                            {
                                NodoOrtogonal tmpAdelante = buscarNodoProximo(ref actual.adelante, ref nuevo, ref actual, ref ladoZ, ref contadorZ);
                                if (tmpAdelante != null)
                                    return tmpAdelante;
                            }
                        }
                    }
                    /*--------------------------------------- </COMPARACION NIVELES > -----------------------------------*/
                    if (actual.derecha != null && actual.derecha.columna != nuevo.columna) /* no permite colision*/
                    {
                        NodoOrtogonal tmpDer = null;
                        if (actual.derecha != nodoAnterior)
                        {
                            tmpDer = buscarNodoProximo(ref actual.derecha, ref nuevo, ref actual ,ref ladoZ,ref contadorZ);
                            if (tmpDer != null)
                                return tmpDer;
                        }
                    }
                    return null;
                }
                else if (ladoX == 1) //el nuevo esta hacia la izquierda 
                {
                    if (actual.derecha != null && actual.derecha.columna != nuevo.columna)
                    {
                        if (actual.derecha != nodoAnterior)
                        {
                            NodoOrtogonal tmpDer = buscarNodoProximo(ref actual.derecha, ref nuevo, ref actual, ref ladoZ, ref contadorZ);
                            if (tmpDer != null)
                                return tmpDer;
                        }
                    }
                    /*--------------------------------------- <COMPARACION NIVELES > ----------------------------*/
                    if (ladoZ == 0)
                    {
                        if (actual.atras != null)
                        {
                            if (actual.atras.unidad.nivel != nodoAnterior.unidad.nivel)
                            {
                                NodoOrtogonal tmpAtras = buscarNodoProximo(ref actual.atras, ref nuevo, ref actual, ref ladoZ,ref contadorZ);
                                if (tmpAtras != null)
                                    return tmpAtras;
                            }
                        }
                    }
                    else if (ladoZ == 1)
                    {
                        if (actual.adelante != null)
                        {
                            if (actual.adelante.unidad.nivel != nodoAnterior.unidad.nivel)
                            {
                                NodoOrtogonal tmpAdelante = buscarNodoProximo(ref actual.adelante, ref nuevo, ref actual,ref ladoZ,ref contadorZ);
                                if (tmpAdelante != null)
                                    return tmpAdelante;
                            }
                        }
                    }
                    /*--------------------------------------- </COMPARACION NIVELES > -----------------------------------*/
                    if (actual.izquierda != null && actual.izquierda.columna != nuevo.columna)
                    {
                        if (actual.izquierda != nodoAnterior)
                        {
                            NodoOrtogonal tmpIzq = buscarNodoProximo(ref actual.izquierda, ref nuevo, ref actual, ref ladoZ, ref contadorZ);
                            if (tmpIzq != null)
                                return tmpIzq;
                        }
                    }
                    return null;
                }
                else if (ladoX == 2) //estan sobre la misma columna 
                    return null;
            }
            return null;
        }



        public NodoOrtogonal existeNodoEnNivel(ref NodoOrtogonal actual, int nuevoNivel)
        {
            if (actual.unidad.nivel == nuevoNivel)
            {
                return actual;
            }
            else if (nuevoNivel < actual.unidad.nivel) //busca en los niveles de abajo
            {
                if (actual.atras != null)
                {
                    NodoOrtogonal tmpAtras = actual.atras;
                    while (tmpAtras != null)
                    {
                        if (tmpAtras.unidad.nivel == nuevoNivel)
                            return tmpAtras;
                        tmpAtras = tmpAtras.atras;
                    }
                }
                return null;
            }
            else if (nuevoNivel > actual.unidad.nivel) //busca en los niveles de adelante
            {
                if (actual.adelante != null)
                {
                    NodoOrtogonal tmpAdelante = actual.adelante;
                    while (tmpAdelante != null)
                    {
                        if (tmpAdelante.unidad.nivel == nuevoNivel)
                            return tmpAdelante;
                        tmpAdelante = tmpAdelante.adelante;
                    }
                }
                return null;
            }
            return null;
        }

        public bool verificarEnlaceIzqDerNiveles(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo)
        {
            int ladoNivel = verificarLadoNivel(ref actual, ref nuevo);

            switch (ladoNivel)
            {
                case 0: //esta en elnivel de abajo
                    NodoOrtogonal tmpAtras = actual;
                    while (tmpAtras != null)
                    {
                        if (tmpAtras.unidad.nivel == nuevo.unidad.nivel)
                            return enlazarIzqDer(ref tmpAtras, ref nuevo);
                        tmpAtras = tmpAtras.atras;
                    }
                    if (tmpAtras.atras == null)
                        return enlazarIzqDer(ref tmpAtras, ref nuevo);
                    return false;
                    break;

                case 1: //esta en los niveles de arriba
                    NodoOrtogonal tmpAdelante = actual;
                    while (tmpAdelante != null)
                    {
                        if (tmpAdelante.unidad.nivel == nuevo.unidad.nivel)
                            return enlazarIzqDer(ref tmpAdelante, ref nuevo);
                        tmpAdelante = tmpAdelante.adelante;
                    }
                    if (tmpAdelante.adelante == null)
                        return enlazarIzqDer(ref tmpAdelante, ref nuevo);
                    return false;
                    break;

                case 2: //estan en el mismo nivel
                    return enlazarIzqDer(ref actual, ref nuevo);
                    break;

                default:
                    return false;
                    break;
            }
            return false;
        }

        public bool enlazarIzqDer(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo)
        {
            int lado = verificarLadoIzqDer(ref actual, ref nuevo);
            switch (lado)
            {
                case 0: //enlace hacia la derecha
                    NodoOrtogonal tmpDer = actual;
                    while (tmpDer.derecha != null) //insercion al medio
                    {
                        if (nuevo.columna < tmpDer.derecha.columna)
                        {
                            nuevo.derecha = tmpDer.derecha;
                            tmpDer.derecha.izquierda = nuevo;
                            tmpDer.derecha = nuevo;
                            nuevo.izquierda = tmpDer;
                            return true;
                        }
                        tmpDer = tmpDer.derecha;
                    }
                    if (tmpDer.derecha == null) //insercion al ultimo
                    {
                        tmpDer.derecha = nuevo;
                        nuevo.izquierda = tmpDer;
                        return true;
                    }
                    return false;
                    break;

                case 1: //enlace hacia la izquierda;
                    NodoOrtogonal tmpIzq = actual;
                    while (tmpIzq.izquierda != null)
                    {
                        if (nuevo.columna > tmpIzq.izquierda.columna)
                        {
                            nuevo.izquierda = tmpIzq.izquierda;
                            tmpIzq.izquierda.derecha = nuevo;
                            tmpIzq.izquierda = nuevo;
                            nuevo.derecha = tmpIzq;
                            return true;
                        }
                        tmpIzq = tmpIzq.izquierda;
                    }
                    if (tmpIzq.izquierda == null) //enlace al ultimo de la parte izquierda;
                    {
                        tmpIzq.izquierda = nuevo;
                        nuevo.derecha = tmpIzq;
                        return true;
                    }
                    return false;
                    break;

                case 2:  // tanto el nuevoNodo como el actual estan en la misma Columa pero distinto nivel

                    if (actual.derecha != null)
                    {
                        NodoOrtogonal tmpDerNivel = actual.derecha;
                        while (tmpDerNivel != null)
                        {
                            if (verificarEnlaceIzqDerNiveles(ref tmpDerNivel, ref nuevo))
                                return true;
                            tmpDerNivel = tmpDerNivel.derecha;
                        }
                    }
                    if (actual.izquierda != null)
                    {
                        NodoOrtogonal tmpIzqNivel = actual.izquierda;
                        while (tmpIzqNivel != null)
                        {
                            if (verificarEnlaceIzqDerNiveles(ref tmpIzqNivel, ref nuevo))
                                return true;
                            tmpIzqNivel = tmpIzqNivel.izquierda;
                        }
                    }
                    return false;
                    break;

                default:
                    return false;
                    break;
            }
            return false;
        }

        public int verificarLadoNivel(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo)
        {
            /* si  retorn 1 significa que se deber recorrer hacia adelante
             *  si retorna 0 debe recorrer hacia atras
             *  si  retorna 2 significa que estan en el mismo nivel
             */
            if (nuevo.unidad.nivel > actual.unidad.nivel)
                return 1;
            else if (nuevo.unidad.nivel < actual.unidad.nivel)
                return 0;
            else
                return 2;
        }
        public int verificarLadoIzqDer(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo)
        {
            /* si  retorn 1 significa que se deber recorrer hacia la izquierda
            *  si retorna 0 debe recorrer hacia la Derecha
            *  si  retorna 2 significa que estan en el mismo nivel
            */
            if (nuevo.columna < actual.columna) //movimiento hacia la izquierdqa
                return 1;
            else if (nuevo.columna > actual.columna) //movimiento hacia la izquierda
                return 0;
            else            // estan en el mismo nivel
                return 2;
        }

        public bool enlazarEntreNiveles(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo)
        {
            if (yaExisteEnlaceEntreNivel(ref actual, ref nuevo))
                return false;
            int ladoNivel = verificarLadoNivel(ref actual, ref nuevo);
            if (ladoNivel == 1) // el nivel se encutnra arriba
            {
                NodoOrtogonal tmp = actual;
                while (tmp.adelante != null)
                {
                    if (nuevo.unidad.nivel < tmp.adelante.unidad.nivel)
                    {
                        nuevo.adelante = tmp.adelante;
                        tmp.adelante.atras = nuevo;
                        tmp.adelante = nuevo;
                        nuevo.atras = tmp;
                        return true;
                    }
                    tmp = tmp.adelante;
                }
                if (tmp.adelante == null)
                {
                    tmp.adelante = nuevo;
                    nuevo.atras = tmp;
                    return true;
                }
            }
            else if (ladoNivel == 0) // el nivel se encuentra abajo
            {
                NodoOrtogonal tmp = actual;
                while (tmp.atras != null)
                {
                    if (nuevo.unidad.nivel > tmp.atras.unidad.nivel)
                    {
                        nuevo.atras = tmp.atras;
                        tmp.atras.adelante = nuevo;
                        tmp.atras = nuevo;
                        nuevo.adelante = tmp;
                        return true;
                    }
                    tmp = tmp.atras;
                }
                if (tmp.atras == null)
                {
                    tmp.atras = nuevo;
                    nuevo.adelante = tmp;
                    return true;
                }
            }
            return false;
        }

        public bool yaExisteEnlaceEntreNivel(ref NodoOrtogonal actual, ref NodoOrtogonal nuevo)
        {
            int ladoNivel = verificarLadoNivel(ref actual, ref nuevo);
            NodoOrtogonal tmp = actual;
            if (ladoNivel == 1) // el nuevo niel se encuentra arriba
            {
                while (tmp != null)
                {
                    if (tmp.columna == nuevo.columna && tmp.unidad.nivel == nuevo.unidad.nivel)
                        return true;
                    tmp = tmp.adelante;
                }
                return false;
            }
            else if (ladoNivel == 0) // el nuevo nivel se encuentra abajo
            {
                while (tmp != null)
                {
                    if (tmp.columna == nuevo.columna && tmp.unidad.nivel == nuevo.unidad.nivel)
                        return true;
                    tmp = tmp.atras;
                }
                return false;
            }
            return true; // estan en el mismo nivel por lo tanto no se debe evaluar
        }


        public bool Eliminar(int fila, string columna, int nivel)
        {
            int col = Encoding.ASCII.GetBytes(columna)[0]; //conversion de string a entero en codigo ascci
            Encabezado eFila = ncbzdoFilas.buscarEncabezado(fila);
            Encabezado eCol = ncbzdoColumnas.buscarEncabezado(col);

            if(eFila != null && eCol != null)
            {
                NodoOrtogonal nodoFila = buscarNodoFila(ref eFila.accesoNodo, ref eFila.accesoNodo, col, nivel);
                NodoOrtogonal nodoColumna = buscarNodoCol(ref eCol.accesoNodo, ref eCol.accesoNodo, fila, nivel);

                if(nodoFila != null && nodoColumna != null)
                {
                    if(nodoFila == nodoColumna)
                    {
                        if (eFila.accesoNodo == nodoFila) //eliminacion al pricipio
                        {
                           if(nodoFila.atras != null)
                               eFila.accesoNodo = nodoFila.atras;
                           else if(nodoFila.adelante != null)
                               eFila.accesoNodo = nodoFila.adelante;
                           else if(nodoFila.derecha != null)
                               eFila.accesoNodo = nodoFila.derecha;
                           else
                           {
                              bool elimino = ncbzdoFilas.eliminar(fila);
                               if(!elimino)
                                   return false;
                           }
                                
                        }
                        if(eCol.accesoNodo == nodoColumna)
                        {
                            if(nodoColumna.atras != null)
                                eCol.accesoNodo = nodoColumna.atras;
                            else if(nodoColumna.adelante != null)
                                eCol.accesoNodo = nodoColumna.derecha;
                            else if(nodoColumna.abajo != null)
                                eCol.accesoNodo = nodoColumna.abajo;
                            else
                            {
                                bool eliminado = ncbzdoColumnas.eliminar(col);
                                    if(!eliminado)
                                        return false;
                            }
                        }

                        if(nodoFila.derecha != null && nodoFila.izquierda != null)
                        {
                            nodoFila.derecha.izquierda = nodoFila.derecha;
                            nodoFila.izquierda.derecha = nodoFila.izquierda;
                            nodoFila.derecha = null;
                            nodoFila.izquierda = null;
                        }
                        else if(nodoFila.derecha != null)
                        {
                            nodoFila.derecha.izquierda = null;
                            nodoFila.derecha = null;
                        }
                        else if(nodoFila.izquierda != null)
                        {
                            nodoFila.izquierda.derecha = null;
                            nodoFila.izquierda = null;
                        }
                        if(nodoFila.adelante != null && nodoFila.atras != null)
                        {
                            nodoFila.adelante.atras = nodoFila.atras;
                            nodoFila.atras.adelante = nodoFila.adelante;
                            nodoFila.atras = null;
                            nodoFila.adelante = null;
                        }
                        else if(nodoFila.adelante != null)
                        {
                            nodoFila.adelante.atras = null;
                            nodoFila.adelante = null;
                        }
                        else if(nodoFila.atras != null)
                        {
                            nodoFila.atras.adelante = null;
                            nodoFila.atras = null;
                        }
                        if(nodoColumna.arriba != null && nodoColumna.abajo != null)
                        {
                            nodoColumna.arriba.abajo = nodoColumna.abajo;
                            nodoColumna.abajo.arriba = nodoColumna.arriba;
                            nodoColumna.arriba = null;
                            nodoColumna.abajo = null;
                        }
                        else if(nodoColumna.arriba != null)
                        {
                            nodoColumna.arriba.abajo = null;
                            nodoColumna.arriba = null;
                        }
                        else if(nodoColumna.abajo != null)
                        {    nodoColumna.abajo.arriba = null;
                            nodoColumna.abajo = null;
                        }
                        return true;
                    }

                }
                
            }
            return false;
        }

        public NodoOrtogonal buscarNodoFila(ref NodoOrtogonal actual, ref NodoOrtogonal anterior, int col,int nivel)
        {
            if(actual != null)
            {
                if(actual.unidad.nivel == nivel && actual.columna == col)
                    return actual;
                if(actual.adelante != null && actual.adelante != anterior)
                {
                    NodoOrtogonal encontrado = buscarNodoFila(ref actual.adelante, ref actual,  col,  nivel);
                    if(encontrado != null)
                        return actual;
                }
                if(actual.atras != null && actual.atras != anterior)
                {
                    NodoOrtogonal encontrado = buscarNodoFila(ref actual.atras, ref actual,  col,  nivel);
                    if(encontrado != null)
                        return actual;
                }
                return buscarNodoFila(ref actual.derecha, ref actual, col, nivel);
            }
            return null;
        }
        public NodoOrtogonal buscarNodoCol( ref NodoOrtogonal actual, ref NodoOrtogonal anterior, int fila, int nivel)
        {
            if(actual != null)
            {
                if (actual.unidad.nivel == nivel && actual.fila == fila)
                    return actual;
                if(actual.adelante != null && actual.adelante != anterior)
                {
                    NodoOrtogonal encontrado = buscarNodoCol(ref actual.adelante, ref actual, fila, nivel);
                    if (encontrado != null)
                        return encontrado;
                }
                if(actual.atras != null && actual.atras != anterior)
                {
                    NodoOrtogonal encontrado = buscarNodoCol(ref actual.atras, ref actual, fila, nivel);
                    if (encontrado != null)
                        return actual;
                }
                return buscarNodoCol(ref actual.abajo, ref actual, fila, nivel);
            }
            return null;
        }
    }
}