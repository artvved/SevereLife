using System.Collections;
using System.Collections.Generic;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.LevelChanger
{
    public class LevelChangeModePresenter : IPresenter
    {
        private LevelChangeModeView levelChangeModeView;
        private LevelController levelController;
        private LevelCompleteView levelCompleteView;
        private BlackoutScreen blackoutScreen;
        private PlayerView playerView;
        private AdController adController;

        private void OnDoAction()
        {
            levelChangeModeView.StartCoroutine(LevelChangeAnimation());;
        }

        public LevelChangeModePresenter(LevelChangeModeView levelChangeModeView, LevelController levelController,PlayerView playerView,AdController adController)
        {
            this.levelChangeModeView = levelChangeModeView;
            this.levelController = levelController;
            this.playerView = playerView;
            this.adController = adController;
            levelCompleteView = this.levelChangeModeView.LevelCompleteView;
            blackoutScreen = this.levelChangeModeView.BlackoutScreen;
            
        }


        private IEnumerator LevelChangeAnimation()
        {
            playerView.OnHideControls();
            levelCompleteView.Show();
            yield return new WaitUntil(() => levelCompleteView.IsFinished);
            blackoutScreen.StartDarkening();
            yield return new WaitUntil(() => blackoutScreen.IsDarkeningFinished);
            levelCompleteView.Idle();
           
            adController.ShowLevelChangeAd();
           
            levelController.InitNewLevel();
            playerView.OnShowControls();
        }

        public void Enable()
        {
            levelChangeModeView.DoActionEvent += OnDoAction;
        }

        public void Disable()
        {
            levelChangeModeView.DoActionEvent -= OnDoAction;
        }
    }
}