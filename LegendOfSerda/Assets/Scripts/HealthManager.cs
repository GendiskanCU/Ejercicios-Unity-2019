using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controlará la vida del personaje
public class HealthManager : MonoBehaviour
{
    public int maxHealth;//Vida máxima
    [SerializeField] private int currentHealth;//Vida actual
    public int Health
    {
        get
        {
            return currentHealth;
        }        
    }


    public UIManager uiManager;//Manager del UI (Canvas)

    public bool flashActive;//Para controlar si el efecto de sufrir daño está activa
    public float flashLength;//Duración del efecto de sufrir daño
    public float flashCounter;//Contador para la duración del efecto de sufrir daño

    private SpriteRenderer _characterRenderer;//Sprite del personaje

    public int expWhenDefeated = 0;//Cantidad de experiencia que dará el character al ser derrotado

    //Para utilizar por los enemigos de las misiones de eliminar enemigos
    private QuestEnemy quest;
    private QuestManager questManager;

    // Start is called before the first frame update
    void Start()
    {
        _characterRenderer = GetComponent<SpriteRenderer>();

        //uiManager = GameObject.Find("GameCanvas").GetComponent<UIManager>();

        currentHealth = maxHealth;//Al iniciar, el player comienza con la vida máxima inicial

        //Actualiza la información de la barra de vida del player en la UI
        if (gameObject.tag == "Player")
            uiManager.UpdateBarHealth(currentHealth, maxHealth);

        quest = GetComponent<QuestEnemy>();
        questManager = FindObjectOfType<QuestManager>();
    }
    

    /// <summary>
    /// Reduce la vida del personaje. Después comprueba si se ha quedado sin vida
    /// en cuyo caso activa la muerte del mismo
    /// </summary>
    /// <param name="damage">cantidad de vida a reducir</param>
    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        //Cuando el que haya recibido el daño sera el player
        //Actualiza la información de la barra de vida del player en la UI
        if(gameObject.tag == "Player")
            uiManager.UpdateBarHealth(currentHealth, maxHealth);

        //Mostrará el efecto visual de recibir daño solo si el character tiene
        //un valor mayor de cero en esta variable, así podremos aplicar el efecto
        //solo al player o a cualquier otro character que queramos
        if(flashLength > 0)
        {
            flashActive = true;
            flashCounter = flashLength;//Reinicia el contador de flash
        }        

        //Si el personaje pierde toda la vida y aún sigue activo
        if (currentHealth <= 0 && gameObject.activeSelf)
        {            
            gameObject.SetActive(false);//Lo desactivamos
            //Cuando el que haya sido vencido sea un enemigo
            //Aplicará al player el aumento experiencia que otorga
            //E informará al manager de misiones de que se ha eliminado a este enemigo
            if (gameObject.tag == "Enemie")
            {
                GameObject.Find("Player").GetComponent<CharacterStats>().
                    AddExperience(expWhenDefeated);

                questManager.enemyKilled = quest;
            }                      
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
        //Actualiza la información de la barra de vida del player en la UI
        if (gameObject.tag == "Player")
            uiManager.UpdateBarHealth(currentHealth, maxHealth);
    }

    /// <summary>
    /// Muestra u oculta sprite del character en función del valor del parámetro recibido
    /// </summary>
    /// <param name="visible"></param>
    private void ToggleColor(bool visible)
    {
        //Cambiará solo el alpha del color del sprite
        _characterRenderer.color = new Color(_characterRenderer.color.r,
            _characterRenderer.color.g, _characterRenderer.color.b,
            visible ? 1f : 0f);
    }

    private void Update()
    {
        //Control del efecto de recibir daño:
        if(flashActive)//Cuando el efecto esté activado
        {
            GetComponent<BoxCollider2D>().enabled = false;//Desactiva el collider para que durante la duración del efecto no se pueda volver a recibir daño
            GetComponent<PlayerController>().canMove = false;//Evita que el player pueda moverse mientras dure el efecto
            flashCounter -= Time.deltaTime;//Va restando el contador

            //Divide el efecto en 4 fases en función del valor del contador
            if(flashCounter > flashLength * 0.66f)
            {
                ToggleColor(false);
            }
            else if(flashCounter > flashLength * 0.33f)
            {
                ToggleColor(true);
            }
            else if(flashCounter > 0)
            {
                ToggleColor(false);
            }
            else//Cuando el contador llegue a cero
            {
                ToggleColor(true);
                flashActive = false;
                GetComponent<BoxCollider2D>().enabled = true;//Vuelve a activar el collider para que sea posible recibir nuevo daño
                GetComponent<PlayerController>().canMove = true;//Permite que el player pueda moverse de nuevo
            }
        }
    }

}
