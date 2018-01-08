using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavalWarsEDD
{
    public class NodoAVL
    {
        public NodoUsuario referenciaUsurio;
        public string nickname;
        public string password;
        public string email;
        public NodoAVL izquierda;
        public NodoAVL derecha;
        public int altura;
        public NodoAVL(string nickname, string password, string email)
        {
            this.referenciaUsurio = null;
            this.nickname = nickname;
            this.password = password;
            this.email = email;
            this.izquierda = null;
            this.derecha = null;
        }
        public NodoAVL(ref NodoUsuario usuario)
        {
            this.referenciaUsurio = usuario;
            this.nickname = usuario.informacion.nickName;
            this.password = usuario.informacion.password;
            this.email = usuario.informacion.email;
            this.derecha = null;
            this.izquierda = null;
        }
    }
    public class ArbolAVL
    {
        public NodoAVL raiz;
        public ArbolAVL()
        {
            this.raiz = null;
        }
        public void insertar(string nickname, string password, string email)
        {
            if (raiz == null)
                raiz = new NodoAVL(nickname, password, email);
            else
                insertar(nickname, password, email, ref raiz);
        }
        public void insertar(string nickname, string password, string email, ref NodoAVL actual)
        {
            if(actual == null)
            {
                actual = new NodoAVL(nickname, password, email);
            }
            else if( nickname.CompareTo(actual.nickname) < 0) //dirigirse a las ramas izquierdas
            {
                insertar(nickname, password, email, ref actual.izquierda);
                /*aqui se evita hacer la resta de nodoDer - nodoIzq para ahorrarse el signo negativo 
                  ademas si la resta de niveles es igual a 2 significa que esta desiquilibrado*/
                if( obtenerAltura(actual.izquierda) - obtenerAltura(actual.derecha) == 2) 
                {
                    if (nickname.CompareTo(actual.izquierda.nickname) < 0)
                        actual = simpleRotacionDer(ref actual);
                    else
                        actual = dobleRotacionizq(ref actual);
                }
            }
            else if(nickname.CompareTo(actual.nickname) >0) // dirigirse a las ramas derechas
            {
                insertar(nickname, password, email, ref actual.derecha);
                if(obtenerAltura(actual.derecha) - obtenerAltura(actual.izquierda) == 2)
                {
                    if (nickname.CompareTo(actual.derecha.nickname) > 0)
                        actual = simpleRotacionIzq(ref actual);
                    else
                        actual = dobleRotacionDer(ref actual);
                }
            }
            actual.altura = calcularAltura(ref actual);
        }

        public void insertarRef(ref NodoUsuario usuario)
        {
            insertarRef(ref usuario, ref this.raiz); 
        }
        public void insertarRef(ref NodoUsuario usuario, ref NodoAVL actual)
        {
            if(actual == null)
            {
                actual = new NodoAVL(ref usuario);
            }
            else if(usuario.informacion.nickName.CompareTo(actual.nickname) < 0) //hacia las ramas izquierdas
            {
                insertarRef(ref usuario, ref actual.izquierda);
                if(obtenerAltura(actual.izquierda) - obtenerAltura(actual.derecha) ==2)
                {
                    if (usuario.informacion.nickName.CompareTo(actual.izquierda.nickname) < 0)
                        actual = simpleRotacionDer(ref actual);
                    else
                        actual = dobleRotacionizq(ref actual);
                }
            }
            else if(usuario.informacion.nickName.CompareTo(actual.nickname) > 0) //hacia las ramas derechas
            {
                insertarRef(ref usuario, ref actual.derecha);
                if(obtenerAltura(actual.derecha) - obtenerAltura(actual.izquierda) ==2)
                {
                    if (usuario.informacion.nickName.CompareTo(actual.nickname) > 0)
                        actual = simpleRotacionIzq(ref actual);
                    else
                        actual = simpleRotacionDer(ref actual);
                }
            }
            actual.altura = calcularAltura(ref actual);
        }

        public bool modificar(string nickname,string nickMod, string password, string email,ref NodoAVL actual)
        {
            if(actual!= null)
            {
                int comparacion = nickname.CompareTo(actual.nickname);
                if (comparacion == 0)
                {
                    if (nickMod != "")
                    {
                        if(actual.referenciaUsurio !=null)
                        {
                            //NodoAVL reeinsertado = new NodoAVL(ref actual.referenciaUsurio);
                            //if (eliminar(nickname))
                            //{
                            //    insertarRef(ref reeinsertado.referenciaUsurio);
                            //    return true;
                            //}
                            //    return false;
                            return false;
                        }
                        else
                        {
                            if(eliminar(nickname))
                            {
                                insertar(nickname, password, email);
                                return true;
                            }
                            return false;
                        }
                    }
                    else
                    {
                        actual.password = password;
                        actual.email = email;
                        return true;
                    }
                }
                else if (comparacion < 0)
                    return modificar(nickname,nickMod, password, email, ref actual.izquierda);
                else if (comparacion > 0)
                    return modificar(nickname,nickMod, password, email, ref actual.derecha);

            }
            return false;
        }
        public bool eliminar(string nickname)
        {
            if(raiz != null)
            {
                eliminar(nickname, ref raiz);
            }
            return false;
        }
        public bool eliminar(string nickname,ref NodoAVL raiz)
        {
            NodoAVL padre = null;
            NodoAVL nodo = null;
            NodoAVL actual = raiz;
            string auxNick = "";
            string auxPass = "";
            string auxEmail = "";
            NodoUsuario auxUsuario = null;
            while(actual != null)
            {
                if(nickname == actual.nickname) //si el nickname es igual al actual nodo
                {
                    /*-----------------------<ComparandoSiEsHoja>-----------------------*/
                    if(actual.izquierda == null && actual.derecha == null)
                    {
                        if(padre != null) //preguntamos si el padre tiene valor
                        {
                            if (padre.derecha == actual)
                            {
                                padre.derecha = null; 
                                return true;
                            }
                            else if (padre.izquierda == actual)
                            {
                                padre.izquierda = null;
                                return true;
                            }
                        }
                        raiz = null;
                        return true;
                    }
                /*-----------------------</ComparandoSiEsHoja>-----------------------*/
                    else
                    {
                        padre = actual;
                        if(actual.derecha != null) // tomando el valor mayor a la izquierda
                        {
                            nodo = actual.derecha;
                            while(nodo.izquierda != null)
                            {
                                padre = nodo;
                                nodo = nodo.izquierda;
                            }
                        }
                        else
                        {
                            nodo = actual.izquierda;
                            while(actual.derecha != null) //tomando el valor menor a la derecha
                            {
                                padre = nodo;
                                nodo = nodo.derecha;
                            }
                        }
                        if(actual.referenciaUsurio !=null && nodo.referenciaUsurio != null)
                        {
                            auxUsuario = actual.referenciaUsurio;
                            auxNick = actual.nickname;
                            auxEmail = actual.email;
                            auxPass = actual.password;
                            actual.referenciaUsurio = nodo.referenciaUsurio;
                            actual.nickname = nodo.nickname;
                            actual.email = nodo.email;
                            actual.password = nodo.password;
                            nodo.referenciaUsurio = auxUsuario;
                            nodo.nickname = auxNick;
                            nodo.email = auxEmail;
                            nodo.password = auxPass;
                            actual = nodo;
                        }
                        else
                        {
                            auxNick = actual.nickname;
                            auxEmail = actual.email;
                            auxPass = actual.password;
                            actual.nickname = nodo.nickname;
                            actual.email = nodo.email;
                            actual.password = nodo.password;
                            nodo.nickname = auxNick;
                            nodo.email = auxEmail;
                            nodo.password = auxPass;
                            actual = nodo;
                        }
                        
                    }
                }
                else
                {
                    padre = actual;
                    if (nickname.CompareTo(actual.nickname) > 0) //el actual ahora es la subrama derecha
                        actual = actual.derecha;
                    if (nickname.CompareTo(actual.nickname) < 0) //el actual ahora es la subRama izquierda
                        actual = actual.izquierda;
                }
            }
            return false;
        }

        public NodoAVL simpleRotacionIzq(ref NodoAVL actual)
        {
            NodoAVL tmp;
            tmp = actual.derecha;
            actual.derecha = tmp.izquierda;
            tmp.izquierda = actual;
            actual = tmp;
            //calculando la altura para las ramas
            actual.altura = calcularAltura(ref actual);

            return actual;
        }
        public NodoAVL simpleRotacionDer(ref NodoAVL actual)
        {
            NodoAVL  tmp;
            tmp = actual.izquierda;
            actual.izquierda = tmp.derecha;
            tmp.derecha = actual;
            actual = tmp;
            actual.altura = calcularAltura(ref actual);
            return actual;
        }

        public NodoAVL dobleRotacionDer(ref NodoAVL actual)
        {
            actual.derecha = simpleRotacionDer(ref actual.derecha);
            return simpleRotacionIzq(ref actual);
        }
        public NodoAVL dobleRotacionizq(ref NodoAVL actual)
        {
            raiz.izquierda = simpleRotacionIzq(ref actual.izquierda);
            return simpleRotacionDer(ref actual);
        }
        public int calcularAltura(ref NodoAVL actual)
        {
            if(actual != null)
            {
                int alturaIzq = calcularAltura(ref actual.izquierda);
                int alturaDer = calcularAltura(ref actual.derecha);
                if (alturaIzq > alturaDer)
                    return alturaIzq + 1;
                else
                    return alturaDer + 1;
            }
            return 0;
        }
        public int obtenerAltura(NodoAVL actual)
        {
            if(actual != null)
            {
                return actual.altura;
            }
            return 0;
        }

        public void getNickContacto(NodoAVL actual, ref List<string> acum)
        {
            if(actual!=null)
            {
                acum.Add(actual.nickname);
                getNickContacto(actual.izquierda,ref acum);
                getNickContacto(actual.derecha,ref acum);
            }
        }
        public NodoAVL getContacto(NodoAVL actual,string nickContacto)
        {
            if(actual!= null)
            {
                if (actual.nickname == nickContacto)
                    return actual;
                else if (nickContacto.CompareTo(actual.nickname) < 0)
                    return getContacto(actual.izquierda, nickContacto);
                else if (nickContacto.CompareTo(actual.nickname) > 0)
                    return getContacto(actual.derecha, nickContacto);
            }
            return null;
        }
        public void preOrden(ref NodoAVL tmp, ref string acum, ref string cabecera)
        {
            if(tmp != null)
            {
                cabecera += "struct" + tmp.GetHashCode().ToString() + "[label=\"<f0> | <f1> " + tmp.nickname +"\\n"+tmp.password +" \\n" + tmp.email + "\\n |<f2>\"];\n";
                if(tmp.izquierda != null)
                    acum += "\"struct" + tmp.GetHashCode().ToString() + "\":f0 -> \"struct" + tmp.izquierda.GetHashCode().ToString() + "\":f1;\n";
                if(tmp.derecha != null)
                    acum += "\"struct" + tmp.GetHashCode().ToString() + "\":f2 -> \"struct" + tmp.derecha.GetHashCode().ToString() + "\":f1;\n";
                preOrden(ref tmp.izquierda, ref acum, ref cabecera);
                preOrden(ref tmp.derecha, ref acum, ref cabecera);
            }
        }
    }

    
}