using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;//Velocidad movimiento inicial
    [SerializeField] private float rotateSpeed = 60f;//Velocidad(grados) rotación    

    private float currentMoveSpeed;//Velocidad de movimiento actual
    private float currentRotateSpeed;//Velocidad de rotación actual

    private float hInput, vInput;//Movimiento en el eje Horizontal, Vertical

    private Rigidbody _rigidbody;

    //Para el control del salto:
    [SerializeField] private float jumpSpeed = 5f;//Velocidad de salto
    [SerializeField] private float distanceToGround = 0.1f;//Distancia máxima a objetos marcados con la capa Ground para poder saltar
    [SerializeField] private LayerMask groundLayer;//Capa a la que pertenece el suelo
    private CapsuleCollider _collider;//Collider del personaje

    //Para el control del disparo
    [SerializeField] private GameObject bullet;//Prefab de la bala
    [SerializeField] private Transform shootPoint;//Punto de disparo
    [SerializeField] private float bulletSpeed = 100f;//Velocidad de la bala

    //Para acceder al GameManager
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        currentMoveSpeed = moveSpeed;
        currentRotateSpeed = rotateSpeed;

        _collider = GetComponent<CapsuleCollider>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetAxis("Fire1") > 0.5f)//Si se pulsa la tecla Left Control se reduce la velocidad de movimiento y rotación
        {
            currentMoveSpeed = moveSpeed / 2.0f;
            currentRotateSpeed = rotateSpeed / 2.0f;
        }
        else
        {
            currentMoveSpeed = moveSpeed;
            currentRotateSpeed = rotateSpeed;
        }
        
        hInput = Input.GetAxis("Horizontal") * currentRotateSpeed;
        vInput = Input.GetAxis("Vertical") * currentMoveSpeed;

        //Disparo al pulsar el botón principal del ratón
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet =
                Instantiate(bullet, shootPoint.position, shootPoint.rotation)
                as GameObject;
            
            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            bulletRb.velocity = shootPoint.forward * bulletSpeed;
        }


        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround())//Si se pulsa Espacio, salta si está tocando la capa Ground
        {
            _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

        //Movimiento sin física
        /*transform.Rotate(Vector3.up * hInput * Time.deltaTime);//Rota
        transform.Translate(Vector3.forward * vInput * Time.deltaTime);//Mueve*/
        
    }

    private void FixedUpdate()
    {
        //Movimiento con física
        _rigidbody.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);//Mueve

        Vector3 rotation = Vector3.up * hInput;//Calcula la rotación
        Quaternion angleRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);//Calcula el ángulo de rotación
        _rigidbody.MoveRotation(_rigidbody.rotation * angleRotation);//Rota        
    }

    /// <summary>
    /// Comprueba si el personaje está tocando la capa de suelo
    /// </summary>
    /// <returns>true si está tocando el suelo, false en caso contrario</returns>
    private bool IsOnTheGround()
    {
        //Punto inferior del personaje: Como tiene forma de cápsula, su límite inferior estará en el centro de X,
        //centro de Z y la parte más baja en Y de su collider, coordenada que se puede obtener así:
        Vector3 capsuleBotton = new Vector3(_collider.bounds.center.x,
            _collider.bounds.min.y, _collider.bounds.center.z);

        //Utilizaremos el método Check (en este caso de una cápsula, ya que es la forma del collider) para averiguar si
        //la parte inferior del collider está a una distancia menor o igual que la que hemos fijado como máxima para "tocar"
        //Los parámetros que este método requiere en este caso son los siguientes:
        //Punto de inicio de la cápsula (punto central), Punto inferior del collider,
        //Distancia en dirección hacia abajo, capa de comprobación de colisión, ignorando interacciones de triggers
        bool onTheGround = Physics.CheckCapsule(_collider.bounds.center, capsuleBotton,
            distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return onTheGround;
    }

    /// <summary>
    /// Si el jugador colisiona con un enemigo se le restará una vida
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameManager.HP--;
        }
    }
}
