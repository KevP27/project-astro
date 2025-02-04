/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public GameObject HideButton;

    static int loadCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4253631");

        if (loadCount % 3 == 0)
        {
            PlayAd();
        }
        loadCount++;
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void ShowBanner()
    {
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
        }

        else
        {
            StartCoroutine(RepeatShowBanner());
        }
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }
}
*/