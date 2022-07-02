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

    public GameObject panelInventory;//Panel que contiene el inventario del player
    public GameObject panelMenu;//Panel que contiene los botones para filtrar el inventario

    public Button inventoryButton;//Prefab de botones del inventario

    public Image playerAvatar;//Pequeño icono que aparecerá junto a la barra de vida

    public Text inventoryTex;//Texto bajo el inventario que mostrará una descripción de cada elemento

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
    /// Actualiza el icono junto a la barra de vida mostrando el arma equipada
    /// </summary>
    public void UpdatePlayerAvatar(GameObject equipedWeapon)
    {
        playerAvatar.sprite = equipedWeapon.GetComponent<SpriteRenderer>().sprite;
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

    /// <summary>
    /// Muestra/oculta el inventario del player
    /// </summary>
    public void ToggleInventory()
    {
        panelInventory.SetActive(!panelInventory.activeSelf);
        panelMenu.SetActive(!panelMenu.activeInHierarchy);//activeInHierarchy y activeSelf son similares

        //Cuando esté activo se actualizará con el posible nuevo contenido

        //Para ello primero se vacía el contenido antiguo
        foreach (Transform t in panelInventory.transform)
            Destroy(t.gameObject);

        //Y después se rellena con el contenido actual
        if (panelInventory.activeSelf)
            FillInventory();

        //El texto del campo de la descripción se deja en blanco
        inventoryTex.text = "";
    }


    /// <summary>
    /// Rellena el panel de inventario de la UI con las armas, items de misión que tenga el player
    /// </summary>
    public void FillInventory()
    {
        //Obtiene la lista de armas del inventario del player

        WeaponManager managerWeapons = FindObjectOfType<WeaponManager>();

        List<GameObject> weaponsInventory =
            managerWeapons.GetAllWeapons();

        int i = 0;
        //Añade como hijos al panel del inventario un botón por cada arma
        foreach(GameObject weapon in weaponsInventory)
        {
            AddItemToInventory(weapon, InventoryButton.ItemType.WEAPON, i);
            i++;
        }


        //Obtiene la lista de items de misión que tenga el player

        ItemsManager itemsManager = FindObjectOfType<ItemsManager>();

        List<GameObject> questItems = itemsManager.GetQuestItems();

        int j = 0;
        //Añade como hijos al panel del inventario un botón por cada item de misión
        foreach(GameObject it in questItems)
        {
            AddItemToInventory(it, InventoryButton.ItemType.SPECIAL_ITEMS, j);
            j++;
        }
    }


    /// <summary>
    /// Añade como hijo al panel del inventario un botón correspondiente al item recibido
    /// </summary>
    /// <param name="newItem"></param>
    /// <param name="typeItem"></param>
    /// <param name="position"></param>
    private void AddItemToInventory(GameObject newItem, InventoryButton.ItemType typeItem, int position)
    {
        Button newButton = Instantiate(inventoryButton, panelInventory.transform);

        //A cada botón se le asigna el método que se deberá ejecutar al pulsarlo
        //Como el hacer click es un evento, hay que utilizar un delegado:

        newButton.GetComponent<InventoryButton>().itemId = position;
        newButton.GetComponent<InventoryButton>().type = typeItem;
        newButton.onClick.AddListener(() => newButton.GetComponent<InventoryButton>().ActivateButton());        

        //Y se le asigna la imagen que corresponda a cada arma
        newButton.image.sprite = newItem.GetComponent<SpriteRenderer>().sprite;
    }


    /// <summary>
    /// Filtra el inventario para mostrar solo los objetos del tipo especificado
    /// </summary>
    /// <param name="type"></param>
    public void ShowOnly(int type)
    {
        //Recorre los hijos del panel de inventario
        //Y activa solo los que sean del tipo especificado como parámetro
        foreach(Transform t in panelInventory.transform)
        {
            t.gameObject.SetActive((int)t.gameObject.GetComponent<InventoryButton>().type == type);
        }
    }


    /// <summary>
    /// Muestra todos los objetos del inventario
    /// </summary>
    public void ShowAll()
    {
        //Recorre los hijos del panel de inventario y los activa
        foreach (Transform t in panelInventory.transform)
        {
            t.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        //Al pulsar la tecla I (aunque también se puede hacer pulsando el botón de la UI)
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();//Muestra/oculta el inventario
        }
    }

    private void Start()
    {
        //Al inicio los paneles del inventario estarán desactivados
        panelInventory.SetActive(false);
        panelMenu.SetActive(false);
    }
}
