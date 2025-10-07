using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;
    
    string adUnitId;

    private void Awake()
    {
        #if UNITY_ANDROID
            adUnitId = androidAdUnitId;
        #elif UNITY_IOS
            adUnitId = iosAdUnitId;
        #elif UNITY_EDITOR
            adUnitId = androidAdUnitId;
        #endif
    }

    public void LoadInterstitial()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowInterstitialAd()
    {
        Advertisement.Show(adUnitId, this);
        LoadInterstitial();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Interstitial ad loaded");
    }
    
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ads Show Complete");
    }
    
    
    
    
    

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    { }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    { }

    public void OnUnityAdsShowStart(string placementId)
    { }

    public void OnUnityAdsShowClick(string placementId)
    { }
}
