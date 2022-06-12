using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]//Textos que se mostrarán en la UI
    private string labelText =
        "¡Recolecta todos los ítems y consigue la victoria!";

    [SerializeField] private int maxItems = 3;//Número máximo de ítems
    
    private int playerHP = 3;//Vida del player

    private bool showWinScreen;//Para saber cuándo se debe mostrar la pantalla de victoria

    public int HP//Propiedad para acceder a la vida del player
    {
        get { return playerHP; }
        set
        {
            if (value >= 0 && value <= 3)
            {
                playerHP = value;
            }
            Debug.LogFormat("Vidas: {0}", playerHP);
        }

    }

    private int itemsCollected = 0;//Items recogidos por el jugador
    public int Items//Propiedad para acceder a los items recogidos
    {
        get { return itemsCollected;  }
        set 
        {
            if (value >= 0)
            {
                itemsCollected = value;
            }
            Debug.LogFormat("Items: {0}", itemsCollected);
            if( itemsCollected >= maxItems)//Comprueba si se han recogido todos los ítems
            {
                labelText = "¡Has encontrado todos los ítems!!!!";
                Time.timeScale = 0f;
                showWinScreen = true;
            }
            else
            {
                labelText = "Ítem encontrado. Te faltan: " + (maxItems - itemsCollected) +
                    " ítems.";
            }
        }
    }


    //Uso de la clase GUI para mostrar una UI 
    private void OnGUI()
    {
        GUI.Box(new Rect(25, 25, 180, 25), "Vida: " + playerHP.ToString("00")); //Muestra una caja con el número de vidas

        GUI.Box(new Rect(25, 65, 180, 25), "Ítems recogidos: " + itemsCollected.ToString("00"));//Muestra una caja con el número de ítems recogidos

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50), labelText);//Muestra un texto flotante con información

        if(showWinScreen)//Cuando el jugador haya vencido
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200), "¡HAS GANADO!!!!"))//Muestra el botón de victoria y si se pulsa en él
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Recarga la escena actual
            }
        }
    }

}
