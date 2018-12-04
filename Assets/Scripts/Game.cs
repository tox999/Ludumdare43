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
    GameObject slidesPanel;
    [SerializeField]
    Texture2D defaultCursor;

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
        ContinueGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            PauseGame();
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

    public void ExitGame()
    {
        Application.Quit();
    }
}
