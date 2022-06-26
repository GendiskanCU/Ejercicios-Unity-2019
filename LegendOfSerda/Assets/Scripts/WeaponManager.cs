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
    }
    
}
