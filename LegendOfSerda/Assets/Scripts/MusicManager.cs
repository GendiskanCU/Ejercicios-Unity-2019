using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona la música que se reproduce en cada momento del juego
public class MusicManager : MonoBehaviour
{

    public AudioSource[] audioTracks;//Pistas de música existentes

    public int currentTrack;//Pista reproduciéndose actualmente

    public bool audioCanBePlayer = true;//Para controlar si en algún momento no debe reproducirse ninguna música

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(audioCanBePlayer)//Si debe reproducirse música
        {
            if(!audioTracks[currentTrack].isPlaying)//Y no se está reproduciendo la pista actual
            {
                audioTracks[currentTrack].Play();//Comienza a reproducirse
            }
        }
        else//Si no debe reproducir, se detiene
        {
            audioTracks[currentTrack].Stop();
        }
    }


    /// <summary>
    /// Cambia la pista de música activa
    /// </summary>
    /// <param name="newTrack"></param>
    public void PlayNewTrackMusic(int newTrack)
    {
        audioTracks[currentTrack].Stop();//Detiene la que se esté reproduciendo ahora
        currentTrack = newTrack;
        audioTracks[currentTrack].Play();//Reproduce la nueva pista
    }
}
