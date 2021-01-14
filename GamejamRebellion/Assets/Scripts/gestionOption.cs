using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionOption : MonoBehaviour
{

    public bool isColourBlind;
    public string typeColourBlindness;
    public GameObject profilDeuteranopia;
    public GameObject profilProteranopia;
    public GameObject profilTriteranopia;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void recupererDatas()
    {
        
    }

}
