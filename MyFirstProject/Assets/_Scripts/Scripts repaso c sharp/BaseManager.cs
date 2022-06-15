using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ejemplo de una case abstracta


public abstract class BaseManager
{
    protected string _state;

    public abstract string State { get; set; }

    public abstract void Initialize();
}
