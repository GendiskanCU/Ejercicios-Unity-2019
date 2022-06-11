using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Para destruir cualquier objeto transcurrido un tiempo determinado
/// </summary>
public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 1.5f;//Tiempo para la destrucción del objeto
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }    
}
