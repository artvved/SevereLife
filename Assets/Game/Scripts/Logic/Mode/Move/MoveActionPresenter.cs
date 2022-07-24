using UnityEngine;

namespace Game.Scripts.Logic.Mode.Move
{
    public class MoveActionPresenter : IPresenter
    {

        private MoveActionView view;

        public MoveActionPresenter(MoveActionView view)
        {
            this.view = view;
        }

        private void DoAction()
        {
          
            view.StartCoroutine(view.GoToTarget());
            view.PlayEffects();
          

        }

        private void OnFinishMove()
        {
           
            view.NextDoAction();
        }

        public void Enable()
        {
            view.DoActionEvent += DoAction;
            view.FinishMoveEvent += OnFinishMove;
        }

        public void Disable()
        {
            view.DoActionEvent -= DoAction;
            view.FinishMoveEvent -= OnFinishMove;
        }
    }
}