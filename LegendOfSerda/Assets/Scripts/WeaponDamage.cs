using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla el daño que hará el arma sobre los enemigos

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño que hace el arma")]
    public int damage; //Daño inicial del arma

    public string weaponName;//Nombre del arma

    public GameObject bloodAnim;//Efecto de partículas de sangre al golpear a un enemigo

    public GameObject CanvasDamage;//Canvas de texto que aparecerá informando del daño causado

    private GameObject hitPoint;//Punto de aparición del efecto de sangre

    private CharacterStats stats;//Estadísticas del player, para conocer el nuevo daño que hará el arma al subir de nivel

    private void Start()
    {
        //Localiza el hitpoint dentro de sus hijos
        hitPoint = transform.Find("HitPoint").gameObject;

        //Captura las estadísticas del player
        stats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemie"))//Si el arma choca con un enemigo le hará daño
        {
            //Actualiza el daño según el nivel actual del player
            int totalDamage = damage + stats.strengLevels[stats.level];
            //int totalDamage = damage * (1 + stats.strengLevels[stats.level] / CharacterStats.MAX_STAT_VALUE);

            //Según la probabilidad de que el ataque falle en función de la
            //estadística del player el ataque puede quedarse en cero:
            if (Random.Range(0, CharacterStats.MAX_STAT_VALUE) > stats.accuracyLevels[stats.level])
            {
                totalDamage = 0;
            }

            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage);

            //Mostrará un texto con el daño ocasionado
            if (CanvasDamage != null && hitPoint != null)
            {
                GameObject clone = Instantiate(CanvasDamage, hitPoint.transform.position,
                    Quaternion.identity);
                clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
            }

            //Y muestra el efecto de sangre, si se ha establecido alguno en la vista diseño
            //Y además el arma tiene establecido un punto de golpe
            if (bloodAnim != null && hitPoint != null)
                Instantiate(bloodAnim, hitPoint.transform.position, hitPoint.transform.rotation);
        }
    }
}