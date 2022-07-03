using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controla el volumen global del audio



public class AudioVolumeManager : MonoBehaviour
{
    private AudioVolumeController [] audios;//Lista de todos los audios que haya en la escena

    [Range(0, 1)]
    public float maxVolumeLevel;//Nivel máximo de volumen global

    [Range(0, 1)]
    public float currentVolumeLevel;//Nivel actual de volumen global

    private void Start()
    {
        //Captura todos los audios que haya en la escena
        audios = FindObjectsOfType<AudioVolumeController>();

        ChangeGlobalAudioVolume();
    }


    /// <summary>
    /// Modifica el volumen de todos los audios de la escena estableciendo el definido
    /// como valor actual a nivel global
    /// </summary>
    public void ChangeGlobalAudioVolume()
    {
        //Asegura que no se pueda sobrepasar el nivel máximo de volumen definido
        if (currentVolumeLevel >= maxVolumeLevel)
            currentVolumeLevel = maxVolumeLevel;

        foreach(AudioVolumeController ac in audios)
        {
            ac.SetAudioLevel(currentVolumeLevel);
        }
    }


    /// <summary>
    /// Modifica el volumen actual por el especificado utilizando el slider de la UI
    /// </summary>
    /// <param name="newVolume"></param>
    public void VolumeChanged(Slider audioSlider)
    {
        currentVolumeLevel = audioSlider.value;
        ChangeGlobalAudioVolume();
    }
}
