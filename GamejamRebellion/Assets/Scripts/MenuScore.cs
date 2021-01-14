using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using TMPro;

public class MenuScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] ListeNom = new TextMeshProUGUI[4];
    [SerializeField]
    private TextMeshProUGUI[] ListeScore = new TextMeshProUGUI[4];

    [SerializeField]
    private PlayfabManager playfabManager = null;
    // Start is called before the first frame update

    void Start() {
        //vider les champ du leaderboard
        for (int i = 0; i < 3; i++) {
            ListeNom[i].text = "";
            ListeScore[i].text = "";
        }
    }

    public void Afficher()
    {
        Debug.Log("Afficher les scores!");
        if (playfabManager == null)
            playfabManager = FindObjectOfType<PlayfabManager>();
        playfabManager.GetLeaderboard(modifierMeilleurScores);
        playfabManager.GetPersonalLeaderBoard(modifierDernnierScore);
    }

    private void modifierDernnierScore(GetLeaderboardAroundPlayerResult obj) {
        if (obj.Leaderboard[0].StatValue == 0) {
            ListeNom[3].text = "";
            ListeScore[3].text = "-";
        }
        else {
            ListeNom[3].text = obj.Leaderboard[0].DisplayName;
            ListeScore[3].text = " : " + obj.Leaderboard[0].StatValue;
        }
    }

    private void modifierMeilleurScores(GetLeaderboardResult obj)
    {
        for (int i = 0; i < 3; i++) {
            if (i < obj.Leaderboard.Count)
            {
                ListeNom[i].text = obj.Leaderboard[i].DisplayName;
                ListeScore[i].text = ": " + obj.Leaderboard[i].StatValue;
            }
            else {
                ListeNom[i].text = "";
                ListeScore[i].text = "";
            }
        }
    }
}
