using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuFin : MonoBehaviour
{
    [SerializeField]
    private GameObject scorenNormal;
    [SerializeField]
    private GameObject scoreMeilleur;
    [SerializeField]
    private TextMeshProUGUI[] scoresUI = new TextMeshProUGUI[2];

    [SerializeField]
    private TMP_InputField nomInput;

    private PlayfabManager manager = null;
    // Start is called before the first frame update
    void Start()  {
        manager = FindObjectOfType<PlayfabManager>();

        foreach (TextMeshProUGUI scoreUI in scoresUI) {
            scoreUI.text = manager.score.ToString();
        }
       
        if (manager.isNewBest) {
            scoreMeilleur.SetActive(true);
        } else {
            scorenNormal.SetActive(true);
        }
    }

    public void envoyerScore() {
        manager.envoyerScore(nomInput.text);
    }
}
