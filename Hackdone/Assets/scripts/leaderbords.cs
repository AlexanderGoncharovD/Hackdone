using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class leaderbords : MonoBehaviour
{ 
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
        Social.localUser.Authenticate((bool success) =>
        {
            // если подключение успешное
            if (success)
            {
                userName = Social.localUser.userName;//получаем имя игрока
            }
            else
            {

            }

        });
    }
}
