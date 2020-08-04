using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour
{
    public static AdController instance;

    private string store_id = "3493233";

    private string video_ad = "video";

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Advertisement.Initialize(store_id, false);
    }

    public void ShowVideoOrINterstitialAD()
    {
        if (Advertisement.IsReady(video_ad))
        {
            Advertisement.Show();
        }
        
    }


}
