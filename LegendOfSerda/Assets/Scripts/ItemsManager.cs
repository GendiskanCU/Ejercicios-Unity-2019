using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se encarga de la gestión de los items que puede haber en el juego

public class ItemsManager : MonoBehaviour
{
    private List<GameObject> questItems = new List<GameObject>();//Lista de items de misión que ha recogido el player

    
    /// <summary>
    /// Devuelve los items de misión del juego
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetQuestItems()
    {
        return questItems;
    }
   

    /// <summary>
    /// Comprueba si un item es de tipo misión
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool HasTheQuestItem(QuestItem item)
    {
        foreach(GameObject qi in questItems)
        {
            if (qi.GetComponent<QuestItem>().itemName == item.itemName)
                return true;
        }

        return false;
    }


    /// <summary>
    /// Añade un item a la lista de items de misión recogido por el player
    /// </summary>
    /// <param name="newItem"></param>
    public void AddQuestItem(GameObject newItem)
    {
        questItems.Add(newItem);
    }


    /// <summary>
    /// Devuelve el item de la lista de items de misión recogidos que esté en la posición especificada
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    public QuestItem GetItemAt(int idx)
    {        
        return questItems[idx].GetComponent<QuestItem>();        
    }
}
