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


    //Para controlar el ataque
    public float attackTime = 0.6f;//Tiempo de duración del ataque del player, para permitir ver la animación hasta el final
    private float attackTimeCounter;//Contador de tiempo transcurrido desde el inicio del ataque

    //Para controlar las animaciones con el Blentree:
    private bool walking;
    private bool atacking;
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


        //Control del ataque (prevalece sobre el movimiento, por eso se pone antes)
        if (atacking)//Si ya está atacando, descontaremos el tiempo hasta el próximo ataque
        {
            attackTimeCounter -= Time.deltaTime;
            if(attackTimeCounter <= 0)//Transcurrido el tiempo de ataque, detiene el mismo
            {
                atacking = false;
                _animator.SetBool("Attacking", false);
            }
        }
        else//Al pulsar el botón del mouse, si no está atacando ya inicia un ataque
        {            
            if (Input.GetMouseButtonDown(0))
            {
                atacking = true;
                attackTimeCounter = attackTime;//Reinicia el contador de tiempo de duración del ataque

                _rigidbody.velocity = Vector2.zero;//Detiene el movimiento del player al atacar
                _animator.SetBool("Attacking", true);//Inicia la animación de ataque


            }
        }



        //Movimiento del player: E = V * t
        //GetAxisRaw recoge el movimiento exacto del joystick
        movH = Input.GetAxisRaw(AXIS_H);
        movV = Input.GetAxisRaw(AXIS_V);
        
        
        //Solo se moverá si el joystick se mueve al menos en un 20%
        if (Mathf.Abs(movH) > 0.2f)
        {
            /*//Movimiento sin utilizar físicas
            Vector3 translation = new Vector3(movH * speed * Time.deltaTime, 0, 0);
            transform.Translate(translation); */

            //Movimiento utilizando físicas (no necesita utilizar el deltaTime)
            //Se normaliza el vector antes de multiplicar por la velocidad
            //Para evitar que el movimiento en diagonal, cuando se pulse en los dos
            //ejes a la vez, sea más rápido que el movimiento horizontal o vertical
            _rigidbody.velocity = new Vector2(movH,
                _rigidbody.velocity.y).normalized * speed;

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
                movV).normalized * speed;

            walking = true;
            lastMovement = new Vector2(0, movV);
        }
        else
        {//Ajusta el movimiento si no hay pulsación en este eje
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,
                0f);
        }

        
        
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
