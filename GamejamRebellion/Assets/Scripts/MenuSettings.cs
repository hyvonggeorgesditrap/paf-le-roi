using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MenuSettings : MonoBehaviour
{
    [SerializeField]
    private Settings settings = null;
    [SerializeField]
    private Slider sliderMusique;
    [SerializeField]
    private Slider sliderEffets;

    public AudioMixer mainMixer;

    public TextMeshProUGUI musicText;
    public TextMeshProUGUI effectsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetEffectsVolume(float value) {
        float linearTodB = 20.0f * Mathf.Log10(value / 100);
        if (value != 0)
           mainMixer.SetFloat("effectsVolume", linearTodB);
        else
           mainMixer.SetFloat("effectsVolume", -80.0f);

        //int textValue = (int)(value * 100 / 80 + 100);
        settings.volumeEffects = value;
        effectsText.text = value.ToString() + "%";
    }

    public void SetMusicVolume(float value) {
        float linearTodB = 20.0f * Mathf.Log10(value / 100);
        if (value != 0)
            mainMixer.SetFloat("musicVolume", linearTodB);
        else
            mainMixer.SetFloat("musicVolume", -80.0f);

        //int textValue = (int)(value * 100 / 80 + 100);
        settings.volumeMusique = value;
        musicText.text = value.ToString() + "%";
    }

    public void afficher() {
        if (settings == null)
            settings = FindObjectOfType<Settings>();

        Debug.Log("volume musique trouvee : " + settings.volumeMusique);
        sliderMusique.value = settings.volumeMusique;

        Debug.Log("volume effects trouvee : " + settings.volumeEffects);
        sliderEffets.value = settings.volumeEffects;
    }
}
