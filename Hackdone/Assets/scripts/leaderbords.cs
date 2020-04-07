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
        try
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.Activate();
        }
        catch(Exception ex)
        {
            AppDebug.Error(ex.Message);
        }
    }

    public void Start()
    {
        SearchCamera();
        ConnectionServies();
    }


    public void SearchCamera()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<controller>();
    }

    /// <summary>
    ///     Подключение к Google Play Srvices
    /// </summary>
    public void ConnectionServies()
    {
        try
        {
            Social.localUser.Authenticate((bool success, string message) =>
            {
                AppDebug.Info($"Loading: {success}");
                if (success)
                {
                    userName = Social.localUser.userName;
                    AppDebug.Info($"User name: {userName}");
                }
                else
                {
                    AppDebug.Error(message);
                }
            });
        }
        catch(Exception ex)
        {
            AppDebug.Error(ex.Message);
        }
    }

    /// <summary>
    ///     Отобразить таблицу лидеров
    /// </summary>
    public void OnShowLeaderBoard()
    {
        try
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(LEADERBOARD);
        }
        catch (Exception ex)
        {
            AppDebug.Error(ex.Message);
        }
    }

    /// <summary>
    ///     Опубликовать результат
    /// </summary>
    /// <param name="score">
    ///     Количество очков
    /// </param>
    public void Publish(int score)
    {
        Social.ReportScore(score, LEADERBOARD, (result) =>
        {
            if (!result)
            { 
                AppDebug.Error($"Publish score({score}) fail");
            }
        });
    }
}
