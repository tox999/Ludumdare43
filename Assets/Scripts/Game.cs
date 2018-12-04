using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    [SerializeField]
    bool PauseOnStart = true;

    [SerializeField]
    GameObject menuPanel;
    [SerializeField]
    GameObject gameoverPanel;
    [SerializeField]
    GameObject slidesPanel;
    [SerializeField]
    GameObject inGameUIPanel;
    [SerializeField]
    Texture2D defaultCursor;
    [SerializeField]
    Text TimeCounter;
    [SerializeField]
    Text gameOverScoreText;

    [HideInInspector]
    public float SurvivingTime = 0;
    [HideInInspector]
    public bool Playing = false;
    [HideInInspector]
    public float ScoreTime = 0;
    //Settings settings;
    //string settingsPath = "Assets/Data/Settings.asset";
    KeyCode pauseKey = KeyCode.Escape;

    private void Awake()
    {
        //settings = (Settings)AssetDatabase.LoadMainAssetAtPath(settingsPath);
    }

    public void Start()
    {
        Cursor.SetCursor(defaultCursor, new Vector2(defaultCursor.width/2, defaultCursor.height/2) , CursorMode.Auto);
        if (PauseOnStart)
        {
            PauseGame();
            menuPanel.SetActive(true);
        }
        else
            menuPanel.SetActive(false);
    }

    public void Play()
    {
        Playing = true;
        ContinueGame();

    }

    void Update()
    {
        if (Playing)
            SurvivingTime += Time.deltaTime;

        TimeCounter.text = SecondsToTime(SurvivingTime);

        if (Input.GetKeyDown(pauseKey))
        {
            PauseGame();
        }
    }

    string SecondsToTime(float seconds)
    {
        TimeSpan t = TimeSpan.FromSeconds(seconds);

        if (t.Hours > 0)
        {
            return string.Format("{0:d}h {1:d}m {2:d}s {3:d}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
        }
        if (t.Minutes > 0)
        {
            return string.Format("{0:d}m {1:d}s {2:d}", t.Minutes, t.Seconds, t.Milliseconds);
        }
        if (t.Seconds > 0)
        {
            return string.Format("{0:d}s {1:d}", t.Seconds, t.Milliseconds);
        }
        return string.Format("{0:d}ms", t.Milliseconds);
    }

    public void PauseGame()
    {
        Playing = false;
        Time.timeScale = 0;
        menuPanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    public void EndGame()
    {
        //ScoreTime = SurvivingTime;
        gameOverScoreText.text = "You managed to survive for: " + SecondsToTime(SurvivingTime);
        //SurvivingTime = 0;
        menuPanel.SetActive(false);
        PauseGame();
        gameoverPanel.SetActive(true);
        // Play loose Sound
    }
    public void RetryGame()
    {
        SurvivingTime = 0;
        Scene scene = SceneManager.GetActiveScene();
        //ContinueGame();
        SceneManager.LoadScene(scene.name);
    }
    public void ContinueGame()
    {
        Playing = true;
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        //enable the scripts again
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
