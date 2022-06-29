using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Gestiona los diálogos con los NPC

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;//Panel que contiene los diálogos
    public Text dialogueText;//Cuadro de texto del diálogo
    public Image avatarImage;//Imagen del avatar del personaje con el que se dialoga

    public bool dialogueActive;//Para controlar si el diálogo está activo

    public string[] dialogueLines;//El panel admitirá más de una línea de diálogo
    public int currentDialogueLine;//Línea de diálogo que se muestra en cada momento

    private PlayerController player;//Para poder acceder al player e indicar que está dialogando

    private void Start()
    {
        dialogueBox.SetActive(false);
        dialogueActive = false;

        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si dentro del diálogo el jugador pulsa espacio
        if(dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogueLine++;//Pasa a la siguiente línea de diálogo

            if(currentDialogueLine >= dialogueLines.Length)//Si ya se han terminado las líneas de diálogo
            {
                dialogueActive = false; //Se desactiva el panel de diálogo
                //Desactiva la imagen de avatar si estaba presente
                if (avatarImage.gameObject.activeInHierarchy)
                    avatarImage.gameObject.SetActive(false);

                dialogueBox.SetActive(false);

                currentDialogueLine = 0;

                //Indica al player que ha finalizado el diálogo para que éste pueda reanudar su movimiento
                player.isTalking = false;
            }
            else
            {//En caso contrario, se muestra la siguiente línea
                dialogueText.text = dialogueLines[currentDialogueLine];
            }            
        }
    }


    /// <summary>
    /// Muestra el panel de diálogo y carga las diversas líneas de diálogo recibidas
    /// mostrando la primera de ellas
    /// </summary>
    /// <param name="text"></param>
    public void ShowDialogue(string [] lines)
    {
        dialogueLines = lines;

        currentDialogueLine = 0;

        dialogueActive = true;
        dialogueBox.SetActive(true);

        dialogueText.text = dialogueLines[currentDialogueLine];

        //Indica al player que está dialogando para que éste detenga su movimiento
        player.isTalking = true;
    }

    /// <summary>
    /// Activa la imagen de avatar con el sprite indicado
    /// Muestra el panel de diálogo y carga las diversas líneas de diálogo recibidas
    /// Mostrando la que corresponda
    /// </summary>
    /// <param name="text"></param>
    /// <param name="sprite"></param>
    public void ShowDialogue(string [] lines, Sprite sprite)
    {
        avatarImage.sprite = sprite;
        avatarImage.gameObject.SetActive(true);

        ShowDialogue(lines);
    }

    
}
