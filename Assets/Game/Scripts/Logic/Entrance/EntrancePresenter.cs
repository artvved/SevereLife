using UnityEngine;

namespace Game.Scripts.Logic
{
    public class EntrancePresenter : IPresenter
    {
        private EntranceView view;

        public EntrancePresenter(EntranceView view)
        {
            this.view = view;
        }

        public void Enable()
        {
            
        }

        public void Disable()
        {
            
        }
        
        

        public void Enter(PlayerView playerView)
        {
            view.gameObject.SetActive(false);
            playerView.transform.position = view.SpawnPoint.transform.position;

            foreach (var o in view.ToDisable)
            {
                o.SetActive(false);
            }

            foreach (var o in view.ToEnable)
            {
                o.SetActive(true);
            }
        }
    }
}