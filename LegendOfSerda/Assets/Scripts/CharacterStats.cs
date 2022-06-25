using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla las estadísticas del player o cualquier otro character
public class CharacterStats : MonoBehaviour
{

    public const int MAX_STAT_VALUE = 100;//Estado máximo de algunas estadísticas

    //Nivel del character
    public int level;

    //Experiencia acumulada
    public int exp;

    //Experiencia necesaria para subir de nivel
    public int[] expToLevelUp;

    //Cantidad de vida que tendrá el player en cada nivel de habilidades
    public int[] hpLevels;

    //Cantidad de fuerza que se suma al daño del arma en cada nivel de habilidades
    public int[] strengLevels;

    //Cantidad de defensa que divide el daño de los enemigos en cada nivel de habilidades
    public int[] defenseLevels;

    //Cantidad de velocidad de ataque del player en cada nivel de habilidades
    public int[] speedLevels;

    //Cantidad de suerte del player(probabilidad de esquivar ataques) en cada nivel de habilidades
    public int[] luckLevels;

    //Probabilidad de fallar ataques en cada nivel de habilidades
    public int[] accuracyLevels;

    private UIManager uiManager;//Manager del UI (Canvas)

    private HealthManager healthManager;//Manager de la vida del player

    private PlayerController playerController;//Controlador del jugador



    private void Start()
    {
        uiManager = GameObject.Find("GameCanvas").GetComponent<UIManager>();

        healthManager = GetComponent<HealthManager>();

        playerController = GetComponent<PlayerController>();

        //Inicia la información en la UI
        uiManager.UpdateLevel(level, exp, expToLevelUp[level]);
        uiManager.UpdateBarExperience(exp);
    }

    

    /// <summary>
    /// Aumenta la experiencia en la cantidad indicada
    /// </summary>
    /// <param name="newExp"></param>
    public void AddExperience(int newExp)
    {
        //Si se ha alcanzado ya el último nivel, no podrá subir más
        if (level >= expToLevelUp.Length - 1)
        {
            return;
        }

        //Actualiza la experiencia y actualiza la UI
        exp += newExp;
        uiManager.UpdateBarExperience(exp);

        

        //Si se ha alcanzado el nivel de experiencia necesaria, subirá de nivel
        if (exp >= expToLevelUp[level])
        {
            level++;
            //Actualiza la información en la UI
            uiManager.UpdateLevel(level, exp, expToLevelUp[level]);

            //Modifica las estadísticas del player en función del nuevo nivel
            healthManager.UpdateMaxHealth(hpLevels[level]);//Vida máxima
            playerController.attackTime -= speedLevels[level] / MAX_STAT_VALUE;//Velocidad del ataque
        }
    }
}
