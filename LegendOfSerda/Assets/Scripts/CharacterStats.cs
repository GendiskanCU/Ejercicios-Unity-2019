using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla las estadísticas del player o cualquier otro character
public class CharacterStats : MonoBehaviour
{
    //Nivel del character
    public int level;

    //Experiencia acumulada
    public int exp;

    //Experiencia necesaria para subir de nivel
    public int[] expToLevelUp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    /// <summary>
    /// Aumenta la experiencia en la cantidad indicada
    /// </summary>
    /// <param name="newExp"></param>
    public void AddExperience(int newExp)
    {
        exp += newExp;

        //Si se ha alcanzado ya el último nivel, no podrá subir más
        if (level >= expToLevelUp.Length - 1)
        {
            return;
        }

        //Cuando haya alcanzado el nivel de experiencia necesaria, subirá de nivel
        if (exp >= expToLevelUp[level])
        {
            level++;
        }
    }
}
