using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controla los botones de inventario que pueden aparecer en la UI
public class InventoryButton : MonoBehaviour
{
    
    public enum ItemType { WEAPON = 0, ITEM = 1, ARMOR = 2, RING = 3, SPECIAL_ITEMS = 4 };//Todos los tipos de ítems que puede haber en el inventario
    
    public int itemId;//Indice del ítem asociado al botón

    public ItemType type;//Tipo de ítem asociado al botón

    /// <summary>
    /// Ejecuta el código relativo al tipo de ítem asociado al botón
    /// </summary>
    public void ActivateButton()
    {
        switch(type)
        {
            case ItemType.WEAPON:
                //Cambia el arma equipada
                FindObjectOfType<WeaponManager>().ChangeWeapon(itemId);                
                break;
            case ItemType.ITEM:
                Debug.Log("Activa la acción del ítem seleccionado");
                break;
            case ItemType.ARMOR:
                Debug.Log("Equipa la armadura seleccionada");
                break;
            case ItemType.RING:
                Debug.Log("Equipa el anillo seleccionado");
                break;
            case ItemType.SPECIAL_ITEMS:                                                
                break;
        }

        ShowDescription();
    }

   


    /// <summary>
    /// Muestra en el canvas del inventario la información sobre el item seleccionado, o sobre el que pasa el cursor
    /// </summary>
    public void ShowDescription()
    {
        switch (type)
        {
            case ItemType.WEAPON:                
                //Muestra el nombre del arma bajo el inventario:
                FindObjectOfType<UIManager>().inventoryTex.text = FindObjectOfType<WeaponManager>().GetWeaponAt(itemId).weaponName;
                break;
            case ItemType.ITEM:
                Debug.Log("Activa la acción del ítem seleccionado. Pendiente de implementar");
                break;
            case ItemType.ARMOR:
                Debug.Log("Equipa la armadura seleccionada. Pendiente de implementar");
                break;
            case ItemType.RING:
                Debug.Log("Equipa el anillo seleccionado. Pendiente de implementar");
                break;
            case ItemType.SPECIAL_ITEMS:
                //Muestra la descripción del item bajo el inventario:
                QuestItem item = FindObjectOfType<ItemsManager>().GetItemAt(itemId);                
                FindObjectOfType<UIManager>().inventoryTex.text = "Quest item: " + item.itemName;
                break;
        }
    }


    /// <summary>
    /// Deja en blanco la información sobre los items seleccionados en el canvas del inventario
    /// </summary>
    public void ClearDescription()
    {
        FindObjectOfType<UIManager>().inventoryTex.text = "";
    }
}
