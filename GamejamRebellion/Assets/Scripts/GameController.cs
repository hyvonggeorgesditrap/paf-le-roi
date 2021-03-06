using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using TMPro;
using System;
using UnityEngine.Rendering.PostProcessing;

public class GameController : MonoBehaviour
{
    const float VITESSE_MAX = 2f;

    public float health;
    public float maxHealth;

    public int score;
    public int bestScore;

    public int hitConsecutif = 0;
    public int combo = 1;
    public Settings sets;
    public int timerSeconds = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI comboText;
    public Image healthBarImage;
    public List<PostProcessProfile> profils;
    public TextMeshProUGUI countdown;
    private bool gamePlaying;

    [SerializeField]
    private List<Transform> positionsAleatoires;
    [SerializeField]
    private GameObject pancarte;

    [SerializeField]
    private List<Animator> animatorVillageois;

    [SerializeField]
    private AudioSource sourceMusique;
    [SerializeField]
    private AudioSource sourceEffets;
    [SerializeField]
    private AudioClip sonTirManque;
    [SerializeField]
    private AudioClip sonTirTouchee;
    [SerializeField]
    private AudioClip sonImpact;
    private PlayfabManager playfabManager = null;

    private void Start()
    {
        //Recuperer la session
        playfabManager = FindObjectOfType<PlayfabManager>();
        sets = FindObjectOfType<Settings>();
        //Afficher le dernier score
        playfabManager.GetPersonalLeaderBoard(afficherDernierScore);

        //set valeur de verification de nouveau meilleur score a faux par defaut
        playfabManager.isNewBest = false;
        playfabManager.score = 0;

        //Positionner pancarte al�atoire
        placerPancarte();

        StartCoroutine(StartTimer());
        updateAffichageHealth();
        afficherCombo();
        setupCam();
        
    }

    void afficherDernierScore(GetLeaderboardAroundPlayerResult obj) {
        bestScore = obj.Leaderboard[0].StatValue;
        bestScoreText.text = "Record : " + obj.Leaderboard[0].StatValue;
    }

    void placerPancarte()
    {
        int index = UnityEngine.Random.Range(0, positionsAleatoires.Count);
        Transform pancartePosition = positionsAleatoires[index];
        Instantiate(pancarte, pancartePosition.position, pancartePosition.rotation);
    }

    IEnumerator StartTimer()
    {
        while (timerSeconds > 0)
        {
            Debug.Log("seconde"+ timerSeconds);
            countdown.text = timerSeconds.ToString();
            yield return new WaitForSecondsRealtime(1);
            timerSeconds--;
        }
        countdown.text = "";
        gamePlaying = true;
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AugmenterTemps() {
        hitConsecutif++;
        if (hitConsecutif > 4 && Time.timeScale < VITESSE_MAX) {
            Time.timeScale += 0.2f;
            hitConsecutif = 0;
            combo++;
            afficherCombo();
            GererMusique();
        }
    }
    public void Frappe() {
        for(int i = 0; i < animatorVillageois.Count; i++)
        {
            animatorVillageois[i].SetTrigger("statueTouchee");
        }

        sourceEffets.PlayOneShot(sonTirTouchee);
    }

    internal void Missed()
    {
        sourceEffets.PlayOneShot(sonTirManque);
    }

    void afficherCombo() { comboText.text = "Combo X" + combo; }

    public void ResetCombo() {
        Time.timeScale = 1;
        hitConsecutif = 0;
        combo = 1;
        afficherCombo();
        GererMusique();
    }

    public void Pause() {
        Time.timeScale = 0;
    }
    public void Play() {
        ResetCombo();
    }

    public void touchee(int poids) {
        sourceEffets.PlayOneShot(sonImpact);
        AddScore(poids);
        AugmenterTemps();
    }

    private void AddScore(int a_objet) {
        score += a_objet * combo;
    }

    public void addHealth(int damageAmout) {
        if (gamePlaying) {
            if (damageAmout < 0) Missed();
            health += damageAmout;
            health = Mathf.Clamp(health, 0f, maxHealth);
            updateAffichageHealth();

            //Si mort
            if (health <= 0)  {
                LevelLoader loader = FindObjectOfType<LevelLoader>();
                playfabManager.isNewBest = (bestScore < score);
                playfabManager.score = score;
                loader.LoadFin();
            }
        }
    }

    void updateAffichageHealth() {
        healthBarImage.fillAmount = health / maxHealth;
    }

    void OnTriggerExit(Collider other) {
        // Destroy Projectile that leaves the trigger
        if (other.gameObject.tag == "Projectile") {
            //Reduire la vie
            addHealth(0 - other.GetComponent<Projectile>().poids);
            //'Briser' le combo
            ResetCombo();
            //Detruire l'objet
            Destroy(other.gameObject);
        }
    }

    public void GererMusique() {
        if (combo == 1)  {
            sourceMusique.pitch = (float)1.0;
            sourceEffets.pitch = (float)1.0;
        }
        else {
            sourceMusique.pitch = float.Parse("1." + combo);
            sourceEffets.pitch = float.Parse("1." + combo);
        }
    }

    public void setupCam()
    {
        if (sets.toggleDaltonisme)
        {
         switch (sets.daltonisme)
         {
                    case "Protanopia":
                        Camera.main.GetComponent<PostProcessVolume>().profile = profils[0];
                        break;
                    case "Deuteranopia":
                        Camera.main.GetComponent<PostProcessVolume>().profile = profils[2];
                        break;
                    case "Tritanopia":
                        Camera.main.GetComponent<PostProcessVolume>().profile = profils[1];
                        break;
                    default:
                        Camera.main.GetComponent<PostProcessVolume>().profile = profils[3];
                        break;
          }
        }
        else
        {
            Camera.main.GetComponent<PostProcessVolume>().profile = profils[3];
        }       
    }

}
