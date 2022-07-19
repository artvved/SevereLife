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

        private void OnDoAction()
        {
            levelChangeModeView.StartCoroutine(LevelChangeAnimation());;
        }

        public LevelChangeModePresenter(LevelChangeModeView levelChangeModeView, LevelController levelController,PlayerView playerView)
        {
            this.levelChangeModeView = levelChangeModeView;
            this.levelController = levelController;
            this.playerView = playerView;
            levelCompleteView = this.levelChangeModeView.LevelCompleteView;
            blackoutScreen = this.levelChangeModeView.BlackoutScreen;
        }


        private IEnumerator LevelChangeAnimation()
        {
            playerView.OnShowHideControls();
            levelCompleteView.Show();
            yield return new WaitUntil(() => levelCompleteView.IsFinished);
            blackoutScreen.StartDarkening();
            yield return new WaitUntil(() => blackoutScreen.IsDarkeningFinished);
            levelCompleteView.Idle();
            levelController.InitNewLevel();
            playerView.OnShowHideControls();
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