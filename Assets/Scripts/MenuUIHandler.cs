using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{


    public string lastuserName;
    public string highscoreUserName;
    public int h_Points;
    public Text highScoreText;
    public InputField User;


    // Start is called before the first frame update
    void Start()
    {
        if (MenuControl.Instance != null)
        {
            highscoreUserName = MenuControl.Instance.highscoreUserName;
            h_Points = MenuControl.Instance.h_Points;
            lastuserName = MenuControl.Instance.lastuserName;
            highScoreText.text = "Best Score : " + highscoreUserName + " " + h_Points;
            User.text = lastuserName;

        }
    }

   

   public void UpdateLastUser()
    {
        MenuControl.Instance.lastuserName = User.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MenuControl.Instance.Save();
       
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
