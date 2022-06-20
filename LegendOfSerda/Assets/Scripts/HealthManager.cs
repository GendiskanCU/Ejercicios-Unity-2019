using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controlará la vida del player
public class HealthManager : MonoBehaviour
{
    public int maxHealth;//Vida máxima
    [SerializeField] private int currentHealth;//Vida actual

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;//Al iniciar, el player comienza con la vida máxima inicial
    }
    

    /// <summary>
    /// Reduce la vida del personaje. Después comprueba si se ha quedado sin vida
    /// en cuyo caso activa la muerte del mismo
    /// </summary>
    /// <param name="damage">cantidad de vida a reducir</param>
    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Actualiza la vida máxima e iguala la vida actual a esa nueva vida máxima
    /// </summary>
    /// <param name="newMaxHealth">nueva cantidad de vida máxima</param>
    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }

}
