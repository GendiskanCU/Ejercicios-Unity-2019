using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;//Para poder utilizar la clase stringbuilder con la que crear las cadenas de texto

//Gestionará la información que aparece en la UI (Canvas)
public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;//Barra de vida del player
    public TextMeshProUGUI playerHealthText;//Info con la vida del player  

    public TextMeshProUGUI playerLevelText;//Info con el nivel del player
    public Slider playerExpBar;//Barra de experiencia del player    

       

    /// <summary>
    /// Actualiza los valores de la barra de vida
    /// </summary>
    public void UpdateBarHealth(int currentHealth, int maxHealth)
    {
        //Actualiza la barra de vida con el valor máximo y actual recibidos
        playerHealthBar.maxValue = maxHealth;
        playerHealthBar.value = currentHealth;

        //Actualiza el texto que aparece en la barra de vida
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("HP: ").Append(currentHealth).
            Append(" / ").Append(maxHealth);

        playerHealthText.text = stringBuilder.ToString();
    }

    /// <summary>
    /// Actualiza el valor de la barra de experiencia en la UI
    /// </summary>
    public void UpdateBarExperience(int experience)
    {
        playerExpBar.value = experience;
    }


    /// <summary>
    /// Actualiza el nivel del player en la UI
    /// y el valor mínimo/máximo en la barra de experiencia para que muestre
    /// la cantidad que se debe lograr para subir al siguiente nivel
    /// </summary>
    public void UpdateLevel(int level, int newMinExp, int newMaxExp)
    {
        StringBuilder stringBuilder = new StringBuilder().Append("Level ").
            Append(level);
        playerLevelText.text = stringBuilder.ToString();

        playerExpBar.minValue = newMinExp;
        playerExpBar.maxValue = newMaxExp;
    }
}
