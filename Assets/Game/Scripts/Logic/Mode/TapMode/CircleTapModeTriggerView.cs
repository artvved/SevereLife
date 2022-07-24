using System;
using System.Collections;
using Game.Scripts.Logic.Destroy;
using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.Mode.Move;
using Game.Scripts.Logic.Mode.Quest;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class CircleTapModeTriggerView : QuestAction
    {
        [SerializeField] private int circlesCount;
        [SerializeField] private Effect[] effects;

        public Effect[] Effects => effects;

        public int CirclesCount => circlesCount;

      
      
        
       
        
    }
}