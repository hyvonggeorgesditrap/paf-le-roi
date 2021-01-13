using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionTimeScale : MonoBehaviour
{
   private int i;

   public void AugmenterTemps()
   {
        i++;
        if(i > 4)
        {
            Time.timeScale += 0.2f;
            i = 0;
        }
   }

    public void ReduireVitesse()
    {
        Time.timeScale = 1;
    }

}
