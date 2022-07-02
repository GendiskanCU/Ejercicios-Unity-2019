using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Actualiza los límites de movimiento la cámara cada vez que se carga de nuevo una escena
//haciéndolos coincidir con los límites del box collider de este objeto

[RequireComponent(typeof(BoxCollider2D))]

public class CameraLimits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CameraFollow>().ChangeLimits(GetComponent<BoxCollider2D>());
    }

   
}
