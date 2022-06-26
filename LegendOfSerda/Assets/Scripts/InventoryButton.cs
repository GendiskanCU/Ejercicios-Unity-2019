using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controla los botones de inventario que pueden aparecer en la UI
public class InventoryButton : MonoBehaviour
{
    
    public enum ItemType { WEAPON, ITEM, ARMOR, RING };//Todos los tipos de ítems que puede haber en el inventario
    
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
        }
    }
}
