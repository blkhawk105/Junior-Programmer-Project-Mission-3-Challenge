using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public TextMeshProUGUI NewPlayerName;

    public TextMeshProUGUI HighScorePlayerName;
    public TextMeshProUGUI HighScoreText;

    public int HighScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadTopScore();
        HighScoreText.text = HighScore.ToString();

        // HighScore = 0;
        // SaveTopScore();
    }


    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public void SaveTopScore()
    {
        SaveData data = new()
        {
            highScorePlayerName = NewPlayerName.text,
            highScore = HighScore
        };


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        Debug.Log("Score Saved");
    }

    public void LoadTopScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayerName.text = data.highScorePlayerName;
            HighScore = data.highScore;
        }
        else
        {
            HighScorePlayerName.text = "Will it be you?";
        }

        Debug.Log("Score Loaded");
    }
}
