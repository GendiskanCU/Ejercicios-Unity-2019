using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public int exp = 0;

    public Character()
    {
        name = "Hero name";
    }

    public Character(string name)
    {
        this.name = name;
    }

    public Character(string name, int exp)
    {
        this.name = name;
        this.exp = exp;
    }

    public void PrintCharacterStats()
    {
        Debug.LogFormat("Héroe: {0} - Experiencia: {1}", name, exp);
    }

    private void Reset()
    {
        name = "Hero name";
        exp = 0;
    }
}


public struct Weapon
{
    public string name;
    public int damage;

    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    public void PrintWeaponStats()
    {
        Debug.Log("Arma: " + name + ". Daño: " + damage);
    }
}