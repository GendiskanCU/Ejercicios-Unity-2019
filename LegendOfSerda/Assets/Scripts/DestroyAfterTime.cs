using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destruye un objeto al finalizar el tiempo establecido

public class DestroyAfterTime : MonoBehaviour
{

    public float timeToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);    
    }


}
