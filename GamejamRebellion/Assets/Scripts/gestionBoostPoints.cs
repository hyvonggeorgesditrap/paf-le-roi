using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionBoostPoints : MonoBehaviour
{
    // CE SCRIPT EST TEMPORAIRE IL SERA IMPLÉMENTER DANS LE GAME MANAGER
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fonction appeler quand le joueur touche la cible
    public int CalculerPoints(int nbPoints)
    {
        int multiplicateur;
        switch (GetComponent<gestionTimeScale>().boostText)
        {
            case "X1":
                multiplicateur = 1;
                break;
            case "X2":
                multiplicateur = 2;
                break;
            case "X3":
                multiplicateur = 3;
                break;
            case "X4":
                multiplicateur = 4;
                break;
            default:
                multiplicateur = 1;
                break;
        }
        return nbPoints * multiplicateur;
    }
}
