using System.Collections;
using System.Collections.Generic;
using TMPro;
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
}
