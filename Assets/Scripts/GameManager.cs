using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DragonStats drake;

    [SerializeField] private GameObject[] objectsToDestroy;
    [SerializeField] private GameObject uiDead;
    [SerializeField] private GameObject uiMain;
    [SerializeField] private Text scoreText;

    private bool haveAlreadySeeAd = false;
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        drake.OnDead += GameOver;
        
        uiDead.SetActive(false);
    }

    private void OnDisable()
    {
        drake.OnDead -= GameOver;
    }

    private void Update()
    {
        continueButton.interactable = !haveAlreadySeeAd;
    }

    private void GameOver(bool state = false)
    {
        scoreText.text = drake.currentScore.ToString();
        
        foreach (GameObject obj in objectsToDestroy)
        {
            obj.SetActive(state);
        }
        
        int maxScore = PlayerPrefs.GetInt("MaxScore");

        int newMaxScore = Mathf.Max(maxScore, drake.currentScore);
        PlayerPrefs.SetInt("MaxScore", newMaxScore);
        
        uiDead.SetActive(!state);
        uiMain.SetActive(state);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continue()
    {
        GameOver(true);
        drake.ResetHealth();

        MoveableObjects[] moveable = FindObjectsByType<MoveableObjects>(FindObjectsSortMode.None);
        
        foreach (MoveableObjects obj in moveable)
        {
            Destroy(obj.gameObject);
        }
        
        haveAlreadySeeAd = true;
    }
}
