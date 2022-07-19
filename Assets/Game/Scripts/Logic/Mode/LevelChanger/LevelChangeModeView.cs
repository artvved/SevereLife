using System.Collections;
using Game.Scripts.Logic.Mode.Quest;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.LevelChanger
{
    public class LevelChangeModeView : QuestAction
    {
        [SerializeField] private LevelCompleteView levelCompleteView;
        [SerializeField] private BlackoutScreen blackoutScreen;


        public LevelCompleteView LevelCompleteView => levelCompleteView;

        public BlackoutScreen BlackoutScreen => blackoutScreen;
    }
}