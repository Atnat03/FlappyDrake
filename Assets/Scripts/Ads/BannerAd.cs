using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    public static BannerAd instance; void Awake() { instance = this; } 
    
  [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

  [SerializeField] string _androidAdUnitId = "Banner_Android";
  [SerializeField] string _iOSAdUnitId = "Banner_iOS";
  string _adUnitId = null;

  void Start()
  {
      LoadBanner();
      ShowBannerAd();
      
    #if UNITY_IOS
    _adUnitId = _iOSAdUnitId;
    #elif UNITY_ANDROID
    _adUnitId = _androidAdUnitId;
    #endif

    Advertisement.Banner.SetPosition(_bannerPosition);
  }

  public void LoadBanner()
  {
      // Set up options to notify the SDK of load events:
      BannerLoadOptions options = new BannerLoadOptions
      {
          loadCallback = OnBannerLoaded,
          errorCallback = OnBannerError
      };

      // Load the Ad Unit with banner content:
      Advertisement.Banner.Load(_adUnitId, options);
  }

  void OnBannerLoaded()
  {
      Debug.Log("Banner loaded");
  }

  // Implement code to execute when the load errorCallback event triggers:
  void OnBannerError(string message)
  {
      Debug.Log($"Banner Error: {message}");
      // Optionally execute additional code, such as attempting to load another ad.
  }

  // Implement a method to call when the Show Banner button is clicked:
  void ShowBannerAd()
  {
      // Set up options to notify the SDK of show events:
      BannerOptions options = new BannerOptions
      {
          clickCallback = OnBannerClicked,
          hideCallback = OnBannerHidden,
          showCallback = OnBannerShown
      };

      // Show the loaded Banner Ad Unit:
      Advertisement.Banner.Show(_adUnitId, options);
  }

  // Implement a method to call when the Hide Banner button is clicked:
  void HideBannerAd()
  {
      // Hide the banner:
      Advertisement.Banner.Hide();
  }

  void OnBannerClicked() { }
  void OnBannerShown() { }
  void OnBannerHidden() { }
}
