using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla que el acceso del player a la zona que activa el diálogo con cada NPC 
//Controla también los mensajes informativos colocados en puntos de la escena (ExtraInfo)

[RequireComponent(typeof(CircleCollider2D))]

public class NPCDialogue : MonoBehaviour
{
    public string npcName;//Nombre del NPC
    public string [] npcDialogueLines;//Líneas de diálogo que ofrece el NPC
    public Sprite npcSprite;//Sprite que representa al NPC

    private DialogueManager dialogueManager;
    private bool playerInTheZone;//Para controlar si el player está dentro de la zona de diálogo

    private string[] finalDialogue;//Líneas de diálogo que ofrece el NPC formateadas   

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();

        //Si el NPC tiene nombre, aparacerá al principio de cada línea de diálogo
        finalDialogue = new string[npcDialogueLines.Length];
        for (int i = 0; i < npcDialogueLines.Length; i++)
        {
            finalDialogue[i] = (npcName != null) ?
            npcName + "\n" + npcDialogueLines[i] : npcDialogueLines[i];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = false;
        }
    }

    private void Update()
    {
        //Cuando el player esté en la zona de diálogo y se pulse E
        if(playerInTheZone && Input.GetKeyDown(KeyCode.E))
        {
            //Se detiene el movimiento del NPC (que será padre de este objeto)
            if(gameObject.GetComponentInParent<NPCMovement>() != null)
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }

            //En función de si el NPC tiene sprite o no, se muestra el diálogo de forma diferente:
            if (npcSprite == null)
                dialogueManager.ShowDialogue(finalDialogue);
            else
                dialogueManager.ShowDialogue(finalDialogue, npcSprite);
        }
    }
}
