using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public string CurrentPlayer;

    public string HighScorePlayerName { get; private set; }
    public int HighScore { get; private set; }

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
    }


    [System.Serializable]
    class SaveData
    {
        public string HighScorePlayerName;
        public int HighScore;
    }

    public void SaveTopScore(string name, int score)
    {
        SaveData data = new()
        {
            HighScorePlayerName = name,
            HighScore = score
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

            HighScorePlayerName = data.HighScorePlayerName;
            HighScore = data.HighScore;
        }
        else
        {
            HighScorePlayerName = "Will it be you?";
            HighScore = 0;
        }

        Debug.Log("Score Loaded for: " + HighScorePlayerName);
        
        // Show the save path when running in the editor
        #if UNITY_EDITOR
            Debug.Log(path);
        #endif
    }
}
