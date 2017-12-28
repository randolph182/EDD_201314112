using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Nodo
    {
        public Nodo izquierda;
        public Nodo derecha;
        public Nodo arriba;
        public Nodo abajo;
        public Nodo adelante;
        public Nodo atras;
        //public Encabezado accEncabezado;

        public int fila;
        public int columna;
        public Unidad unidad;
        public Nodo(int fila, int columna,ref Unidad valor)
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
           // this.accEncabezado = null;
        }
           
    }

   public class Encabezado
   {
       public int id;
       public Encabezado siguiente;
       public Encabezado anterior;
       public Nodo acceso;

       public Encabezado(int id)
       {
           this.id = id;
           this.siguiente = null;
           this.anterior = null;
           this.acceso = null;
       }
   }

    public class ListaEncabezado
    {
        public Encabezado primero;
        int size;
        public void insertar(ref Encabezado nuevo)
        {
            if(primero ==null)
            {
                primero = nuevo;
                size++;
            }
            else
            {
                if(nuevo.id < primero.id) //insercion al inicio
                {
                    nuevo.siguiente = primero;
                    primero.anterior = nuevo;
                    primero = nuevo;
                    size++;
                }
                else
                {
                    Encabezado tmp = primero;
                    
                    while(tmp.siguiente != null)
                    {
                        if(nuevo.id < tmp.siguiente.id)
                        {
                            nuevo.siguiente = tmp.siguiente;
                            tmp.siguiente.anterior = nuevo;
                            nuevo.anterior = tmp;
                            tmp.siguiente = nuevo;
                            size++;
                            break;
                        }
                        tmp = tmp.siguiente;
                    }

                    if(tmp.siguiente == null)
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
            
            if(primero !=null)
            {
                Encabezado tmp = primero;
                while(tmp!=null)
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
            if(primero !=null)
            {
                if(primero.id == id)
                {
                    primero = primero.siguiente;
                    primero.anterior = null;
                    size--;
                    return true;
                }
                else
                {
                    Encabezado tmp = primero;

                    while (tmp != null)
                    {
                        if (id == tmp.id)
                        {
                            Encabezado tmp2 = tmp.anterior;
                            tmp2.siguiente = tmp.siguiente;
                            tmp.siguiente.anterior = tmp2;
                            size--;
                            return true;
                        }
                        tmp = tmp.siguiente;
                    }
                }
            }
            return false;
        }
    }


    class Matriz
    {
        public ListaEncabezado ncbzdoFilas;
        public ListaEncabezado ncbzdoColumnas;
        public Matriz()
        {
            this.ncbzdoFilas = new ListaEncabezado();
            this.ncbzdoColumnas = new ListaEncabezado(); ;
        }

        public void insertar(int fila, string columna,ref Unidad nuevaUnidad)
        {
            int col = Encoding.ASCII.GetBytes(columna)[0]; //conversion de stirng a entero en codigo ascii
            Nodo nuevoNodo = new Nodo(fila, col, ref nuevaUnidad);
            Encabezado encabezadoFila = ncbzdoFilas.buscarEncabezado(fila);
            if (encabezadoFila == null)
            {
                encabezadoFila = new Encabezado(fila);
                ncbzdoFilas.insertar(ref encabezadoFila);
                encabezadoFila.acceso = nuevoNodo;
            }
            else
            {   /* El nuevo nodo pregunta si la columna  es menor a la que tiene acceso la fila 
                  Esta Verificado que no importa que nivel se inserte al principio */
                if (nuevoNodo.columna < encabezadoFila.acceso.columna) //insercion al inicio
                {
                    nuevoNodo.derecha = encabezadoFila.acceso;
                    encabezadoFila.acceso.izquierda = nuevoNodo;
                    encabezadoFila.acceso = nuevoNodo;
                }
                else
                {
                    /* Hay que preguntar si el nivel del nuevo Nodo existe en la Fila Obtenida
                   Si retorna un Null hay que ubicarlo en los Niveles de la Fila
                    si retorn distinto a Null hay que ubicarlo en las columnas del  Nodo ubicado*/
                    Nodo  NodoEncontrado = existeNivel(ref encabezadoFila.acceso,nuevoNodo.unidad.nivel);
                    if(NodoEncontrado == null) //hay que hubicarlo en los niveles de la Fila
                    {
                        if(nuevoNodo.columna == encabezadoFila.acceso.columna) //tengo que verificar si el nuevo tiene la misma columna
                        {
                            insertarEntreNiveles(ref encabezadoFila.acceso, ref nuevoNodo);
                            verificarEnlaceIzqDer(ref encabezadoFila.acceso, ref nuevoNodo);
                            if(nuevoNodo.unidad.nivel ==1) //si el nuevoNod en la misma columna tiene nivel 1 lo pongo como acceso
                                encabezadoFila.acceso = nuevoNodo;
                            else if(nuevoNodo.unidad.nivel !=1)
                            {
                                if(nuevoNodo.unidad.nivel < encabezadoFila.acceso.unidad.nivel )
                                {
                                    encabezadoFila.acceso = nuevoNodo;
                                }
                            }
                        }
                        else //significa el nivel no esxite y que las columnas no son las mismas
                        {
                            insertarEntreNiveles(ref encabezadoFila.acceso, ref nuevoNodo);
                            verificarEnlaceIzqDerNiveles(ref encabezadoFila.acceso, ref nuevoNodo);
                        }
                    }
                    // el nivel del nuevo nodo ya existe por lo tanto con lo retornado hay que hubicarlos entre sus columnas
                    // preguntando siempre si el nuevo columna tiene distita columna que el nodo Encontrado ya que es el acceso
                    else if(!existeNodoFila(ref NodoEncontrado,ref nuevoNodo))
                    {
                        
                        if(nuevoNodo.columna < NodoEncontrado.columna) // insercion al inicio
                        {
                            int ladoNivel = verificarLadoNivel(ref encabezadoFila.acceso, ref nuevoNodo);
                            NodoEncontrado.izquierda = nuevoNodo;
                            nuevoNodo.derecha = NodoEncontrado;

                            if(ladoNivel == 1)
                            {
                                encabezadoFila.acceso.adelante.atras = null; // borro el enlace que quedaba de por medio
                                encabezadoFila.acceso.adelante = nuevoNodo;
                                nuevoNodo.atras = encabezadoFila.acceso;
                            }
                            else if(ladoNivel == 0)
                            {
                                encabezadoFila.acceso.atras.adelante = null; //borro elenlace que quedaba de por medio
                                encabezadoFila.acceso.atras = nuevoNodo;
                                nuevoNodo.adelante = encabezadoFila.acceso;
                            }
                            if(nuevoNodo.unidad.nivel ==1)
                            {
                                encabezadoFila.acceso = nuevoNodo;
                            }
                        }
                        else
                        {
                            Nodo tmpNivel = NodoEncontrado;
                            while (tmpNivel.derecha != null)
                            {
                                if (nuevoNodo.columna < tmpNivel.derecha.columna )//insercion al medio 
                                {
                                    nuevoNodo.derecha = tmpNivel.derecha;
                                    tmpNivel.derecha.izquierda = nuevoNodo;
                                    nuevoNodo.izquierda = tmpNivel;
                                    tmpNivel.derecha = nuevoNodo;
                                    verificarEnlaceIzqDerNiveles(ref tmpNivel, ref nuevoNodo);
                                    break;
                                }
                                tmpNivel = tmpNivel.derecha;
                            }
                            if (tmpNivel.derecha == null )
                            {
                                tmpNivel.derecha = nuevoNodo;
                                nuevoNodo.izquierda = tmpNivel;
                                verificarEnlaceIzqDerNiveles(ref tmpNivel, ref nuevoNodo);
                            }
                        }

                    }
                }
            }
/*----------------------------- COMIENZA EL ANALISIS EN LA INSERCION DE COLUMNAS --------------------------*/
            Encabezado encabezadoCol = ncbzdoColumnas.buscarEncabezado(col);
            if (encabezadoCol == null)
            {
                encabezadoCol = new Encabezado(col);
                ncbzdoColumnas.insertar(ref encabezadoCol);
                encabezadoCol.acceso = nuevoNodo;
            }
        }


        public bool existeNodoFila(ref Nodo actual, ref Nodo nodoNuevo)
        {
            if(actual.izquierda != null)
            {
                Nodo tmpIzq = actual;
                while(tmpIzq != null)
                {
                    if(tmpIzq.columna == nodoNuevo.columna && tmpIzq.unidad.nivel == nodoNuevo.unidad.nivel)
                        return true;
                    tmpIzq = tmpIzq.izquierda;
                }
            }
            else if(actual.derecha != null)
            {
                Nodo tmpDer = actual;
                while(tmpDer != null)
                {
                    if (tmpDer.columna == nodoNuevo.columna && tmpDer.unidad.nivel == nodoNuevo.unidad.nivel)
                        return true;
                    tmpDer = tmpDer.derecha;
                }
            }
            return false;
        }
        public void verificarEnlaceIzqDer(ref Nodo actual, ref Nodo nuevo )
        {
            //un cero recorro atras del cubo y un 1 recorro adelante del cubo  y un 2 estan en el mismo nivel
            int lado = verificarLadoNivel(ref actual, ref nuevo);
             if(actual.izquierda != null)
            {
                Nodo tmpIzq = actual.izquierda;
				while (tmpIzq != null)
                {
	                if(lado == 1) //tengo que moverme hacia adelante
	                {
	                    if (tmpIzq.adelante != null)
	                    {
	                        Nodo tmpIzqAdelante = tmpIzq;
	                        while (tmpIzqAdelante != null)
	                        {
	                            if (tmpIzqAdelante.unidad.nivel == nuevo.unidad.nivel)
	                            {
	                                tmpIzqAdelante.derecha = nuevo;
	                                nuevo.izquierda = tmpIzqAdelante;
	                                break;
	                            }
	                            tmpIzqAdelante = tmpIzqAdelante.adelante;
	                        }
	                        break;
	                    }
	                }
	                else if(lado ==0) //tengo que moverme hacia abajo
	                {
	                    if (tmpIzq.atras != null)
	                    {
	                        Nodo tmpIzqAtras= tmpIzq;
	                        while (tmpIzqAtras != null)
	                        {
	                            if (tmpIzqAtras.unidad.nivel == nuevo.unidad.nivel)
	                            {
	                                tmpIzqAtras.derecha = nuevo;
	                                nuevo.izquierda = tmpIzqAtras;
	                                break;
	                            }
	                            tmpIzqAtras = tmpIzqAtras.atras;
	                        }
	                        break;
	                    }
	                }
	                tmpIzq = tmpIzq.izquierda;  
	            }                 
            }

            if(actual.derecha != null)
            {
                Nodo tmpDer = actual.derecha;
                while(tmpDer != null)
                {
                    if(lado == 1) //tengo que movereme hacia adelante
                    {
                        if(tmpDer.adelante != null)
                        {
                            Nodo tmpDerAdelante = tmpDer;
                            while(tmpDerAdelante != null)
                            {
                                if(tmpDerAdelante.unidad.nivel == nuevo.unidad.nivel)
                                {
                                    tmpDerAdelante.izquierda = nuevo;
                                    nuevo.derecha = tmpDerAdelante;
                                    break;
                                }
                                tmpDerAdelante = tmpDerAdelante.adelante;
                            }
                            break;
                        }
                    }
                    else if(lado ==0) //tengoq ue moverme hacia atras
                        if(tmpDer.atras != null)
                        {
                            Nodo tmpDerAtras = tmpDer;
                            while(tmpDerAtras!= null)
                            {
                                if(tmpDerAtras.unidad.nivel == nuevo.unidad.nivel)
                                {
                                    tmpDerAtras.izquierda = nuevo;
                                    nuevo.derecha = tmpDerAtras;
                                    break;
                                }
                                tmpDerAtras = tmpDerAtras.atras;
                            }
                            break;
                        }
                    tmpDer = tmpDer.derecha;
                }
            }
        }

        public int verificarLadoNivel(ref Nodo actual, ref Nodo nuevo)
        { // si retorna 1 significa que deber recorrer para adelnte 
            //si retorna 0 se debe recorrer para atras
            //si retorna 2 es porque estan en el mismo nivel
            if (nuevo.unidad.nivel > actual.unidad.nivel)
                return 1;
            else if (nuevo.unidad.nivel < actual.unidad.nivel)
                return 0;
            else
                return 2;
        }
        public Nodo existeNivel(ref Nodo actual,int nivel)
        {
            if(actual.unidad.nivel == nivel)
            {
                return actual;
            }
            else if(nivel < actual.unidad.nivel)
            {
                Nodo tmp = actual;
                while(tmp != null)
                {
                    if(tmp.unidad.nivel == nivel)
                        return tmp;
                    tmp = tmp.atras;
                }
            }
            else if(nivel > actual.unidad.nivel)
            {
                Nodo tmp = actual;
                while(tmp!=null)
                {
                    if(tmp.unidad.nivel ==nivel)
                        return tmp;
                    tmp = tmp.adelante;
                }
            }
            return null;
        }


        public void insertarEntreNiveles(ref Nodo actual, ref Nodo nuevo)
        {   // 1= arriba  0 = abajo   2 = estan en el mismo nivel
            int ladoNivel = verificarLadoNivel(ref actual, ref nuevo);

            Nodo tmp = actual;
            if(ladoNivel == 1) //debo moverme hacia adelante
            {
                 while(tmp.adelante!= null) //enlace en medio 
                 {
                     if(nuevo.unidad.nivel < tmp.adelante.unidad.nivel)
                     {
                         nuevo.adelante = tmp.adelante;
                         tmp.adelante.atras = nuevo;
                         tmp.adelante = nuevo;
                         nuevo.atras = tmp;
                         break;
                     }
                     tmp = tmp.adelante;
                 }
                if(tmp.adelante == null) //insercion al ultimo
                {
                    tmp.adelante = nuevo;
                    nuevo.atras = tmp;
                }
            }
            else if(ladoNivel == 0)
            {
                while(tmp.atras != null)
                {
                    if(nuevo.unidad.nivel > tmp.atras.unidad.nivel)
                    {
                        nuevo.atras = tmp.atras;
                        tmp.atras.adelante = nuevo;
                        tmp.atras = nuevo;
                        nuevo.adelante = tmp;
                        break;
                    }
                    tmp = tmp.atras;
                }
                if(tmp.atras ==null) //insercion al ultimo
                {
                    tmp.atras = nuevo;
                    nuevo.adelante = tmp;
                }
            }
            
        }


        public void verificarEnlaceIzqDerNiveles(ref Nodo actual, ref Nodo nuevo)
        {
            //un cero recorro atras del cubo y un 1 recorro adelante del cubo  y un 2 estan en el mismo nivel
            int lado = verificarLadoNivel(ref actual, ref nuevo);
            if(lado == 2) //significa que hay que verificar los adelante del actual
            {
                if(actual.adelante != null)
                {
                    verificarEnlaceIzqDerNiveles(ref actual.adelante,ref  nuevo); //metodo recursivo solo que cambia el nivel hacia adelante
                }
                if(actual.atras != null)
                {
                    verificarEnlaceIzqDerNiveles(ref actual.atras, ref nuevo); //metodo recursivo solo que cambia el nivel hacia atras
                }
            }
            else
            {
                if (actual.izquierda != null)
                {
                    Nodo tmpIzq = actual;
                    while (tmpIzq != null)
                    {
                        if (lado == 1)
                        {
                            if (tmpIzq.columna == nuevo.columna && !verificarNiveles(ref tmpIzq,ref nuevo))
                            {
                                Nodo tmpIzqAdelante = tmpIzq;
                                while (tmpIzqAdelante.adelante != null)
                                {

                                    if(nuevo.unidad.nivel < tmpIzqAdelante.adelante.unidad.nivel)
                                    {
                                        nuevo.adelante = tmpIzqAdelante.adelante;
                                        tmpIzqAdelante.adelante.atras = nuevo;
                                        tmpIzqAdelante.adelante = nuevo;
                                        nuevo.atras = tmpIzqAdelante;
                                        break;
                                    }
                                    tmpIzqAdelante = tmpIzqAdelante.adelante;
                                }
                                if (tmpIzqAdelante.adelante == null)
                                {
                                    tmpIzqAdelante.adelante = nuevo;
                                    nuevo.atras = tmpIzqAdelante;
                                }

                                break;
                            }
                        }
                        else if (lado == 0)
                        {
                            if (tmpIzq.columna == nuevo.columna && !verificarNiveles(ref tmpIzq,ref nuevo))
                            {
                                Nodo tmpIzqAtras = tmpIzq;

                                while (tmpIzqAtras.atras != null)
                                {
                                    if(nuevo.unidad.nivel > tmpIzqAtras.atras.unidad.nivel)
                                    {
                                        nuevo.atras = tmpIzqAtras.atras;
                                        tmpIzqAtras.atras.adelante = nuevo;
                                        tmpIzqAtras.atras = nuevo;
                                        nuevo.adelante = tmpIzqAtras;
                                        break;
                                    }

                                    tmpIzqAtras = tmpIzqAtras.atras;
                                }
                                if (tmpIzqAtras.atras == null)
                                {
                                    tmpIzqAtras.atras = nuevo;
                                    nuevo.adelante = tmpIzqAtras;
                                }
                                break;
                            }
                        }
                        tmpIzq = tmpIzq.izquierda;
                    }
                }

                if (actual.derecha != null)
                {
                    Nodo tmpDer = actual;
                    while (tmpDer != null)
                    {
                        if (lado == 1)
                        {
                            if (tmpDer.columna == nuevo.columna && !verificarNiveles(ref tmpDer, ref nuevo))
                            {
                                Nodo tmpDerAdelante = tmpDer;
                                while (tmpDerAdelante.adelante != null)
                                {

                                    if(nuevo.unidad.nivel < tmpDerAdelante.adelante.unidad.nivel)
                                    {
                                        nuevo.adelante = tmpDerAdelante.adelante;
                                        tmpDerAdelante.adelante.atras = nuevo;
                                        tmpDerAdelante.adelante = nuevo;
                                        nuevo.atras = tmpDerAdelante;
                                        break;
                                    }
                                    tmpDerAdelante = tmpDerAdelante.adelante;
                                }
                                if (tmpDerAdelante.adelante == null)
                                {
                                    tmpDerAdelante.adelante = nuevo;
                                    nuevo.atras = tmpDerAdelante;
                                    break;
                                }
                            }
                        }
                        else if (lado == 0)
                        {
                            if (tmpDer.columna == nuevo.columna && !verificarNiveles(ref tmpDer, ref nuevo))
                            {
                                Nodo tmpDerAtras = tmpDer;
                                while (tmpDerAtras.atras != null)
                                {
                                    if(nuevo.unidad.nivel > tmpDerAtras.atras.unidad.nivel)
                                    {
                                        nuevo.atras = tmpDerAtras.atras;
                                        tmpDerAtras.atras.adelante = nuevo;
                                        nuevo.adelante = tmpDerAtras;
                                        tmpDerAtras.atras = nuevo;
                                        break;
                                    }

                                    tmpDerAtras = tmpDerAtras.atras;
                                }

                                if (tmpDerAtras.atras == null)
                                {
                                    tmpDerAtras.atras = nuevo;
                                    nuevo.adelante = tmpDerAtras;
                                    break;
                                }
                                
                            }
                        }
                        tmpDer = tmpDer.derecha;
                    }
                }
            }


        }

        public bool verificarNiveles(ref Nodo actual,ref Nodo nuevo)
        {
            int lado = verificarLadoNivel(ref actual,ref nuevo);

            Nodo tmp = actual;

            if(lado == 1)
            {
                while(tmp!=null)
                {
                    if(tmp.unidad.nivel == nuevo.unidad.nivel && tmp.columna == nuevo.columna)
                    {
                        return true;
                    }
                    tmp = tmp.adelante;
                }
            }
            else if (lado == 0)
            {
                while (tmp != null)
                {
                    if (tmp.unidad.nivel == nuevo.unidad.nivel && tmp.columna == tmp.columna)
                    {
                        return true;
                    }
                    tmp = tmp.atras;
                }
            }

            return false;
        }
        public void insertEntreNivel(ref Nodo actual,ref Nodo nuevo)
        {
            if(nuevo.unidad.nivel != actual.unidad.nivel && nuevo.unidad.nivel < 4 && nuevo.unidad.nivel >=0)
            {
                if(nuevo.unidad.nivel <actual.unidad.nivel)
                {
                    Nodo tmp = actual;
                    bool enlazo = false;
                    while (tmp.atras != null)
                    {
                        if (tmp.atras.unidad.nivel < nuevo.unidad.nivel) //esta en medio de los nivees
                        {
                            nuevo.atras = tmp.atras;
                            tmp.atras.adelante = nuevo;
                            tmp.atras = nuevo;
                            nuevo.adelante = tmp;
                            enlazo = true;
                            break;
                        }
                        tmp = tmp.atras;
                    }
                    if(tmp.atras == null)
                    {
                        tmp.atras = nuevo;
                        nuevo.adelante = tmp;                                                                                                               
                        enlazo = true;
                    }

                    if (enlazo)
                    {
                        if (tmp.derecha != null)
                        {
                            if (nuevo.unidad.nivel == tmp.derecha.unidad.nivel)
                            {
                                nuevo.derecha = tmp.derecha;
                                tmp.derecha.izquierda = nuevo;
                                tmp.derecha = null;
                            }
                            else if (tmp.derecha.atras != null)
                            {
                                Nodo tmpDer = tmp.derecha;
                                while (tmpDer != null)
                                {
                                    if (tmpDer.unidad.nivel == nuevo.unidad.nivel)
                                    {
                                        tmpDer.izquierda = nuevo;
                                        nuevo.derecha = tmpDer;
                                        break;
                                    }
                                    tmpDer = tmpDer.atras;
                                }
                            }
                            else
                            {
                                nuevo.derecha = tmp.derecha;
                                tmp.derecha.izquierda = nuevo;
                                tmp.derecha = null;
                                //verificarEnlaceFila(ref actual, ref nuevo);
                            }
                        }
                        if (tmp.izquierda != null)
                        {
                            if (nuevo.unidad.nivel == tmp.izquierda.unidad.nivel)
                            {
                                nuevo.izquierda = tmp.izquierda;
                                tmp.izquierda.derecha = nuevo;
                                tmp.izquierda = null;
                            }
                            else if (tmp.izquierda.atras != null)
                            {
                                Nodo tmpIzq = tmp.izquierda;
                                while (tmpIzq != null)
                                {
                                    if (tmpIzq.unidad.nivel == nuevo.unidad.nivel)
                                    {
                                        tmpIzq.derecha = nuevo;
                                        nuevo.izquierda = tmpIzq;
                                        break;
                                    }
                                    tmpIzq = tmpIzq.atras;
                                }
                            }
                            else
                            {
                                nuevo.izquierda = tmp.izquierda;
                                tmp.izquierda.derecha = nuevo;
                                tmp.izquierda = null;
                            }
                        }
                    }
                }
                else if(nuevo.unidad.nivel > actual.unidad.nivel)
                {
                    Nodo tmp = actual;
                    bool enlazo = false;

                    while (tmp.adelante != null)
                    {
                        if (nuevo.unidad.nivel < tmp.adelante.unidad.nivel) //esta en medio de los nivees
                        {
                            nuevo.adelante = tmp.adelante;
                            tmp.adelante.atras = nuevo;
                            tmp.adelante = nuevo;
                            nuevo.atras = tmp;
                            enlazo = true;
                            break;
                        }
                        tmp = tmp.adelante;
                    }

                    if (tmp.adelante == null )
                    {
                        tmp.adelante = nuevo;
                        nuevo.atras = tmp;
                        enlazo = true;
                    }

                    if (enlazo)
                    {
                        if (tmp.derecha != null)
                        {

                        }
                    }


                    if (enlazo)
                    {
                        if (tmp.derecha != null)
                        {
                            if (nuevo.unidad.nivel == tmp.derecha.unidad.nivel)
                            {
                                nuevo.derecha = tmp.derecha;
                                tmp.derecha.izquierda = nuevo;
                                tmp.derecha = null;
                            }
                            else if (tmp.derecha.adelante != null)
                            {
                                Nodo tmpDer = tmp.derecha;
                                while (tmpDer != null)
                                {
                                    if (tmpDer.unidad.nivel == nuevo.unidad.nivel)
                                    {
                                        tmpDer.izquierda = nuevo;
                                        nuevo.derecha = tmpDer;
                                        break;
                                    }
                                    tmpDer = tmpDer.adelante;
                                }
                            }
                            else
                            {
                                nuevo.derecha = tmp.derecha;
                                tmp.derecha.izquierda = nuevo;
                                tmp.derecha = null;
                            }
                        }
                        if (tmp.izquierda != null)
                        {
                            if (nuevo.unidad.nivel == tmp.izquierda.unidad.nivel)
                            {
                                nuevo.izquierda = tmp.izquierda;
                                tmp.izquierda.derecha = nuevo;
                                tmp.izquierda = null;
                            }
                            else if (tmp.izquierda.adelante != null)
                            {
                                Nodo tmpIzq = tmp.izquierda;
                                while (tmpIzq != null)
                                {
                                    if (tmpIzq.unidad.nivel == nuevo.unidad.nivel)
                                    {
                                        tmpIzq.derecha = nuevo;
                                        nuevo.izquierda = tmpIzq;
                                        break;
                                    }
                                    tmpIzq = tmpIzq.adelante;
                                }
                            }
                            else
                            {
                                nuevo.izquierda = tmp.izquierda;
                                tmp.izquierda.derecha = nuevo;
                                tmp.izquierda = null;
                            }
                        }
                    }
                    
                }
            }
        }

        public void insertEntreNivelCol(ref Nodo actual, ref Nodo nuevo)
        {
            if (nuevo.unidad.nivel != actual.unidad.nivel && nuevo.unidad.nivel < 4 && nuevo.unidad.nivel >= 0)
            {
                if (nuevo.unidad.nivel < actual.unidad.nivel)
                {
                    Nodo tmp = actual;
                        if (tmp.abajo != null)
                        {
                            if (nuevo.unidad.nivel == tmp.abajo.unidad.nivel)
                            {
                                nuevo.abajo = tmp.abajo;
                                tmp.abajo.arriba = nuevo;
                                tmp.abajo = null;
                            }
                            else if (tmp.abajo.atras != null)
                            {
                                Nodo tmpDer = tmp.abajo;
                                while (tmpDer != null)
                                {
                                    if (tmpDer.unidad.nivel == nuevo.unidad.nivel)
                                    {
                                        tmpDer.arriba = nuevo;
                                        nuevo.abajo = tmpDer;
                                        break;
                                    }
                                    tmpDer = tmpDer.atras;
                                }
                            }
                            else
                            {
                                nuevo.abajo = tmp.abajo;
                                tmp.abajo.arriba = nuevo;
                                tmp.abajo = null;
                            }
                        }
                        if (tmp.arriba != null)
                        {
                            if (nuevo.unidad.nivel == tmp.arriba.unidad.nivel)
                            {
                                nuevo.arriba = tmp.arriba;
                                tmp.arriba.abajo = nuevo;
                                tmp.arriba = null;
                            }
                            else if (tmp.arriba.atras != null)
                            {
                                Nodo tmpIzq = tmp.arriba;
                                while (tmpIzq != null)
                                {
                                    if (tmpIzq.unidad.nivel == nuevo.unidad.nivel)
                                    {
                                        tmpIzq.abajo = nuevo;
                                        nuevo.arriba = tmpIzq;
                                        break;
                                    }
                                    tmpIzq = tmpIzq.atras;
                                }
                            }
                            else
                            {
                                nuevo.arriba = tmp.arriba;
                                tmp.arriba.abajo = nuevo;
                                tmp.arriba = null;
                                verificarEnlaceCol(ref tmp, ref nuevo);
                            }
                        }
                }
                else if (nuevo.unidad.nivel > actual.unidad.nivel)
                {
                    Nodo tmp = actual;
                        if (tmp.abajo != null)
                        {
                            if (nuevo.unidad.nivel == tmp.abajo.unidad.nivel)
                            {
                                nuevo.abajo = tmp.abajo;
                                tmp.abajo.arriba = nuevo;
                                tmp.abajo = null;
                            }
                            else if (tmp.abajo.adelante != null)
                            {
                                Nodo tmpDer = tmp.abajo;
                                while (tmpDer != null)
                                {
                                    if (tmpDer.unidad.nivel == nuevo.unidad.nivel)
                                    {
                                        tmpDer.arriba = nuevo;
                                        nuevo.abajo = tmpDer;
                                        break;
                                    }
                                    tmpDer = tmpDer.adelante;
                                }
                            }
                            else
                            {
                                nuevo.abajo = tmp.abajo;
                                tmp.abajo.arriba = nuevo;
                                tmp.abajo = null;
                            }
                        }
                        if (tmp.arriba != null)
                        {
                            if (nuevo.unidad.nivel == tmp.arriba.unidad.nivel)
                            {
                                nuevo.arriba = tmp.arriba;
                                tmp.arriba.abajo = nuevo;
                                tmp.arriba = null;
                            }
                            else if (tmp.arriba.adelante != null)
                            {
                                Nodo tmpIzq = tmp.arriba;
                                while (tmpIzq != null)
                                {
                                    if (tmpIzq.unidad.nivel == nuevo.unidad.nivel)
                                    {
                                        tmpIzq.abajo = nuevo;
                                        nuevo.arriba = tmpIzq;
                                        break;
                                    }
                                    tmpIzq = tmpIzq.adelante;
                                }
                            }
                            else
                            {
                                nuevo.arriba = tmp.arriba;
                                tmp.arriba.abajo = nuevo;
                                tmp.arriba = null;
                            }
                        }

                }
            }
        }

        public  void verificarEnlaceCol(ref Nodo actual,ref Nodo nuevo)
        {
            if(actual.unidad.nivel != nuevo.unidad.nivel)
            {
                if(nuevo.unidad.nivel < actual.unidad.nivel)
                {
                    Nodo tmp = actual;

                    while(tmp!=null)
                    {
                        if(tmp.unidad.nivel == nuevo.unidad.nivel)
                        {
                            tmp.abajo = nuevo;
                            nuevo.arriba = tmp;
                            break;
                        }
                        tmp = tmp.atras;
                    }
                }
                else
                {
                    Nodo tmp = actual;
                    while(tmp !=null)
                    {
                        if(tmp.unidad.nivel == nuevo.unidad.nivel)
                        {
                            tmp.abajo = nuevo;
                            nuevo.arriba = tmp;
                            break;
                        }
                        tmp = tmp.adelante;
                    }
                }

            }
        }

        public void verificarEnlaceFila(ref Nodo actual, ref Nodo nuevo)
        {
            if (actual.unidad.nivel != nuevo.unidad.nivel)
            {
                if (nuevo.unidad.nivel < actual.unidad.nivel)
                {
                    Nodo tmp = actual;

                    while (tmp != null)
                    {
                        if (tmp.unidad.nivel == nuevo.unidad.nivel)
                        {
                            tmp.derecha = nuevo;
                            nuevo.izquierda = tmp;
                            break;
                        }
                        tmp = tmp.atras;
                    }
                }
                else //es mayor
                {
                    Nodo tmp = actual;
                    while (tmp != null)
                    {
                        if (tmp.unidad.nivel == nuevo.unidad.nivel)
                        {
                            tmp.derecha = nuevo;
                            nuevo.izquierda = tmp;
                            break;
                        }
                        tmp = tmp.adelante;
                    }
                }

            }
        }

        public void prueba(int fila, string columna)
        {
            int col = Encoding.ASCII.GetBytes(columna)[0]; //conversion de stirng a entero en codigo ascii
            
        }
    }
}
