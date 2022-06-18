using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;//Objeto al que seguirá la cámara

    public float cameraSpeed;//Velocidad de la cámara (lo aconsejable es poner la misma que la velocidad a la que se mueva el target)

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y,
            this.transform.position.z);
    }

    private void LateUpdate()
    {
        //Movemos la cámara utilizando una interpolación (con Lerp) para que el movimiento sea más suave
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
