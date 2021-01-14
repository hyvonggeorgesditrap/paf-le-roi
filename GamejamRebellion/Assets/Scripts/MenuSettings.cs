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

    public TextMeshProUGUI musicText;
    public TextMeshProUGUI effectsText;

    [SerializeField]
    private AudioSource sourceEffets;
    [SerializeField]
    private AudioClip sonTirManque;
    private float EffectCooldown = (float)0.5;
    private float NextEffect = 0;

    public void SetEffectsVolume(float value) {
        settings.SetEffectsVolume(value);
        effectsText.text = value.ToString() + "%";

        //Jouer un son a titre d'indicateur
        if (Time.time > NextEffect) {
            NextEffect = Time.time + EffectCooldown;
            sourceEffets.PlayOneShot(sonTirManque);
        }
    }

    public void SetMusicVolume(float value) {
        settings.SetMusicVolume(value);
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
