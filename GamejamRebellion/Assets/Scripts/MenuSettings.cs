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
    [SerializeField]
    private Toggle toggleDaltonisme;
    [SerializeField]
    private Dropdown daltonismeDrop;
    [SerializeField]
    private Text daltonismeLabel;

    public AudioMixer mainMixer;

    public TextMeshProUGUI musicText;
    public TextMeshProUGUI effectsText;

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

    public void toggleChange() {
        Debug.Log("toggle change trouvee : " + toggleDaltonisme.isOn);
        settings.toggleDaltonisme = toggleDaltonisme.isOn;
    }

    public void typeDaltonismeChanged() {
        Debug.Log("type de dalto : " + daltonismeLabel.text);
        string name = daltonismeLabel.text;
        settings.daltonisme = name;
        settings.daltonismeId = getDaltonismeId(name);
    }

    int getDaltonismeId(string name) {
        if (string.IsNullOrEmpty(name) == true) { return -1; }
        List<Dropdown.OptionData> list = daltonismeDrop.options;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].text.Equals(name)) { return i; }
        }
        return -1;
    }

    public void afficher() {
        if (settings == null)
            settings = FindObjectOfType<Settings>();

        Debug.Log("volume musique trouvee : " + settings.volumeMusique);
        sliderMusique.value = settings.volumeMusique;

        Debug.Log("volume effects trouvee : " + settings.volumeEffects);
        sliderEffets.value = settings.volumeEffects;

        toggleDaltonisme.isOn = settings.toggleDaltonisme;
        Debug.Log("load toggle : " + settings.toggleDaltonisme);
        daltonismeDrop.value = settings.daltonismeId;
    }
}
