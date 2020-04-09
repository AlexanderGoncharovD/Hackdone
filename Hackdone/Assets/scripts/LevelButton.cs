using Assets.Debug;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private int _lvl;

    private void Start()
    {
        try
        {
            _lvl = int.Parse(this.GetComponentInChildren<Text>().text); 
        }
        catch(Exception ex)
        {
            AppDebug.Error(ex.Message);
        }
    }

    public void LoadLevel()
    {
        var control = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<controller>();
        control.LoadLevel(_lvl);
    }
}
