using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;
using System.IO;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;

    public string playerName;
    public int highScore = 0;
    public string bestPlayer;

    // Start is called before the first frame update
    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        LoadInfo();
    }
    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string bestPlayer;
        public int highScore;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestPlayer = bestPlayer;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

                
            playerName = data.playerName;
            bestPlayer = data.bestPlayer;
            highScore = data.highScore;
        }
    
    }

}
