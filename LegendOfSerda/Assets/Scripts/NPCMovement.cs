using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla el movimiento de los NPC

public class NPCMovement : MonoBehaviour
{
    public float speed = 1.5f;//Velocidad de movimiento

    private Rigidbody2D _rigidbody;

    public bool isWalking = false;//Para controlar cuándo se mueve el NPC

    //Para controlar el movimiento
    public float walkTime = 1.5f;//Duración de cada paso
    public float walkCounter;//Contador de la duración de cada paso
    public float waitTime = 4.0f;//Tiempo de espera entre pasos
    public float waitCounter;//Contador del tiempo de espera entre pasos

    //Posibles direcciones de movimiento del NPC (se excluyen movimientos horizontales)
    private Vector2[] walkingDirections =
        { Vector2.up, Vector2.down, Vector2.left, Vector2.right};

    private int currentDirection;//Dirección de movimiento actual

    private Animator _animator;//Animaciones del NPC

    public BoxCollider2D npcZone;//Zona por la que podrá moverse el NPC

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    private void FixedUpdate()
    {
        if(isWalking)//Cuando esté caminando
        {
            StayInZone();

            //Se aplica la velocidad en la dirección actual (no utiliza deltaTime porque estamos aplicando
            //velocidad a la física, no estamos cambiando directamente la posición)
            Debug.Log(currentDirection);
            _rigidbody.velocity = walkingDirections[currentDirection] * speed;
            walkCounter -= Time.fixedDeltaTime;
            
            if(walkCounter <= 0)
            {
                StopWalking();
            }
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
            waitCounter -= Time.fixedDeltaTime;
            if(waitCounter <= 0)
            {
                StartWalking();
            }
        }
    }


    private void LateUpdate()
    {
        //Aplicamos la animación correspondiente al movimiento actual
        _animator.SetBool("Walking", isWalking);
        _animator.SetFloat("Horizontal", walkingDirections[currentDirection].x);
        _animator.SetFloat("Vertical", walkingDirections[currentDirection].y);
    }

    /// <summary>
    /// Inicia el movimiento del NPC
    /// </summary>
    public void StartWalking()
    {
        currentDirection = Random.Range(0, walkingDirections.Length);
        
        isWalking = true;

        walkCounter = walkTime;//Reinicia el contador de duración del paso
    }

    /// <summary>
    /// Detiene el movimiento del NPC
    /// </summary>
    public void StopWalking()
    {
        isWalking = false;

        waitCounter = waitTime;//Reinicia el contador de espera entre pasos

        _rigidbody.velocity = Vector2.zero;
    }

    /// <summary>
    /// Cambia la dirección si el NPC se va a salir de su zona de movimiento
    /// </summary>
    private void StayInZone()
    {
        //<Primero se comprueba si está dentro del collider que delimita la zona de movimiento
        //Comprueba si se sale de los límites en el eje X
        if (transform.position.x < npcZone.bounds.min.x || transform.position.x > npcZone.bounds.max.x)
        {
            //Debug.Log("Cambia la dirección en X");
            if (currentDirection == 2)
                currentDirection = 3;
            else if (currentDirection == 3)
                currentDirection = 2;
        }
        //Comprueba si se sale de los límites en el eje Y
        if(transform.position.y < npcZone.bounds.min.y || transform.position.y > npcZone.bounds.max.y)
        {
            //Debug.Log("Cambia la dirección en Y");
            if (currentDirection == 0)
                currentDirection = 1;
            else if (currentDirection == 1)
                currentDirection = 0;
        }
    }
}
