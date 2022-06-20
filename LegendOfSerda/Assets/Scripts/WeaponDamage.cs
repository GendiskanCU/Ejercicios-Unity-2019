using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla el daño que hará el arma sobre los enemigos

public class WeaponDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemie"))//Si el arma choca con un enemigo
        {
            Destroy(collision.gameObject);
        }
    }
}
