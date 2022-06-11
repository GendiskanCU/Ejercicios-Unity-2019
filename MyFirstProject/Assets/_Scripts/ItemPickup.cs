using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //El item desaparece porque el player lo ha recogido
            Destroy(transform.parent.gameObject);
            Debug.Log("Item recogido");

            gameManager.Items++;
        }
    }
}
