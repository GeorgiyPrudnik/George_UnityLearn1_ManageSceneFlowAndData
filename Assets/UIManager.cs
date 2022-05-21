using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI highscoreGUI;
    public GameObject inputField;
    public TextMeshProUGUI textDisplay;
    
    public void Start()
    {
        textDisplay.text = SaveManager.instance.playerName;
        highscoreGUI.text = "Highscore: " + SaveManager.instance.playerHighscore;
    }
    
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SaveManager.instance.SaveAllData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
      #else
      Application.Quit();
#endif
    }

    public void ResetProgress()
    {
        SaveManager.instance.ClearData();
        Debug.Log(SaveManager.instance.playerName);
        textDisplay.text = SaveManager.instance.playerName;
        highscoreGUI.text = "Highscore: " + SaveManager.instance.playerHighscore;
    }
    
    
    public void GetName()
    {
        textDisplay.text = inputField.GetComponent<TMP_InputField>().text;
        SaveManager.instance.playerName = textDisplay.text;
    }
    
    
}
