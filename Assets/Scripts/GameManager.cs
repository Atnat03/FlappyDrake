using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private DragonStats drake;

    [SerializeField] private GameObject[] objectsToDestroy;
    [SerializeField] private GameObject uiDead;
    [SerializeField] private GameObject uiMain;
    [SerializeField] private Text scoreText;

    [SerializeField] private Button continueButton;
    public AdsManager adsManager;

    public bool isRewarded = false;

    private void Awake()
    {
        instance = this;
        
        drake.OnDead += GameOver;
        
        uiDead.SetActive(false);
    }

    private void OnDisable()
    {
        drake.OnDead -= GameOver;
    }

    private void Update()
    {
        continueButton.interactable = !isRewarded;
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

        if (CounterGame.instance.gamePlayed % 3 == 0)
        {
            adsManager.interstitialAds.ShowInterstitialAd();
        }
    }

    public void Restart()
    {
        CounterGame.instance.gamePlayed++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continue()
    {
        Debug.Log("Show continue ad");
        adsManager.rewardedAds.ShowRewardedAd();
    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game");
        
        GameOver(true);
        drake.ResetHealth();

        MoveableObjects[] moveable = FindObjectsByType<MoveableObjects>(FindObjectsSortMode.None);
        
        foreach (MoveableObjects obj in moveable)
        {
            Destroy(obj.gameObject);
        }
        
        isRewarded = true;
    }
}
