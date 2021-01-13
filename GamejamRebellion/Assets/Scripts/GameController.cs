using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int score;
    public int bestScore;

    public int timerSeconds = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI comboText;

    private bool gamePlaying;
    public void BeginGame()
    {
        Debug.Log("Le jeu se lance");

        //gamePlaying = true;

    }

    private void Start()
    {
        StartCoroutine(StartTimer());

    }

    IEnumerator StartTimer()
    {
        while(timerSeconds > 0)
        {
            Debug.Log(timerSeconds);
            yield return new WaitForSecondsRealtime(1);
            timerSeconds--;
        }
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

    void OnTriggerExit(Collider other) {
        // Destroy Projectile that leaves the trigger
        if (other.gameObject.tag == "Projectile") {
            Debug.Log("Projectile detruit!");
            Destroy(other.gameObject);
        }
    }
}
