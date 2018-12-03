using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    [SerializeField]
    bool PauseOnStart = true;

    [SerializeField]
    GameObject menuPanel;
    [SerializeField]
    GameObject gameoverPanel;
    [SerializeField]
    Texture2D defaultCursor;

    //Settings settings;
    //string settingsPath = "Assets/Data/Settings.asset";
    KeyCode pauseKey = KeyCode.P;

    private void Awake()
    {
        //settings = (Settings)AssetDatabase.LoadMainAssetAtPath(settingsPath);
    }

    public void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
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
    public void EndGame()
    {
        menuPanel.SetActive(false);
        PauseGame();
        gameoverPanel.SetActive(true);
        // Play loose Sound
    }
    public void RetryGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        //ContinueGame();
        SceneManager.LoadScene(scene.name);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        //enable the scripts again
    }
}
