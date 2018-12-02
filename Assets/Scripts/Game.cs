using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField]
    bool PauseOnStart = true;

    [SerializeField]
    GameObject menuPanel;

    //Settings settings;
    //string settingsPath = "Assets/Data/Settings.asset";
    KeyCode pauseKey = KeyCode.P;

    private void Awake()
    {
        //settings = (Settings)AssetDatabase.LoadMainAssetAtPath(settingsPath);
    }

    public void Start()
    {
        if (PauseOnStart)
            PauseGame();
        else
            menuPanel.SetActive(false);
    }

    public void Play()
    {
        ContinueGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (!menuPanel.activeInHierarchy)
            {
                PauseGame();
            }
            if (menuPanel.activeInHierarchy)
            {
                ContinueGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        //enable the scripts again
    }
}
