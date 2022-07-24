using Game.Scripts.Logic.Destroy;
using Game.Scripts.Logic.Mode.Move;
using UnityEngine;

namespace Game.Scripts.Logic.Mode
{
    public class CirclePresenter: IPresenter
    {
        private CircleView circleView;
        private CircleModel circleModel;
        private CircleSpawner circleSpawner;
        private PlayerView playerView;
        private Effect[] effects;
        private CircleTapModeTriggerView circleTapModeTriggerView;

        public CirclePresenter(CircleView circleView, CircleModel circleModel, CircleSpawner circleSpawner, CircleTapModeTriggerView circleTapModeTriggerView)
        {
            this.circleView = circleView;
            this.circleModel = circleModel;
            this.circleSpawner = circleSpawner;
            this.circleTapModeTriggerView = circleTapModeTriggerView;
            this.effects = circleTapModeTriggerView.Effects;
        }

        private void OnTap()
        {
            if (circleModel.IsFinal)
            {
                circleTapModeTriggerView.NextDoAction();
               
            }
            Disable();
            foreach (var effect in effects)
            {
                effect.StartEffect();
            }
           
            //playerView.Tool();
            circleView.Die();
            circleSpawner.UnblockSpawn();
        }
        
        public void Enable()
        {
            circleView.TapEvent += OnTap;
        }

        public void Disable()
        {
            circleView.TapEvent -= OnTap;
        }
    }
}