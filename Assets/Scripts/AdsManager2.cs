/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4253631");
    }

    public void ShowBanner()
    {
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_LEFT);
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
        yield return new WaitForSeconds(5);
        ShowBanner();
    }
}
*/