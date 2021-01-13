using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class MenuScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] ListeNomLeaderBoard = new TextMeshProUGUI[3];
    [SerializeField]
    private TextMeshProUGUI[] ListeScoreLeaderBoard = new TextMeshProUGUI[3];
    [SerializeField]
    private TextMeshProUGUI textDernierScore;

    [SerializeField]
    private PlayfabManager playfabManager = null;
    // Start is called before the first frame update

    void Start() {
        //vider les champ du leaderboard
        /*for (int i = 0; i < 3; i++) {
            ListeNomLeaderBoard[i].text = "";
            ListeScoreLeaderBoard[i].text = "";
        }*/
    }

    public void Afficher()
    {
        Debug.Log("Afficher les scores!");
        if (playfabManager == null)
            playfabManager = FindObjectOfType<PlayfabManager>();
        playfabManager.GetLeaderboard(modifierMeilleurScores);
        playfabManager.GetPersonalLeaderBoard(modifierDernnierScore);
    }

    private void modifierDernnierScore(int score) {
        textDernierScore.text = ""+score;
    }

    private void modifierMeilleurScores(GetLeaderboardResult obj)
    {
        for (int i = 0; i < 3; i++) {
            if (i < obj.Leaderboard.Count) {
                ListeNomLeaderBoard[i].text = obj.Leaderboard[i].DisplayName;
                ListeScoreLeaderBoard[i].text = ": "+obj.Leaderboard[i].StatValue;
            }
        }
    }
}
