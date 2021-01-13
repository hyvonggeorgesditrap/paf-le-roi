using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float score;

    private bool gamePlaying;
    public void BeginGame()
    {
        Debug.Log("Le jeu se lance");
        //gamePlaying = true;
    }

    void Update()
    {
        
    }

    public void AddScore(int a_objet)
    {
        score += a_objet;
    }
}
