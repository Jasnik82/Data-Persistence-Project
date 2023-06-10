using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MenuControl Instance;

    public string lastuserName;
    public string highscoreUserName;
    public int h_Points;
  
  

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        Load();
        DontDestroyOnLoad(gameObject);

      
    }


    [System.Serializable]
    class SaveData
    {
        public string highscoreUserName;
        public int h_Points;
        public string lastuserName;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highscoreUserName = highscoreUserName;
        data.h_Points= h_Points;
        data.lastuserName = lastuserName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscoreUserName = data.highscoreUserName;
            h_Points = data.h_Points;
            lastuserName = data.lastuserName;
        }

    }

    
}
