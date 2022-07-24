namespace Game.Scripts.Logic.Mode.Sound
{
    public class SoundActionPresenter : IPresenter
    {
        private SoundActionView view;

        public SoundActionPresenter(SoundActionView view)
        {
            this.view = view;
        }

        private void OnAction()
        {
            view.PlaySound();
            view.NextDoAction();
        }

        public void Enable()
        {
            view.DoActionEvent += OnAction;
        }

        public void Disable()
        {
            view.DoActionEvent -= OnAction;
        }
    }
}