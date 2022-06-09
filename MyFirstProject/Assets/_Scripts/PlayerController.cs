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

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        currentMoveSpeed = moveSpeed;
        currentRotateSpeed = rotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetAxis("Fire1") > 0.5f)//Si se pulsa la tecla Left Control se reduce la velocidad de movimiento
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
}
