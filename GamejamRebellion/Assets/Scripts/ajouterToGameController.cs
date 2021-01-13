using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ajouterToGameController : MonoBehaviour
{
    public GameObject spawner;
    public int boost;
    private void Start()
    {
        spawner = FindObjectOfType<spawner>();
    }

    public void changerCouleurTrainer()
    {

    }
}
