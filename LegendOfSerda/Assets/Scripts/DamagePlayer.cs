using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla el daño al player

public class DamagePlayer : MonoBehaviour
{
    public int damage = 1;//Daño que hace el enemigo

    /*
    public float timeToRevivePlayer;//Tiempo que tardará el player en revivir una vez muerto

    private float timeRevivalCounter;//Tiempo transcurrido desde la muerte del player
    private bool playerReviving;//Para controlar si el player tiene el modo de revivir en marcha

    private GameObject player;//Para capturar al player*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")//Cuando colisione contra el player llamará al método para reducir su vida
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            /*            
            player = collision.gameObject;//Guardamos una referencia al player
            player.SetActive(false);//Lo desactivará temporalmente
            playerReviving = true;
            timeRevivalCounter = timeToRevivePlayer;//Reinicia el contador de revivir*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(playerReviving)
        {
            timeRevivalCounter -= Time.deltaTime;
            if(timeRevivalCounter <= 0)//Finalizado el tiempo para revivir
            {
                playerReviving = false;
                player.SetActive(true);//Vuelve a activar al player
            }
        }*/
    }
}
