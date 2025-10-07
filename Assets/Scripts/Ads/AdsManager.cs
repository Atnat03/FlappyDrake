using System;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public InitializeAds initializeAds;
    public BannerAds bannerAds;
    public InterstitialAds interstitialAds;
    public Rewarde rewardedAds;
    
    public static AdsManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
        
        bannerAds.LoadBannerAd();
        interstitialAds.LoadInterstitial();
        rewardedAds.LoadRewardedAds();
    }
}
