using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ReklamIcin : MonoBehaviour
{
    public void Start()
    {
        // Initialize the Mobile Ads SDK.
        MobileAds.Initialize((initStatus) =>
        {
            // SDK initialization is complete
        });
        
    }
}
