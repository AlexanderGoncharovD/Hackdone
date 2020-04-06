using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using System;
using Assets.Debug;

public class leaderbords : MonoBehaviour
{
    private const string LEADERBOARD = "CgkI54aDkMoUEAIQAQ";
    private controller camera;
    public string userName;

    private void Awake()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
    }

    public void Start()
    {
        SearchCamera();
        ConnectionServies();
    }

    void Update()
    {

    }

    public void SearchCamera()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<controller>();
    }

    public void ConnectionServies()
    {
        // авторизация на Google play servies
        Social.localUser.Authenticate((bool success, string message) =>
        {
            AppDebug.Info($"Loading: {success}");
            // если подключение успешное
            if (success)
            {
                userName = Social.localUser.userName;//получаем имя игрока
                AppDebug.Info($"User name: {userName}");
            }
            else
            {
                AppDebug.Info($"Error connect: {message}");
            }
        });
    }

    public void OnShowLeaderBoard()
    {
        try
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(LEADERBOARD);
        }
        catch (Exception ex)
        {
            AppDebug.Info(ex.Message);
        }
    }
}
