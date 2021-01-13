using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int score;
    public int bestScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI comboText;

    private bool gamePlaying;
    public void BeginGame()
    {
        Debug.Log("Le jeu se lance");
        

        //gamePlaying = true;
    }

    void Update()
    {
        scoreText.text = score.ToString();
        bestScoreText.text = "Meilleur score : " + bestScore.ToString();
        comboText.text = "Combo";
    }

    public void AddScore(int a_objet)
    {
        score += a_objet;
    }
}
