using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySecondScript : MonoBehaviour
{
    //Constantes: hay que darles valor al definirlas
    public const float PI = 3.14159265f;

    //Variables de solo lectura: no es necesario darles valor al definirlas
    //Se les da valor en el constructor de la clase (no es posible en otro método)
    public readonly int numberOfEnemies;
    MySecondScript()
    {
        numberOfEnemies = 5;
    }





    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
