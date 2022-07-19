using System;
using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.Mode.Quest;
using Game.Scripts.Logic.Sequence;
using UnityEngine;

namespace Game.Scripts.Logic.Terrain
{
    public class WaitModeView : QuestAction
    {
        [SerializeField] private ItemView rewardItem;
        [SerializeField] private float waitTime;

        [SerializeField] private Animator wheelAnimator;


        public float WaitTime => waitTime;

        public ItemView RewardItem => rewardItem;


     
       

        public void StartWaitAnim()
        {
            wheelAnimator.SetTrigger("Spin");
        }

        public void StopWaitAnim()
        {
            wheelAnimator.SetTrigger("Idle");
        }
    }
}