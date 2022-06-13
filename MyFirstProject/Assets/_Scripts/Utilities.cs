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
    }
}
