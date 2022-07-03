using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controla el volumen de cada sonido en particular

[RequireComponent(typeof(AudioSource))]

public class AudioVolumeController : MonoBehaviour
{
    private AudioSource _audioSource;

    private float currentAudioLevel;//Nivel de sonido actual de este sonido

    [Range(0, 1)]
    public float defaultAudioLevel;//Nivel de sonido inicial para este sonido

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Modifica el nivel de volumen de este sonido
    /// </summary>
    /// <param name="newAudioLevel"></param>
    public void SetAudioLevel(float newAudioLevel)
    {
        //Asegura que el audiosource esté cargado antes de modificar el volumen
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }

        //El volumen se modificará multiplicando los dos valores, siendo recomendable utilizar en
        //defaultAudio un valor entre 0 y 1 según lo fuerte que queramos que sea cada sonido con
        //respecto a los demás, y como newAudio un valor float entre 0 y 1 para cambiar el valor porcentualmente       
        currentAudioLevel = defaultAudioLevel * newAudioLevel;

        _audioSource.volume = currentAudioLevel;
    }
}
