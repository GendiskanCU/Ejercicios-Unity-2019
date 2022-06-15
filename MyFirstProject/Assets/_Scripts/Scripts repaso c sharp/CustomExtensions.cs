using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ejemplo de extensión de clases
namespace CustomExtensions//Debemos crear un nuevo namespace
{
    public static class StringExtensions//Vamos a hacer una extensión a la clase string
    {
        public static void MiPropioDebug(this string str)//La extensión añadirá a la clase string este método propio
        {
            Debug.LogFormat("La frase {0} tiene {1} caracteres", str, str.Length);
        }
    }   
}
