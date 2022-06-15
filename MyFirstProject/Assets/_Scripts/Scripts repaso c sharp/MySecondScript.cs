using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomExtensions;//Usamos el namespace creado en el script CustomExtensions

public class MySecondScript : MonoBehaviour
{
    //Constantes: hay que darles valor al definirlas
    public const float PI = 3.14159265f;

    //Variables de solo lectura: no es necesario darles valor al definirlas
    //Se les da valor en el constructor de la clase (no es posible en otro método)
    public readonly int numberOfEnemies;
    MySecondScript()
    {
        numberOfEnemies = 5;
    }


    //Sobrecarga de métodos
    public bool AttackEnemy(int damage)
    {
        return true;
    }

    public bool AttackEnemy(string player)
    {
        return true;
    }

    public bool AttackEnemy(float damage)
    {
        return true;
    }

    public bool AttackEnemy(float damage, string player)
    {
        return true;
    }

    public void AttackEnemy()
    {

    }

    public float AttackEnemy(bool h)
    {
        return 5.0f;
    }

       

    // Start is called before the first frame update
    void Start()
    {
        AttackEnemy();
        bool b = AttackEnemy(5);
        float f = AttackEnemy(true);

        string mensajeInicial = "La partida ha comenzado";
        mensajeInicial.MiPropioDebug();//Usamos la extensión de la clase string que hemos definido en CustomExtensions

        //Uso de la clase genérica creada en Inventory
        Inventory<string> inventory = new Inventory<string>();
        inventory.SetItem("Armadura");
    }


    //DELEGADOS. SINTAXIS:
    //public delegate returnType NameOfTheDelegate(int param1, string param2, ...); En la clase que se crea en delegado
    //public DelegateName someDelegate = MyMethod; En la clase que va a utilizar el delegado
    //public void MyMethod(...){}

    //EVENTOS. SINTAXIS:
    //public event EventDelegate eventInstance;
    //public delegate void EventDelegate(int param1, string param2,...)

    //Para suscribirse al evento en otra clase:
    //someClass.eventInstance += EventHandler;//Nos suscribimos al evento, con el método asociado que habrá que declarar:
    //Public void EventHandler(int param1, string param2,...)
    //Para desuscribirse al evento posteriormente se haría:
    //someClass.eventInstance -= EventHandler;


    //EXCEPCIONES. Ejemplo:
    public void ValidateUserEmail(string email)
    {
        if(!email.Contains("@"))
        {
            throw new System.ArgumentException("Email invalid");
        }
    }

}
