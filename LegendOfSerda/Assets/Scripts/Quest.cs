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
}
