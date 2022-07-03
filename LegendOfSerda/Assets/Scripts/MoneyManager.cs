using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Gestiona la cantidad de monedas que ha recogido el player

public class MoneyManager : MonoBehaviour
{
    //Cantidad de monedas que tiene el player
    public int currentMoney;
    //Texto de la UI donde reflejar las monedas que tiene el player
    public Text moneyText;


    /// <summary>
    /// Añade al total de monedas recogidas la cantidad indicada
    /// </summary>
    /// <param name="moneyCollected"></param>
    public void AddMoney(int moneyCollected)
    {
        currentMoney += moneyCollected;

        moneyText.text = currentMoney.ToString("00000");

        //Actualiza la cantidad en las player prefs
        PlayerPrefs.SetInt("MONEY", currentMoney);
    }

    private void Start()
    {
        //Si había monedas acumuladas de una sesión previa, se cargan
        if(PlayerPrefs.HasKey("MONEY"))
        {
            currentMoney = PlayerPrefs.GetInt("MONEY");
        }
        else//Si no había monedas de sesiones previas
        {
            currentMoney = 0;
            PlayerPrefs.SetInt("MONEY", currentMoney);//Se crea por primera vez el valor
        }

        //Actualiza la información en la UI
        moneyText.text = currentMoney.ToString("00000");
    }
}
