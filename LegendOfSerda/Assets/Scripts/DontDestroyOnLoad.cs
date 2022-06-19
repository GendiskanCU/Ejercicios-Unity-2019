using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerController.playerCreated)//Si aún no se ha creado ninguna instancia del jugador
            DontDestroyOnLoad(this.transform.gameObject);//Este objeto será el que se mantenga entre escenas
        else//Si ya se había creado algna instancia
        {
            Destroy(gameObject);//Se destruye el script actual
        }
    }

    
}
