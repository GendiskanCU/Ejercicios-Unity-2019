using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//CLASE GENÉRICA PARA ALMACENAR EL INVENTARIO DEL JUGADOR

public class Inventory<T>
{
    private T _item;
    public T Item
    {
        get { return _item;  }

        set { _item = value; }
    }


    public Inventory()//Constructor
    {
        Debug.Log("Inventario creado");
    }

    public void RecibeObjeto(T objetoRecibido)
    {
        Debug.Log("He recibido un objeto");
    }

    public void SetItem(T item)
    {
        _item = item;
    }
}
