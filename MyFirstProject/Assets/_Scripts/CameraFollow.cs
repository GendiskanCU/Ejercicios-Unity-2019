using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 1.3f, -3f);//Distancia de la cámara al jugador

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }



    //LateUpdate, para asegurarnos de que el player se ha movido antes de que la cámara le siga
    private void LateUpdate()
    {
        //Mueve la cámara a la posición del player aplicando el offset correspondiente
        transform.position = target.TransformPoint(cameraOffset);
        //Asegura que la cámara se quede mirando hacia el personaje, y por tanto también hacia donde éste mira
        transform.LookAt(target);        
    }
}
