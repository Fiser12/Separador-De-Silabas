using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeparadorFrases
{
    public class ProcesadorDelTexto
    {
        public static ArrayList ProcesarTexto(string frase, int columnas)
        {
            SeparadorDeSilabas s = new SeparadorDeSilabas();
            ArrayList parrafos = new ArrayList();
            ArrayList silabas = new ArrayList();
            string[] palabras = frase.Split(' ');
            string parrafo = "";
            foreach (string pal in palabras)//Cogemos el string separado por los espacios, es decir el array tiene las palabras
            {
                if(parrafo.Length+pal.Length+1<=columnas)//Si cabe en el parrafo con lo que ya hay y la palabra entera la incorporamos
                {
                    parrafo = parrafo + pal + " ";
                }
                else //No entra la palabra en el parrafo
                {
                    silabas = s.Silabas(pal); //La dividimos en silabas de acuerdo con la división española
                    foreach (string sil in silabas) //Procesamos las silabas
                    {
                        if(parrafo.Length+sil.Length +1<=columnas) //Si cabe esa silaba en el parrafo sin exceder las columnas la metemos
                        {
                            if (silabas.IndexOf(sil) != silabas.Count - 1) //Si no nos encontramos en la última de sus silabas no le agregamos el espacio al final.
                                parrafo = parrafo + sil;
                            else //Si nos encontramos en la última en cambio, si le añadimos el espacio al final porque la palabra ha terminado
                                parrafo = parrafo + sil + " ";
                        }
                        else if (sil.Length > columnas) //Caso especial de que la silaba sea más grande que las columnas
                        {
                            foreach (string letters in sil.SplitInParts(columnas))//Dividimos las silavas en esparaciones del tamaño de las columnas y las vamos metiendo de una en una en cada parrafo
                            {
                                parrafo = parrafo + "-";
                                parrafos.Add(parrafo);
                                parrafo = letters;
                            }
                        }
                        else//Se da que sabemos que la silava no entra en el parrafo y que si entra entera en un parrafo
                        {
                            if (silabas.IndexOf(sil) == 0)//Si es la primera silava de la frase la agregamos sin separador -, pero si es de una sola silaba ponemos el espacio al final
                            {
                                parrafos.Add(parrafo);
                                if (silabas.IndexOf(sil) != silabas.Count - 1)
                                    parrafo = sil;
                                else
                                    parrafo = sil + " ";
                            }
                            else if(silabas.IndexOf(sil) == silabas.Count - 1) //Si es la última silaba ponemos al parrafo previo un separador y un espacio al final de la palabra
                            {
                                parrafo = parrafo + "-";
                                parrafos.Add(parrafo);
                                parrafo = sil + " ";

                            }
                            else //En caso de que sea una silaba intermedia solo agregamos un separador sin espaciarla de la siguiente
                            {
                                parrafo = parrafo + "-";
                                parrafos.Add(parrafo);
                                parrafo = sil;
                            }
                        }
                    }
                }
            }
            return parrafos;
        }
    }
    //http://stackoverflow.com/questions/4133377/splitting-a-string-number-every-nth-character-number
    static class StringExtensions
    {

        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

    }

}
