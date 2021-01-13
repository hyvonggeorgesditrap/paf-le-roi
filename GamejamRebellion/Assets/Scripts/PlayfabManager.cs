using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class PlayfabManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Start() {
        Login();
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

    public void GetLeaderboard(Action<GetLeaderboardResult> callback)
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, callback, OnError);
    }

    private void setName(String name)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = name
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnNameUpdated, OnError);
    }
    public void GetPersonalLeaderBoard(Action<GetLeaderboardAroundPlayerResult> callback)
    {
        int score = 0;
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Score",
            MaxResultsCount = 1,
            PlayFabId = null
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, callback, OnError);
    }

    int OnPersonalLeaderboardGet(GetLeaderboardAroundPlayerResult obj)
    {
        Debug.Log("Got personal leaderboard!");
        var dernierScore = obj.Leaderboard[0];
        return dernierScore.StatValue;
    }


    void OnNameUpdated(UpdateUserTitleDisplayNameResult obj)
    {
        Debug.Log("Le nom a ete enregistrer!");
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult obj)
    {
        Debug.Log("Succes de l'envoie du leaderboard");
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
