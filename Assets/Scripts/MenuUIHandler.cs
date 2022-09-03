using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;
    
    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SavePlayerName()
    {
        DataHolder.Instance.CurrentPlayerName = playerName.text;
        DataHolder.Instance.SavePlayerDatas();
    }

    public void Exit()
    {
        DataHolder.Instance.SavePlayerDatas();
        
        // Conditional compiling
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
