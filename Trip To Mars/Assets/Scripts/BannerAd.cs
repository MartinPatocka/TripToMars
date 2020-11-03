using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    private string gameID = "3889073";
    private string placementId = "banner";
    public bool testMode = true;

    IEnumerator Start()
    {
        Advertisement.Initialize(gameID, testMode);

        while (!Advertisement.IsReady(placementId))
            yield return null;

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show();

    }
}
