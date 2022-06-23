using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla el daño que hará el arma sobre los enemigos

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño que hace el arma")]
    public int damage; //Daño del arma

    public GameObject bloodAnim;//Efecto de partículas de sangre al golpear a un enemigo

    private GameObject hitPoint;//Punto de aparición del efecto de sangre

    private void Start()
    {
        //Localiza el hitpoint dentro de sus hijos
        hitPoint = transform.Find("HitPoint").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemie"))//Si el arma choca con un enemigo le hará daño
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);

            //Y muestra el efecto de sangre, si se ha establecido alguno en la vista diseño
            //Y además el arma tiene establecido un punto de golpe
            if(bloodAnim != null && hitPoint != null)
                Instantiate(bloodAnim, hitPoint.transform.position, hitPoint.transform.rotation);
        }
    }
}
