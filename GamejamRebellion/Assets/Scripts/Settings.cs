using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    public AudioMixer mainMixer;

    public TextMeshProUGUI musicText;
    public TextMeshProUGUI effectsText;


    public void SetEffectsVolume(float value)
    {
        float linearTodB = 20.0f * Mathf.Log10(value / 100);
        if (value != 0)
            mainMixer.SetFloat("effectsVolume", linearTodB);
        else
            mainMixer.SetFloat("effectsVolume", -80.0f);

        //int textValue = (int)(value * 100 / 80 + 100);
        effectsText.text = value.ToString() + "%";
    }

    public void SetMusicVolume(float value)
    {
        float linearTodB = 20.0f * Mathf.Log10(value / 100);
        if (value != 0)
            mainMixer.SetFloat("musicVolume", linearTodB);
        else
            mainMixer.SetFloat("musicVolume", -80.0f);

        //int textValue = (int)(value * 100 / 80 + 100);
        musicText.text = value.ToString() + "%";
    }

    /*public void SetColorblindness(int index)
    {
        switch(index)
        {
            case 0:
                Debug.Log("Protanopia");
                break;
            case 1:
                Debug.Log("Deuteranopia");
                break;
            case 2:
                Debug.Log("Trinatopia");
                break;
            default:
                break;
        }
        
    }*/
}
