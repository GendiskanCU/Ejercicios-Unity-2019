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

    public virtual void PrintCharacterStats()
    {
        Debug.LogFormat("Héroe: {0} - Experiencia: {1}", name, exp);
    }

    private void Reset()
    {
        name = "Hero name";
        exp = 0;
    }
}



public class Paladin : Character
{

    public Weapon weapon;
    public Paladin() : base()
    {

    }

    public Paladin(string name, Weapon weapon) : base(name)
    {
        this.weapon = weapon;
    }

    public override void PrintCharacterStats()
    {
        Debug.LogFormat("Hola, soy el paladín {0}, y llevo un/a: {1}",
            name, weapon.name);
    }
}



public class Archer : Character
{
    public Weapon arch;

    public Archer() : base ()
    {

    }

    public Archer(string name, Weapon arch) : base(name)
    {
        this.arch = arch;
    }

    public override void PrintCharacterStats()
    {
        base.PrintCharacterStats();
        Debug.LogFormat("Llevo un/a: {0}", arch.name);
    }
}


public class Magician : Character
{
    public Weapon staff, knife;
    public Magician() : base()
    {

    }

    public Magician(string name) : base (name)
    {
        this.staff = new Weapon("Vara de sauce", 15);
        this.knife = new Weapon("Daga azul", 35);
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