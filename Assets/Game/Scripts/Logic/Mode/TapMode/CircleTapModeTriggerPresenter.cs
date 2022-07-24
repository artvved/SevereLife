using Game.Scripts.Logic.Destroy;
using Game.Scripts.Logic.Mode;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class CircleTapModeTriggerPresenter : IPresenter
    {
        private CircleTapModeTriggerView view;
     
      
        private CircleSpawner circleSpawner;

        public CircleTapModeTriggerPresenter(CircleTapModeTriggerView view,  CircleSpawner circleSpawner)
        {
            this.view = view;
            
           
            this.circleSpawner = circleSpawner;
        }

        private void OnDoAction()
        {
            Debug.Log("on do");
            circleSpawner.StartSpawn(view);
            
        }
        
     

        
        
        public void Enable()
        {
            view.DoActionEvent += OnDoAction;
           
        }

        public void Disable()
        {
            view.DoActionEvent -= OnDoAction;
           
        }
    }
}