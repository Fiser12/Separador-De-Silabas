using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TextoViewModel
    {
        [Required(ErrorMessage = "Tienes que introducir una frase")]
        public string texto { get; set; }
        [Range(2, Int32.MaxValue)]
        public int col { get; set; }
        public ArrayList textoProcesado { get; set; }
        public TextoViewModel()
        {
            texto = "La aplicación tiene que devolver el texto con saltos de líneas insertados, de forma que ninguna de las líneas sea más larga (el número de caracteres, incluidos espacios) que el número de columnas que le hemos indicado. Intenta que las líneas sean lo más largas posible, dentro del límite, y siempre que puedas, pon el salto de línea en el espacio entre palabras.";
            col = 30;
            textoProcesado = new ArrayList();
        }
    }
}
