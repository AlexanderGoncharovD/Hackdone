using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDebug : MonoBehaviour
{
    #region Public Fields

    public Text debugDisplay;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        debugDisplay.gameObject.SetActive(Assets.Debug.AppDebug.isDebug);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
