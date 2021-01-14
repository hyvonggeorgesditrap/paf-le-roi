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
        mainMixer.SetFloat("effectsVolume", value);
        int textValue = (int)(value*100/80 + 100);
        effectsText.text = textValue.ToString() + "%";
    }

    public void SetMusicVolume(float value)
    {
        mainMixer.SetFloat("musicVolume", value);
        int textValue = (int)(value * 100 / 80 + 100);
        musicText.text = textValue.ToString() + "%";
    }

    public void SetColorblindness(int index)
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
        
    }
}
