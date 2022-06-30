using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona una misión concreta

public class Quest : MonoBehaviour
{
    public int questID;//Identificador de la misión

    public bool questCompleted = false;//Para saber si la quest ha sido completada

    public string title;//Título de la misión
    
    public string startText;//Texto de la misión cuando comienza

    public string completedText;//Texto de la misión cuando se completa

    public bool needsItem;//True si la misión requiere recolectar items
    public List <QuestItem> itemsNeeded;//Lista de items que pueda tener la misión

    private QuestManager questManager;//Acceso al manager de misiones
    

   
    

    /// <summary>
    /// Inicia la misión mostrando la información inicial
    /// </summary>
    public void StartQuest()
    {
        questManager = FindObjectOfType<QuestManager>();//Captura el questManager
        questManager.ShowTextQuest(title + "\n" + startText);
    }


    /// <summary>
    /// Da por finalizada la misión, mostrando el texto final y la desactiva
    /// </summary>
    public void CompleteQuest()
    {
        questManager = FindObjectOfType<QuestManager>();//Captura el questManager

        questManager.ShowTextQuest(title + "\n" + completedText);

        questCompleted = true;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //Si la misión necesita items, y en el manager ya se ha indicado que se ha recogido alguno
        if(needsItem && questManager.itemCollected != null)
        {
            //Comprueba si en la lista de items que la misión necesita está el que ha sido recogido
            for(int i = 0; i < itemsNeeded.Count; i++)
            {
                if(itemsNeeded[i].itemName == questManager.itemCollected.itemName)
                {//Si es así, el item se elimina de la lista de esta quest
                    itemsNeeded.RemoveAt(i);
                    //Y también se "limpia" del manager de misiones
                    questManager.itemCollected = null;
                    break;
                }
            }

            //Si ya se han encontrado todos los items de la lista, ésta estará vacía
            //Por lo que la misión se da por completada
            if (itemsNeeded.Count <= 0)
                CompleteQuest();
        }
    }
}
