using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundScript : MonoBehaviour
{

    // Audio clip for snow
    public AudioClip SnowSound;
    // Audio clip for normal
    public AudioClip NormalSound;

    enum GroundType
    {
        Snow,
        Desert
    }

    [SerializeField] private GroundType m_groundType = GroundType.Desert; // Default Ground Type lvl 1


    // On Event of animator FootPrint
    public void FootPrint()
    {
        if (m_groundType == GroundType.Snow)
        {
            // Play Snow Sound
            AudioSource.PlayClipAtPoint(SnowSound, transform.position);
        }
        else
        {
            // Play Normal Sound
            AudioSource.PlayClipAtPoint(NormalSound, transform.position);
        }
    }
}
