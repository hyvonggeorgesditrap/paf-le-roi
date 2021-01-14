using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setDaltonien : MonoBehaviour
{
    public Image panel;
   public void SetDaltonien(string typeDaltonisme)
    {
        switch (typeDaltonisme)
        {
            case "protanopi":
                panel.color = new Color(132, 132, 132, 30);
                break;
            case "deutéranopie":
                panel.color = new Color(164, 35, 35, 30);
                break;
            case "tritanopie":
                panel.color = new Color(137, 44, 151, 30);
                break;
            default:
                panel.color = new Color(255, 255, 255, 0);
                break;
        }
    }
}
