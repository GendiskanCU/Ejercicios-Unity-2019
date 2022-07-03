using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Para identificar cada pista de música que pueda reproducirse a lo largo del juego

public class PlayAudioTrack : MonoBehaviour
{

    private MusicManager musicManager;//Gestor de música del juego

    public int newTrackID;//Identificador de esta pista de música

    public bool playOnStart;//Para establecer si esta pista debe reproducirse, o no, al comenzar la escena

    // Start is called before the first frame update
    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();//Captura el gestor de música

        if(playOnStart)//Si debe reproducirse al cargar la escena
        {
            musicManager.PlayNewTrackMusic(newTrackID);
        }
    }

    /// <summary>
    /// Indicará que debe cambiarse a la pista de música actual si el jugador entra en una zona determinada
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            musicManager.PlayNewTrackMusic(newTrackID);
            //Destruye el objeto para evitar que el método ontriggerenter se ejecute más veces y la música se reinicie una y otra vez
            gameObject.SetActive(false);
        }
    }

}
