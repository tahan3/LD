using System;
using System.Collections.Generic;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using ModestTree.Util;
using UnityEngine;

namespace Source.Scripts.SDK
{
    public class AppodealHandler : IAppodealInitializationListener, IInitializer, IInterstitialAdListener
    {
        public bool Status { get; private set; }
        
        public AppodealHandler(string appKey/*, params int[] types*/)
        {
            int adTypes = Appodeal.INTERSTITIAL | Appodeal.BANNER | Appodeal.REWARDED_VIDEO | Appodeal.MREC;
            
            /*for (var i = 0; i < types.Length; i++)
            {
                adTypes |= types[i];
            }*/

            Appodeal.initialize(appKey, adTypes, this);
        }
   
        public void ShowInterstitial()
        {
            if (Appodeal.canShow(Appodeal.INTERSTITIAL))
            {
                Appodeal.show(Appodeal.INTERSTITIAL);
            }
        }
        
        public void ShowInterstitial(string placement)
        {
            if (Appodeal.canShow(Appodeal.INTERSTITIAL, placement))
            {
                Appodeal.show(Appodeal.INTERSTITIAL, placement);
            }
        }
        
        public void onInitializationFinished(List<string> errors)
        {
            Status = true;
            Appodeal.setInterstitialCallbacks(this);
        }

        public void onInterstitialLoaded(bool isPrecache)
        {
            Debug.Log("Interstitial loaded");
        }

        public void onInterstitialFailedToLoad()
        {
            Debug.LogError("Interstitial loading failed");
        }

        public void onInterstitialShowFailed()
        {
            Debug.LogError("Interstitial show failed");
        }

        public void onInterstitialShown()
        {
            Debug.Log("Interstitial shown");
        }

        public void onInterstitialClosed()
        {
            Debug.Log("Interstitial closed");
        }

        public void onInterstitialClicked()
        {
            Debug.Log("Interstitial clicked");
        }

        public void onInterstitialExpired()
        {
            Debug.Log("Interstitial expired");
        }
    }
}