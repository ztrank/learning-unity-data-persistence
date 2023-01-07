using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int HighScore { get; set; }
    public string HighScoreName { get; set; }
    public string Name { get; set; }

    private string path;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        this.path = Path.Combine(Application.persistentDataPath, "saveData.json");
        this.Load();
        DontDestroyOnLoad(this.gameObject);
    }

    public void Save()
    {
        SaveData data = new SaveData()
        {
            HighScore = this.HighScore,
            HighScoreName = this.HighScoreName,
            LastName = this.Name
        };

        File.WriteAllText(this.path, JsonUtility.ToJson(data));
    }

    public void Load()
    {
        if (File.Exists(this.path))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(this.path));
            this.HighScore = data.HighScore;
            this.HighScoreName = data.HighScoreName;
            this.Name = data.LastName;
        }
    }

    public bool SetNewHighScore(int score)
    {
        if (this.HighScore < score)
        {
            this.HighScore = score;
            this.HighScoreName = this.Name;
            return true;
        }

        return false;
    }

    [Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScoreName;
        public string LastName;
    }
}
