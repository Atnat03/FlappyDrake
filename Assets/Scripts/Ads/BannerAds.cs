using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
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
        
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoad,
            errorCallback = BannerLoadedError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }


    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = BannerShow,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };
        
        Advertisement.Banner.Show(adUnitId, options);
    }


    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
    
    
    private void BannerHidden(){ }
    private void BannerClicked() { }
    private void BannerShow() { }
    private void BannerLoadedError(string message) { }
    private void BannerLoad() { }
}
