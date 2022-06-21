using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla el daño que hará el arma sobre los enemigos

public class WeaponDamage : MonoBehaviour
{
    [Tooltip("Cantidad de daño que hace el arma")]
    public int damage; //Daño del arma

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemie"))//Si el arma choca con un enemigo le hará daño
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
        }
    }
}
