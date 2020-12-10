using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3889073";

    private string interstitialAd = "video";
    private static readonly string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;

#if UNITY_EDITOR
    public bool isTestAd = true;
#else
    public bool isTestAd = false;
#endif
    
    private CoinManager coinManager;

    public static AdManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.AddListener(this);
            Advertisement.Initialize(playStoreID, isTestAd);
        } else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();

        InitializeAdvertisement();
    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);
    }

    public static void PlayRewardedVideoAd()
    {
        if (Advertisement.IsReady(rewardedVideoAd))
        {
            Advertisement.Show(rewardedVideoAd);
        }
      
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAd) {
                    coinManager.AddCoin();
                    Debug.Log("Add coin");
                }
                if (placementId == interstitialAd) { Debug.Log("Finished interstitial"); }
                break;
        }
    }
}
