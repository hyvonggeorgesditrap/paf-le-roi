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

    public bool toggleDaltonisme;
    public string daltonisme = "Protanopia";
    public int daltonismeId = 0;
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
