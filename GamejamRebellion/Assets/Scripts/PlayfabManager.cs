using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class PlayfabManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Login() {
        var request = new LoginWithCustomIDRequest {
                CustomId = SystemInfo.deviceUniqueIdentifier,
                CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    public void envoyerScore(int score, string nom)
    {
        setName(nom);
        SendLeaderboard(score);
    }

    private void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate{
                    StatisticName = "Score",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    private void setName(String name)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = name
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnNameUpdated, OnError);
    }
    public void GetPersonalLeaderBoard()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Score",
            MaxResultsCount = 1,
            PlayFabId = null
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnPersonalLeaderboardGet, OnError);
    }

    void OnPersonalLeaderboardGet(GetLeaderboardAroundPlayerResult obj)
    {
        Debug.Log("Got personal leaderboard!");
        var dernierScore = obj.Leaderboard[0];
        Debug.Log(dernierScore.DisplayName + " " + dernierScore.StatValue);
    }


    void OnNameUpdated(UpdateUserTitleDisplayNameResult obj)
    {
        Debug.Log("Le nom a ete enregistrer!");
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult obj)
    {
        Debug.Log("Succes de l'envoie du leaderboard");
    }

    void OnLeaderboardGet(GetLeaderboardResult obj)
    {
        foreach (var item in obj.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
        }
    }

    void OnSuccess(LoginResult obj)
    {
        Debug.Log("connection/creation de compte complete avec success!");
    }

    void OnError(PlayFabError obj)
    {
        Debug.Log("Erreur lors de la connection/creation de compte!");
        Debug.Log(obj.GenerateErrorReport());
    }
}
