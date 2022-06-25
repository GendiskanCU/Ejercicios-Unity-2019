using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla el daño al player

public class DamagePlayer : MonoBehaviour
{
    public int damage = 1;//Daño inicial que hace el enemigo

    public GameObject CanvasDamage;//Canvas de texto que aparecerá informando del daño causado

    private CharacterStats statsPlayer;//Estadísticas del player, para reducir el daño en función de su defensa actual (que depende de su nivel)
    private CharacterStats stats;//Estadísticas del enemigo, para aumentar el daño en función de su nivel actual

    /*
    public float timeToRevivePlayer;//Tiempo que tardará el player en revivir una vez muerto

    private float timeRevivalCounter;//Tiempo transcurrido desde la muerte del player
    private bool playerReviving;//Para controlar si el player tiene el modo de revivir en marcha

    private GameObject player;//Para capturar al player*/


    private void Start()
    {
        //Captura las estadísticas del jugador
        statsPlayer = GameObject.Find("Player").GetComponent<CharacterStats>();
        //Captura las estadísticas del enemigo
        stats = GetComponent<CharacterStats>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")//Cuando colisione contra el player llamará al método para reducir su vida
        {
            //Recalcula el daño a hacer en función de la estadística de fuerza del enemigo y de defensa del player
            //asegurándonos de que nunca pueda haber un daño inferior a uno
            int totalDamage = Mathf.Clamp(damage + stats.strengLevels[stats.level] - statsPlayer.defenseLevels[statsPlayer.level], 1, 9999);
            //int totalDamage = Mathf.Clamp(damage * (1 - stats.defenseLevels[stats.level] / CharacterStats.MAX_STAT_VALUE), 1, 9999);

            //Según la probabilidad de que el ataque falle en función de la
            //estadística de suerte del player el ataque puede quedarse en cero:
            if(Random.Range(0, CharacterStats.MAX_STAT_VALUE) < statsPlayer.luckLevels[statsPlayer.level])
            {
                totalDamage = 0;
            }


            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage);

            //Mostrará un texto con el daño ocasionado
            GameObject clone = Instantiate(CanvasDamage, collision.gameObject.transform.position,
                    Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;

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
