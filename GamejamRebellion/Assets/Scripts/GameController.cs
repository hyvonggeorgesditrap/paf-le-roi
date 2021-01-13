using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public int score;
    public int bestScore;

    public int timerSeconds = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI comboText;
    public Image healthBarImage;

    private bool gamePlaying;
    public void BeginGame()
    {
        Debug.Log("Le jeu se lance");
        updateAffichageHealth();
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

    public void addHealth(int damageAmout)
    {
        health += damageAmout;
        health = Mathf.Clamp(health, 0f, maxHealth);
        updateAffichageHealth();
    }

    void updateAffichageHealth()
    {
        healthBarImage.fillAmount = health / maxHealth;
    }

    void OnTriggerExit(Collider other) {
        // Destroy Projectile that leaves the trigger
        if (other.gameObject.tag == "Projectile") {

            //Reduire la vie
            addHealth(0 - other.GetComponent<Projectile>().poids);
            //Detruire l'objet
            Destroy(other.gameObject);
        }
    }
}
