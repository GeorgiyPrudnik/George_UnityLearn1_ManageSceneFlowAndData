using System;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public string playerName;
    public int playerHighscore;
    

    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/savefile.json"))
        {
            LoadData();
        }
        else
        {
            playerName = "Player 1";
            playerHighscore = 0;
        }
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerNameSavedText;
        public int highscore;
    }
    
    public void SaveAllData()
    {
        SaveData data = new SaveData();
        data.playerNameSavedText = playerName;
        data.highscore = playerHighscore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void LoadData()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        playerName = data.playerNameSavedText;
        playerHighscore = data.highscore;
    }

    public void ClearData()
    {
        SaveData data = new SaveData();
        playerName = "Player 1";
        playerHighscore = 0;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
