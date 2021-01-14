using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    //Settings par default (au lancement)

    public float volumeMusique = 100;
    public float volumeEffects = 100;

    public AudioMixer mainMixer;

    public bool toggleDaltonisme;
    public string daltonisme = "Protanopia";
    public int daltonismeId = 0;

    private void Start() {
        SetEffectsVolume(volumeEffects); 
        SetMusicVolume(volumeMusique);
    }

    public void SetEffectsVolume(float value) {
        volumeEffects = value;
        float linearTodB = 20.0f * Mathf.Log10(value / 100);
        if (value != 0)
            mainMixer.SetFloat("effectsVolume", linearTodB);
        else
            mainMixer.SetFloat("effectsVolume", -80.0f);
    }

    public void SetMusicVolume(float value) {
        volumeMusique = value;
        float linearTodB = 20.0f * Mathf.Log10(value / 100);
        if (value != 0)
            mainMixer.SetFloat("musicVolume", linearTodB);
        else
            mainMixer.SetFloat("musicVolume", -80.0f);
    } 
}
