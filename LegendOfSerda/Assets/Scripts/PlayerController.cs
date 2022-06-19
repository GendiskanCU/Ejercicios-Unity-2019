using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Para controlar cuántas instancias del jugador existen (también en el script DontDestroyOnLoad)
    public static bool playerCreated;

    [SerializeField] private float speed = 5.0f;//Velocidad de movimiento

    private Rigidbody2D _rigidbody;

    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical";

    private Animator _animator;


    //Para guardar el movimiento en los ejes horizontal o vertical
    private float movH, movV;


    //Para controlar las animaciones con el Blentree:
    private bool walking;
    public Vector2 lastMovement = Vector2.zero;//También se utilizará para saber a dónde mirará el personaje al cargar la escena

    public string nextUuid;//Siguiente Start Point en el que deberá situarse cuando cargue la siguiente escena
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerCreated = true;//Se marca como creado


        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;

        //GetAxisRaw recoge el movimiento exacto del joystick
        movH = Input.GetAxisRaw(AXIS_H);
        movV = Input.GetAxisRaw(AXIS_V);

        //Movimiento del player: E = V * t
        
        //Solo se moverá si el joystick se mueve al menos en un 20%
        if (Mathf.Abs(movH) > 0.2f)
        {
            /*//Movimiento sin utilizar físicas
            Vector3 translation = new Vector3(movH * speed * Time.deltaTime, 0, 0);
            transform.Translate(translation); */

            //Movimiento utilizando físicas (no necesita utilizar el deltaTime)
            _rigidbody.velocity = new Vector2(movH * speed,
                _rigidbody.velocity.y);

            walking = true;//Indica a las animaciones que está caminando
            lastMovement = new Vector2(movH, 0);//Actualiza la última dirección hacia la que estaba caminando
        }
        else
        {//Ajusta el movimiento si no hay pulsación en este eje
            _rigidbody.velocity = new Vector2(0f,
                _rigidbody.velocity.y);
        }

        if (Mathf.Abs(movV) > 0.2f)
        {
            /*//Movimiento sin utilizar físicas
            Vector3 translation = new Vector3(0, movV * speed * Time.deltaTime, 0);
            transform.Translate(translation);*/

            //Movimiento utilizando físicas
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,
                movV * speed);

            walking = true;
            lastMovement = new Vector2(0, movV);
        }
        else
        {//Ajusta el movimiento si no hay pulsación en este eje
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,
                0f);
        }

        if (!walking)//Detiene al personaje cuando no haya pulsación del joystick en ningún eje
            _rigidbody.velocity = Vector2.zero; ;
    }

    private void LateUpdate()
    {
        //Animaciones del player en movimiento
        _animator.SetFloat("Horizontal", movH);
        _animator.SetFloat("Vertical", movV);        
        
        //Para activar el blend tree de movimiento o de parado
        _animator.SetBool("Walking", walking);

        //Animaciones del player parado                  
        _animator.SetFloat("LastHorizontal", lastMovement.x);
        _animator.SetFloat("LastVertical", lastMovement.y);

    }
}
