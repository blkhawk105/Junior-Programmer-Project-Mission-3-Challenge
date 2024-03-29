using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public TMP_InputField NewPlayerNameText;

    public TextMeshProUGUI HighScorePlayerNameText;
    public TextMeshProUGUI HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        SaveManager.Instance.LoadTopScore();
        
        HighScorePlayerNameText.text = "Name: " + SaveManager.Instance.HighScorePlayerName;
        HighScoreText.text = "Score: " + SaveManager.Instance.HighScore.ToString();
    }

    public void StartNewGame()
    {
        if(!string.IsNullOrEmpty(NewPlayerNameText.text))
        {
            SaveManager.Instance.CurrentPlayer = NewPlayerNameText.text;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
