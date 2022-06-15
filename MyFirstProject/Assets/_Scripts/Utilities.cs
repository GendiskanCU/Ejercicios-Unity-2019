using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities
{
    public static int playerDeaths = 0;//Muertes del jugador


    /// <summary>
    /// Reinicia el nivel actual
    /// </summary>
    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

        Debug.Log("Muertes del jugador: " + playerDeaths);
        string message = UpdateDeathCount(ref playerDeaths);
        Debug.Log("Muertes totales: " + playerDeaths);
    }

    /// <summary>
    /// Carga el nivel indicado
    /// </summary>
    /// <param name="buildIndex">Índice del nivel a cargar</param>
    public static void RestartLevel(int buildIndex)
    {
        if(buildIndex < 0)
        {
            throw new System.ArgumentException("El índice de la escena no puede ser negativo");
        }

        if(buildIndex >= SceneManager.sceneCount)
        {
            throw new System.ArgumentException("El índice de la escena no existe");
        }

        SceneManager.LoadScene(buildIndex);
        Time.timeScale = 1f;
    }


    public static string UpdateDeathCount(ref int countData)
    {
        countData++;
        return "Has jugado ya " + countData + " veces";
    }
    
}
