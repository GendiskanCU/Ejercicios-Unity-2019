using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//Mostrará un texto en movimiento con la cantidad de daño que un golpe hace a un enemigo
public class DamageNumber : MonoBehaviour
{
    public float damageSpeed;//Velocidad del texto
    public float damagePoints;//Cantidad que aparecerá en el texto

    public Text damageText;//Text de la UI que mostrará el texto

    public Vector2 direction = new Vector2(1, 0);//Dirección hacia la que se irá moviendo el texto
    public float timeToChangeDirection = 0.5f;//Tiempo tras el cual irá cambiando de dirección
    public float timeToChangeDirectionCounter;//Cronómetro de tiempo transcurrido desde el último cambio de dirección

    //public TextMeshProUGUI damageTextAlt;//Text alternativo de la UI que mostrará el texto


    private void Start()
    {
        timeToChangeDirectionCounter = timeToChangeDirection + timeToChangeDirection / 2;
    }


    // Update is called once per frame
    void Update()
    {
        damageText.text = "" + damagePoints;
        //damageTextAlt.text = "" + damagePoints;

            
    }

    private void FixedUpdate()
    {
        timeToChangeDirectionCounter -= Time.fixedDeltaTime;
        if(timeToChangeDirectionCounter <= timeToChangeDirection / 2)//Cuando el contador llegue a la mitad del tiempo establecido para cambiar la dirección
        {
            direction *= -1;//Cambia la dirección de movimiento
            timeToChangeDirectionCounter += timeToChangeDirection;//Suma nuevamente el tiempo establecido
        }


        //El canvas con el texto irá subiendo a la velocidad marcada y moviéndose hacia un lado
        transform.position = new Vector3(transform.position.x + direction.x * damageSpeed * Time.fixedDeltaTime,
            transform.position.y + damageSpeed * Time.fixedDeltaTime,
            transform.position.z);



        //También se irá haciendo más pequeño
        transform.localScale = transform.localScale * (1 - Time.fixedDeltaTime);
    }
}
