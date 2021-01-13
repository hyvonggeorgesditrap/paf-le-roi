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

    public int hitConsecutif = 0;
    public int boost = 1;

    public int timerSeconds = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI comboText;
    public Image healthBarImage;

    private bool gamePlaying;
    public void BeginGame()
    {
        Debug.Log("Le jeu se lance");
        //gamePlaying = true;

    }

    private void Start() {
        StartCoroutine(StartTimer());

        updateAffichageHealth();
        afficherBoost();
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
    }

    public void AugmenterTemps() {
        hitConsecutif++;
        if (hitConsecutif > 4) {
            Time.timeScale += 0.2f;
            hitConsecutif = 0;
            boost++;
            afficherBoost();
        }
    }

    void afficherBoost() { comboText.text = "Combo X" + boost; }

    public void ResetBoost() {
        Time.timeScale = 1;
        boost = 1;
        afficherBoost();
    }

    public void Pause() {
        Time.timeScale = 0;
    }
    public void Play() {
        ResetBoost();
    }

    public void ChangerCouleur() {
        switch (boost) {
            case 1:
                Debug.Log("Couleur Blanc");
                break;
            case 2:
                Debug.Log("Couleur jaune");
                break;
            case 3:
                Debug.Log("Couleur orange");
                break;
            case 4:
                Debug.Log("Couleur bleu");
                break;
            default:

                break;
        }
    }

    public void touchee(int poids) {
        AddScore(poids);
        AugmenterTemps();
    }

    private void AddScore(int a_objet) {
        score += a_objet * boost;
    }

    public void addHealth(int damageAmout) {
        health += damageAmout;
        health = Mathf.Clamp(health, 0f, maxHealth);
        updateAffichageHealth();
    }

    void updateAffichageHealth() {
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
