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
}
