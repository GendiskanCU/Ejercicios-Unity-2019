using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Establece el punto donde deberá situarse el player al cargar la escena
public class StartPoint : MonoBehaviour
{
    //Se establecerá tanto la posición del player como la de la cámara
    private PlayerController player;
    private CameraFollow _camera;

    public Vector2 facingDirection;//Para establecer la dirección a la que mirará el player al cargar la escena

    [SerializeField] private string uuid;//Identificador único para guardar el nombre de este Star Point

    // Start is called before the first frame update
    void Start()
    {
        //Captura player y cámara
        player = FindObjectOfType<PlayerController>();
        _camera = FindObjectOfType<CameraFollow>();

        //Solo si el identificador del star point al que debe ir el player coincide con el de éste star point
        //Se enviará al jugador y a la cámara a su misma posición:
        if (player.nextUuid == uuid)
        {
            //Coloca ambos en la posición del Start Point
            player.transform.position = transform.position;
            _camera.transform.position = new Vector3(transform.position.x,
                transform.position.y, _camera.transform.position.z);

            //Actualiza la dirección hacia la que mira el player
            player.lastMovement = facingDirection;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
