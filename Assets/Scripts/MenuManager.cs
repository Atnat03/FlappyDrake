using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    public AdsManager adsManager;

    private void Start()
    {
        StartCoroutine(DisplayBannerWithDelay());
    }

    IEnumerator DisplayBannerWithDelay()
    {
        yield return new WaitForSeconds(1f);
        adsManager.bannerAds.ShowBannerAd();
    }

    public void GoToPlay()
    {
        SceneManager.LoadScene("Game");
        adsManager.bannerAds.HideBannerAd();
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
