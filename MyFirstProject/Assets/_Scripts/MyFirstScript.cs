using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyFirstScript : MonoBehaviour
{
    public Transform cameraTransform;
    public Light directionalLight;
    public Transform lightTransform;

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

        Character hero2 = new Character();
        hero2.PrintCharacterStats();

        hero2 = hero;
        hero2.name = "Other hero name";

        hero.PrintCharacterStats();
        hero2.PrintCharacterStats();

        Character heroine = new Character("Lara");
        heroine.PrintCharacterStats();       

        Weapon sword = new Weapon("Espada roma", 5);

        Weapon sword2 = sword;

        sword.PrintWeaponStats();
        sword2.PrintWeaponStats();

        sword2.name = "Excalibur";
        sword2.damage = 50;

        sword.PrintWeaponStats();
        sword2.PrintWeaponStats();


        Paladin p = new Paladin();       


        Paladin p2 = new Paladin("Frody", sword);        
        

        Archer a = new Archer("Legolin", new Weapon("Arco de los bosques", 7) );        
        

        Character m = new Magician("Gangald");
        

        List<Character> party = new List<Character>();
        party.Add(p2);
        party.Add(a);
        party.Add(m);

        foreach(Character c in party)
        {
            c.PrintCharacterStats();
        }

        //El script está en la cámara
        //Podemos consultar otros componentes de la cámara
        Transform theTransform = GetComponent<Transform>();
        Debug.Log(theTransform.position);
        Debug.Log(theTransform.rotation);

        Camera cam = GetComponent<Camera>();
        Debug.Log(cam.fieldOfView);

        //Acceso a otros objetos de la escena
        GameObject myLight = GameObject.Find("Directional Light");
        Transform t = myLight.GetComponent<Transform>();
        Debug.Log("La luz está posicionada en: " + t.position);

    }   
}
