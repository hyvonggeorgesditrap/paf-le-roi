using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class MenuScore : MonoBehaviour
{
    [SerializeField]
    private PlayfabManager playfabManager = null;
    // Start is called before the first frame update

    public void Afficher()
    {
        Debug.Log("Afficher les scores!");
        if (playfabManager == null)
            playfabManager = FindObjectOfType<PlayfabManager>();
        playfabManager.GetLeaderboard(modifierMeilleurScores);
        playfabManager.GetPersonalLeaderBoard(modifierDernnierScore);
    }

    private void modifierDernnierScore(int score) {
        Debug.Log("Dernier score : "+score);
    }

    private void modifierMeilleurScores(GetLeaderboardResult obj)
    {
        foreach (var item in obj.Leaderboard) {
            Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
        }
    }
}
