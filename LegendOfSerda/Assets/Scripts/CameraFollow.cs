using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class CameraFollow : MonoBehaviour
{
    public GameObject target;//Objeto al que seguirá la cámara

    public float cameraSpeed;//Velocidad de la cámara (lo aconsejable es poner la misma que la velocidad a la que se mueva el target)

    private Vector3 targetPosition;//Posición a la que debe moverse la cámara en el siguiente frame


    //Variables que se utilizan para que la cámara no se "salga" de los límites del escenario
    private Camera theCamera;//La propia cámara
    private BoxCollider2D cameraLimits;//Límites del escenario, definidos por un objeto en la escena que tiene un collider trigger que ocupa el espacio que se debe ver
    private Vector3 minLimits, maxLimits;//Límites mínimos y máximos
    private float halfHeight, halfWidth;//Para calcular la mitad de la altura y la altura que la cámara muestra

    // Start is called before the first frame update
    void Start()
    {
        //Captura el collider que define los límites del escenario
        cameraLimits = GameObject.Find("CameraLimits").GetComponent<BoxCollider2D>();
        //De esos límites, se averigua con el mínimo y el máximo
        minLimits = cameraLimits.bounds.min;
        maxLimits = cameraLimits.bounds.max;
        //Captura la propia cámara
        theCamera = GetComponent<Camera>();

        //La mitad de la altura que la cámara muestra se corresponde con el size de la misma (definido en el Inspector)
        //Nota: El size de una cámara ortográfica (en 2D) es la mitad del valor más pequeño a lo alto o a lo ancho de la misma
        //Como este juego está en 16:9 el valor más pequeño es a lo alto, de ahí que el size corresponda con la mitad de su altura
        halfHeight = theCamera.orthographicSize;

        //Como la proporción es 16:9 a partir de la mitad de la altura, podremos calcular la mitad de la anchura
        //con una simple regla de tres:
        halfWidth = halfHeight * Screen.width / Screen.height;
    }




    // Update is called once per frame
    void Update()
    {
        //Calcula la posición a la que debe moverse la cámara (la del target)
        //Pero vamos a tener en cuenta que la cámara no debe sobrepasar los límites del escenario
        float posX = Mathf.Clamp(target.transform.position.x, minLimits.x + halfWidth, maxLimits.x - halfWidth);
        float posY = Mathf.Clamp(target.transform.position.y, minLimits.y + halfHeight, maxLimits.y - halfHeight);


        targetPosition = new Vector3(posX, posY, transform.position.z);
    }

    private void LateUpdate()
    {
        //Movemos la cámara utilizando una interpolación (con Lerp) para que el movimiento sea más suave
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
