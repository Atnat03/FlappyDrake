using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Text ScoreText;

    public void GoToPlay()
    {
        Debug.Log("Game");
        SceneManager.LoadScene("Game");
    }

    public void Quitter()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        ScoreText.text = PlayerPrefs.GetInt("MaxScore").ToString();
    }
}
