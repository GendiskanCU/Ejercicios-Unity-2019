using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona los efectos de sonido desde código

public class SFXManager : MonoBehaviour
{
    //Los objetos vacíos que contienen los sonidos que se podrán reproducir(en el Inspector están como hijos del SFXManager)
    private List<GameObject> audios;

    //Para crear un singleton de esta clase
    private static SFXManager sharedInstance = null;
    public static SFXManager SharedInstance { get { return sharedInstance; } }


    private void Awake()
    {
        //Crea el Singleton
        if(sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
            //DontDestroyOnLoad(gameObject); //Aquí no es necesario, porque ya tiene asignado el script de DontDestroyOnLoad
        }
    }


    private void Start()
    {
        audios = new List<GameObject>();
        foreach(Transform child in transform)
        {
            audios.Add(child.gameObject);
        }
    }


    /// <summary>
    /// Devuelve el audiosource correspondiente al tipo de sonido buscado
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public AudioSource FindAudioSource(SFXType.SoundType type)
    {
        foreach(GameObject g in audios)
        {
            if (g.GetComponent<SFXType>().type == type)
                return g.GetComponent<AudioSource>();
        }

        return null;
    }

    /// <summary>
    /// Reproduce el tipo de sonido recibido como parámetro
    /// </summary>
    /// <param name="type"></param>
    public void PlaySFX(SFXType.SoundType type)
    {
        FindAudioSource(type).Play();
    }
}
