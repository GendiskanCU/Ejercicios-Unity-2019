using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Para identificar cada pista de música que pueda reproducirse a lo largo del juego

public class PlayAudioTrack : MonoBehaviour
{

    private MusicManager musicManager;//Gestor de música del juego

    public int newTrackID;//Identificador de esta pista de música

    public bool playOnStart;//Para establecer si esta pista debe reproducirse, o no, al comenzar la escena

    public int previousTrackID;//Identificador de la pista de música que sonaba anteriormente a ésta

    private bool isPlaying;//Para controlar si esta pista de música se está reproduciendo actualmente

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
    /// Indicará que debe cambiarse a la pista de música actual o volver a la que sonaba antes
    /// cuando el jugador entra en una zona determinada
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            if(isPlaying)//Si esta pista de música se está reproduciendo actualmente
            {
                musicManager.PlayNewTrackMusic(previousTrackID);//Al pasar por el trigger se volverá a la anterior pista
                isPlaying = false;
            }
            else//Si esta pista no se está reproduciendo actualmente
            {
                musicManager.PlayNewTrackMusic(newTrackID);//Al pasar por el trigger se comenzará a reproducir
                isPlaying = true;
            }           
        }
    }

}
