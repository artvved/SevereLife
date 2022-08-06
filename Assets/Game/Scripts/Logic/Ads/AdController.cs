using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using Game.Scripts.Logic.Ads;
using Game.Scripts.UI;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdController : MonoBehaviour
{

    [SerializeField] private HintView hintView;


    private string levelVideoID = "ca-app-pub-3940256099942544/8691691433"; //"ca-app-pub-3940256099942544/1033173712";
    private string rewardAdID ="ca-app-pub-3940256099942544/5224354917";

    private InterstitialAd changeLevelAd;
    private RewardedAd rewardedAd;

    private ItemName curNeed= ItemName.NOTHING;

    private void Awake()
    {
        MobileAds.Initialize(status => { });
    }

    private void OnEnable()
    {
        changeLevelAd = new InterstitialAd(levelVideoID);
        var adRec = new AdRequest.Builder().Build();
        changeLevelAd.LoadAd(adRec);
        
        rewardedAd = new RewardedAd(rewardAdID);
        var rewAd = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(rewAd);
        
        rewardedAd.OnUserEarnedReward += EarnReward;

    }

    private void EarnReward(object sender, Reward reward)
    {
        if (curNeed!= ItemName.NOTHING)
        {
            hintView.Show(curNeed);
        }
       
    }

    public void ChangeCurrentItemHint(ItemName itemName)
    {
        curNeed = itemName;
    }

    public void ShowLevelChangeAd()
    {
        if (changeLevelAd.IsLoaded())
        {
            changeLevelAd.Show();
            changeLevelAd = new InterstitialAd(levelVideoID);
            var adRec = new AdRequest.Builder().Build();
            changeLevelAd.LoadAd(adRec);
        }
       
    }
    
    public void ShowRewardAd()
    {
        if (curNeed != ItemName.NOTHING)
        {
            if (rewardedAd.IsLoaded())
            {
                rewardedAd.Show();
                rewardedAd = new RewardedAd(rewardAdID);
                var rewAd = new AdRequest.Builder().Build();
                rewardedAd.LoadAd(rewAd);
            }
            
        }
    }
}