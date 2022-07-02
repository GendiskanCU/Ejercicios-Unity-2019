using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Controla las armas del player

public class WeaponManager : MonoBehaviour
{
    //Lista con las armas existentes
    private List<GameObject> weapons;

    public int activeWeapon = 0;//Arma activa
   

    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<GameObject>();
        //Captura todas las armas hijas
        foreach(Transform weapon in transform)
        {
            weapons.Add(weapon.gameObject);
        }

        //Establece el arma activa inicialmente
        for(int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == activeWeapon ? true : false);
        }

        //Cambia el icono que representa el arma activa en la UI
        GameObject.FindObjectOfType<UIManager>().UpdatePlayerAvatar(weapons[activeWeapon]);
    }

    /// <summary>
    /// Cambia el arma activa
    /// </summary>
    /// <param name="newWeapon"></param>
    public void ChangeWeapon(int newWeapon)
    {        
        weapons[activeWeapon].SetActive(false);
        weapons[newWeapon].SetActive(true);
        activeWeapon = newWeapon;

        //Cambia el icono que representa el arma activa en la UI
        GameObject.FindObjectOfType<UIManager>().UpdatePlayerAvatar(weapons[activeWeapon]);
    }

    /// <summary>
    /// Devuelve la lista de armas que tenga el player en su inventario (como objetos hijos)
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetAllWeapons()
    {
        return weapons;
    }


    /// <summary>
    /// Devuelve el WeaponDamage del arma concreta en la posición especificada
    /// Para poder utilizar las propiedades del arma (su nombre, daño,...)
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public WeaponDamage GetWeaponAt(int pos)
    {
        return weapons[pos].GetComponent<WeaponDamage>();
    }
    
}
