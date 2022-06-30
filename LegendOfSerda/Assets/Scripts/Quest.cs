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


    public bool killsEnemy;//True si la misión requiere matar un número de enemigos
    public List<QuestEnemy> enemies;//Lista de enemigos a eliminar que pueda tener la misión
    public List<int> numberOfEnemies;//Número de enemigos de cada tipo que deban ser eliminados

    private QuestManager questManager;//Acceso al manager de misiones

    public Quest nextQuest;//Próxima que se activará cuando se complete la actual, si procede
    
    
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
    /// Activa la siguiente misión, si es que existe
    /// </summary>
    public void CompleteQuest()
    {
        questManager = FindObjectOfType<QuestManager>();//Captura el questManager

        questManager.ShowTextQuest(title + "\n" + completedText);

        questCompleted = true;
        gameObject.SetActive(false);

        if (nextQuest != null)
        {
            Invoke("ActivateNextQuest", 5.0f);
        }
    }


    /// <summary>
    /// Activa e inicia la siguiente Quest
    /// </summary>
    public void ActivateNextQuest()
    {
        nextQuest.gameObject.SetActive(true);
        nextQuest.StartQuest();
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


        //Si la misión consiste en eliminar enemigos y en el manager ya se ha indicado que se ha eliminado alguno
        if(killsEnemy && questManager.enemyKilled != null)
        {
            //Comprueba el que ha sido eliminado es del tipo de los que están en la lista de enemigos a eliminar
            for(int i = 0; i < enemies.Count; i++)
            {
                if(enemies[i].enemyName == questManager.enemyKilled.enemyName)
                {
                    //En cuyo caso se resta el número de enemigos de ese tipo a eliminar para completar la misión
                    numberOfEnemies[i]--;
                    //Y también se "limpia" del manager de misiones
                    questManager.enemyKilled = null;                   

                    //Se comprueba si quedan enemigos de ese tipo por eliminar para completar la misión
                    if(numberOfEnemies[i] <= 0)
                    {
                        //En cuyo caso se eliminan de la lista de enemigos a eliminar
                        enemies.RemoveAt(i);
                        numberOfEnemies.RemoveAt(i);
                    }

                    break;
                }
            }

            //Cuando ya no queden enemigos por matar de ningún tipo, la lista de enemigos estará vacía
            //Por lo que la misión se da por completada
            if(enemies.Count <= 0)
            {
                CompleteQuest();
            }
        }
    }
}
