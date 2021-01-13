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
