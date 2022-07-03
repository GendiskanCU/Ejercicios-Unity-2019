using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla las monedas que el player puede recoger

[RequireComponent(typeof(BoxCollider2D))]

public class Money : MonoBehaviour
{
    public int value;//Valor de la moneda al recogerla

    private MoneyManager moneyManager;//Manager del total de monedas


    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Cuando la moneda sea recogida suma su valor al total
        if (collision.gameObject.name.Equals("Player"))
        {
            moneyManager.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
