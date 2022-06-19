using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{

    [SerializeField] private string newPlaceName;//Escena que se debe cargar
    [SerializeField] private bool needsClick;//Necesita que se haga click para transportar al player?

    [SerializeField] private string uuid;//Identificador del Start Point en el que el player deberá aparecer en la siguiente escena

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Cargará la nueva escena si no es necesario hacer click        
        if (collision.gameObject.tag == "Player" && !needsClick)           
        {
            Teleport();            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Cargará la nueva escena cuando sea necesario hacer click y se haga click
        if (collision.gameObject.tag == "Player" &&
           (needsClick && Input.GetMouseButton(0)))
        {
            Teleport();            
        }
    }

    /// <summary>
    /// Actualiza el punto de salida del jugador en la escena que se va a cargar
    /// y posteriormente carga dicha escena
    /// </summary>
    private void Teleport()
    {
        FindObjectOfType<PlayerController>().nextUuid = uuid;
        SceneManager.LoadScene(newPlaceName);
    }
}
