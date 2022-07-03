using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Para etiquetar cada sonido que gestione el SFXManager

public class SFXType : MonoBehaviour
{
    public enum SoundType
    { ATTACK, DIE, HIT, KNOCK, M_START, M_END }//Tipos de sonido que se pueden reproducir

    public SoundType type;
    
    
}
