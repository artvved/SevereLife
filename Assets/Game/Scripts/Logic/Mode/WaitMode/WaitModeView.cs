using System;
using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.Mode.Move;
using Game.Scripts.Logic.Mode.Quest;
using Game.Scripts.Logic.Sequence;
using UnityEngine;

namespace Game.Scripts.Logic.Terrain
{
    public class WaitModeView : QuestAction
    {
        [SerializeField] private ItemView rewardItem;
        [SerializeField] private float waitTime;

        [SerializeField] private Effect[] effects;


        public float WaitTime => waitTime;

        public ItemView RewardItem => rewardItem;


     
       

        public void StartWaitAnim()
        {
            if (effects!=null && effects.Length!=0)
            {
                foreach (var effect in effects)
                {
                    effect.StartEffect();
                }
            }
          
        }

        public void StopWaitAnim()
        {
            if (effects!=null && effects.Length!=0)
            {
                foreach (var effect in effects)
                {
                    effect.StopEffect();
                }
            }
           
        }
    }
}