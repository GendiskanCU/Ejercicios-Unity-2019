using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona los trigger que marcan los inicios y finales de las misiones

public class QuestTrigger : MonoBehaviour
{

    //Para acceder al QuestManager del juego
    private QuestManager questManager;

    public int questID;//Id de la misión que iniciará o finalizará

    public bool startPoint, endPoint;//Para saber si el trigger marca el inicio o el fin de la misión

    private bool playerInZone;//Para saber si el player está dentro de la zona de activación

    public bool automaticCatch;//Para controlar si la misión se aceptará automáticamente o si hay que hacer alguna acción para ello

    private void Start()
    {
        questManager = GameObject.FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            playerInZone = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInZone = false;
        }
    }


    private void Update()
    {
        if(playerInZone)//Cuando el jugador esté en la zona de activación
        {
            //Si la activación es automática, o no lo es pero se pulsa la tecla Q
            if (automaticCatch || (!automaticCatch && Input.GetKeyDown(KeyCode.Q)) )
            {
                
                //Captura la quest correspondiente al id actual
                Quest newQuest = questManager.QuestWithID(questID);

                if (newQuest == null)//Si no se encontrará el Id sale sin hacer nada
                {
                    Debug.LogErrorFormat("La misión id {0} no existe", questID);
                    return;
                }

                //Si la misión actual no se ha completado previamente (no queremos que se repetible)
                if (!newQuest.questCompleted)
                {
                    if(startPoint)//Si está en el inicio de la misión
                    {
                        //Arranca la misión, siempre que no esté ya iniciada
                        if(!newQuest.gameObject.activeInHierarchy)
                        {
                            //Debug.Log("Misión activada");
                            newQuest.gameObject.SetActive(true);
                            newQuest.StartQuest();
                        }
                    }
                    if(endPoint)//Si está en el final de la misión
                    {
                        //Finaliza la misión, siempre que haya sido iniciada antes
                        if(newQuest.gameObject.activeInHierarchy)
                        {
                            newQuest.CompleteQuest();
                        }
                    }
                }
            }            
        }
    }
}
