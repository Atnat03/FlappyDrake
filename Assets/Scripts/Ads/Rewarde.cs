using UnityEngine;
using UnityEngine.Advertisements;

public class Rewarde : MonoBehaviour,IUnityAdsLoadListener, IUnityAdsShowListener
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
    
    
    public void LoadRewardedAds()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowRewardedAd()
    {
        Debug.Log("Continue ad is showed");
        Advertisement.Show(adUnitId, this);
        LoadRewardedAds();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Interstitial ad loaded");
    }
    
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("OnUnityAdsShowComplete");
        
        if (placementId == adUnitId && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.isRewarded = true;
                GameManager.instance.ContinueGame();
            }
        }
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
