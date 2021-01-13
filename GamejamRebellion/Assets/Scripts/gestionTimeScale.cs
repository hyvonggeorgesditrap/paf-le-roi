using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionTimeScale : MonoBehaviour
{
   private int i;
   public string boostText = "X1";

   public void AugmenterTemps()
   {
        i++;
        if(i > 4)
        {
            Time.timeScale += 0.2f;
            i = 0;
            if (Time.timeScale == 2)
            {
                boostText = "X2";
                
            }else if (Time.timeScale == 3)
            {
                boostText = "X3";
                
            }
            else if (Time.timeScale == 4)
            {
                boostText = "X4";
                
            }
        }
   }

    public void ReduireVitesse()
    {
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Play()
    {
        Time.timeScale = 1;
    }
    public void ChangerCouleur()
    {
        switch(boostText)
        {
            case "X1":
                Debug.Log("Couleur Blanc");
                break;
            case "X2":
                Debug.Log("Couleur jaune");
                break;
            case "X3":
                Debug.Log("Couleur orange");
                break;
            case "X4":
                Debug.Log("Couleur bleu");
                break;
            default:
            
                break;
        }

    }
}

