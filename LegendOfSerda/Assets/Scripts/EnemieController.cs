using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
    [Tooltip("Velocidad de movimiento")]
    public float speed = 1f;//Velocidad de movimiento del enemigo

    [Tooltip("Tiempo de pausa del enemigo entre dos pasos sucesivos")]
    public float timeBetweenSteps;//Tiempo entre pasos
    private float timeBetweenStepsCounter;//Tiempo transcurrido desde el último paso

    [Tooltip("Tiempo que tarda el enemigo en dar un paso")]
    public float timeToMakeSteep;//Tiempo para dar un paso
    private float timeToMakeSteepCounter;//Tiempo transcurrido desde que se inició el paso

    private Vector2 directionToMove;//Dirección de movimiento

    private Rigidbody2D _rigidbody;//El enemigo se moverá utilizando las físicas
    private bool isMoving;//Para controlar si el enemigo está en movimiento



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        //Genera aleatoriamente los tiempos transcurridos para que
        //cada instancia de enemigo arranque en un momento diferente
        //y así evita que todos se muevan a la vez
        timeBetweenStepsCounter = timeBetweenSteps * Random.Range(0.5f, 1.5f);
        timeToMakeSteepCounter = timeToMakeSteep * Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            timeToMakeSteepCounter -= Time.deltaTime;
            _rigidbody.velocity = directionToMove * speed;
            //Cuando se quede sin tiempo de movimiento, el enemigo para
            //Y reinicia el contador de tiempo para estar parado
            if(timeToMakeSteepCounter <= 0)
            {
                _rigidbody.velocity = Vector2.zero;
                timeBetweenStepsCounter = timeBetweenSteps;                
                isMoving = false;
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            //Cuando se quede sin tiempo de estar parado, arranca de nuevo
            //en una dirección aleatoria y reinicia el contador
            //de tiempo para dar el siguiente paso
            if(timeBetweenStepsCounter <= 0)
            {
                directionToMove = new Vector2(Random.Range(-1, 2),
                    Random.Range(-1, 2));
                timeToMakeSteepCounter = timeToMakeSteep;
                isMoving = true;                
            }
        }
    }
}
