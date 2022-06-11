using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private int playerHP = 3;//Vida del player
    public int HP
    {
        get { return playerHP; }
        set
        {
            if (value >= 0 && value <= 3)
            {
                playerHP = value;
            }
            Debug.LogFormat("Vidas: {0}", playerHP);
        }

    }

    private int itemsCollected = 0;//Items recogidos por el jugador
    public int Items
    {
        get { return itemsCollected;  }
        set 
        {
            if (value >= 0)
            {
                itemsCollected = value;
            }
            Debug.LogFormat("Items: {0}", itemsCollected);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
