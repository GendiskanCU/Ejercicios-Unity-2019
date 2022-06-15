using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseManager //Hereda de una clase abstracta creada por nosotros
{

    //Implementación de la clase abstracta BaseManager
    public override string State
    {
        get
        {
            return _state;
        }

        set
        {
            _state = value;
        }

    }
   
    public override void Initialize()
    {
        //Podemos acceder a la variable _state, pues era "protected" en la clase madre
        _state = "Batalla inicializada";
        Debug.Log(_state);
    }
    //Fin implementación de la clase abstracta BaseManager



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
