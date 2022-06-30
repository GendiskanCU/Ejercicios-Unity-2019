using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla todas las misiones existentes

public class QuestManager : MonoBehaviour
{
    private List<Quest> quests;//Lista de todas las misiones hijas del questmanager

    private DialogueManager dialogueManager;//Para poder mostrar la información de las misiones

    public QuestItem itemCollected;//Último item que ha sido recolectado en las misiones que los tengan

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();        

        //Se rellena la lista de misiones con todas las que están definidas como hijos
        quests = new List<Quest>();
        foreach (Transform t in transform)
        {
            quests.Add(t.gameObject.GetComponent<Quest>());
        }
        
    }

    /// <summary>
    /// Invoca al DialogueManager para que muestre la información de alguna de las misiones
    /// </summary>
    public void ShowTextQuest(string questText)
    {
        //Como el método ShowDialogue espera un array, lo creamos con el único string que necesitamos
        dialogueManager.ShowDialogue(new string[] { questText });
    }

    /// <summary>
    /// Devuelve la misión existente cuyo identificador coincida con el especificado
    /// Devuelve nulo si no se encuentra la misión especificada
    /// </summary>
    /// <param name="questID"></param>
    /// <returns></returns>
    public Quest QuestWithID(int questID)
    {
        Quest q = null;

        foreach(Quest f in quests)
        {
            if (f.questID == questID)
                q = f;
        }

        return q;
    }
}
