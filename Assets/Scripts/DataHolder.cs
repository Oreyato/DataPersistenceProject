using System;
using System.IO;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance;

    public string CurrentPlayerName;
    public string BestPlayerName;
    public int BestScore;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerDatas();
    }
    
    // Data persistence between sessions ==============================================
    [System.Serializable]
    class SaveData
    {
        public string CurrentPlayerName;
        
        public int BestScore;
        public string BestPlayerName;
    }
    
    public void SavePlayerDatas()
    {
        SaveData data = new SaveData
        {
            CurrentPlayerName = CurrentPlayerName,
            
            BestScore = BestScore,
            BestPlayerName = BestPlayerName
        };

        // Store data in json format
        string json = JsonUtility.ToJson(data);
        
        // Send it to a file
        File.WriteAllText(Application.persistentDataPath + "/playerDatas.json", json);
    }
    
    public void LoadPlayerDatas()
    {
        string path = Application.persistentDataPath + "/playerDatas.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            CurrentPlayerName = data.CurrentPlayerName;
            BestPlayerName = data.BestPlayerName;
            BestScore = data.BestScore;
        }
    }
}
