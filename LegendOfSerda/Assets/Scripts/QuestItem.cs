using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

//Controla el comportamiento de Items de las misiones en las que estos existan
public class QuestItem : MonoBehaviour
{
    public int questID;//Misión a la que pertenece el item

    private QuestManager questManager;//Para acceder al manager de misiones

    private ItemsManager itemsManager;//Para acceder al manager de misiones

    public string itemName;//Nombre del item

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            //Captura el manager de quests
            questManager = FindObjectOfType<QuestManager>();
            //Captura el manager de items
            itemsManager = FindObjectOfType<ItemsManager>();

            //Busca la quest con el Id correspondiente
            Quest newQuest = questManager.QuestWithID(questID);
            //Si no existiera, notifica el error y sale sin hacer nada más
            if(newQuest == null)
            {
                Debug.LogErrorFormat("La misión Id {0} no existe!!", questID);
                return;
            }

            //Solo si la misión correspondiente está activa/sin finalizar recoger el item tendrá efecto
            if (newQuest.gameObject.activeInHierarchy && !newQuest.questCompleted)
            {
                //Notifica al manager de misiones que el item ha sido recogido
                questManager.itemCollected = this;
                //Añade en el manager de items el item recogido a la lista de items
                itemsManager.AddQuestItem(this.gameObject);
                //Hace desaparacer el item de la escena
                gameObject.SetActive(false);
            }

        }
    }
}
