using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    private void Start()
    {
        

        int[] ranking = {4, 7, 9};

        int firstScore = ranking[0];

        ranking[2] = 125;

        int arrayLength = ranking.Length;

        int pos = 5;

        if (pos >= 0 && pos < arrayLength)
        {
            int someNumber = ranking[pos];
        }

        List<string> partyMembers = new List<string>()
            {"Aragorn", "Gimli", "Legolas"};

        string firsMember = partyMembers[0];
        
        Debug.LogFormat("Nuestra comunidad tiene {0} miembros",
            partyMembers.Count);
        
        partyMembers.Add("Gandlaf");
        partyMembers.Add("Frodo");
        
        partyMembers.Insert(2, "Sam");

        partyMembers.Remove("Sam");
        
        partyMembers.RemoveAt(3);
        
        //Dictionaries
        //Dictionary<keyType, valueType> varName = new Dictionary<keyTape, valueType>();
        /*Dictionary<keyType, valueType> varName = new Dictionary<keyTape, valueType>()
        { {clave1, valor1}, {clave2, valor2}, ...}; */
        Dictionary<string, int> inventory = new Dictionary<string, int>()
        {
            {"Poción", 8},
            {"Antídoto", 3},
            {"Espada", 2},
            {"Hacha", 1},
            {"Flecha", 28}
        };
        
        Debug.LogFormat("Mi inventario tiene {0} elementos", inventory.Count);

        int numberOfPotions = inventory["Poción"];
        inventory["Poción"] = 18;
        
        inventory.Add("Vendas", 3);

        inventory["Cuchillo"] = 7;//Añade la clave "Cuchillo", ya que no existía

        if (inventory.ContainsKey("Cuerda"))
        {
            inventory["Cuerda"]--;
            if (inventory["Cuerda"] == 0)
                inventory.Remove("Cuerda");
        }
        else
        {
            inventory.Add("Cuerda", 10);
        }

        Debug.LogFormat("Mi inventario tiene {0} elementos", inventory.Count);

        //Recorrer un diccionario con foreach
        foreach (KeyValuePair<string, int> element in inventory)
        {
            Debug.LogFormat("Elemento: {0}, Cantidad: {1}", element.Key, element.Value);
        }


        Character hero = new Character();
        hero.PrintCharacterStats();

        Character heroine = new Character("Lara");
        heroine.PrintCharacterStats();

    }
    
    

    

}
