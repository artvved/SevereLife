using Game.Scripts.Logic.Mode;

namespace Game.Scripts.Logic
{
    public class CircleTapModePresenter : IPresenter
    {
        private CircleTapModeView circleTapModeView;
        private PlayerView playerView;
        private InventoryController inventoryController;
        private CircleSpawner circleSpawner;

        public CircleTapModePresenter(CircleTapModeView circleTapModeView, PlayerView playerView, InventoryController inventoryController, CircleSpawner circleSpawner)
        {
            this.circleTapModeView = circleTapModeView;
            this.playerView = playerView;
            this.inventoryController = inventoryController;
            this.circleSpawner = circleSpawner;
        }

        private void OnTap()
        {
            playerView.OnShowHideControls();
            playerView.OnGoTo(circleTapModeView.StartPosition.transform);
            circleSpawner.StartSpawn(circleTapModeView);
        }
        
        
        private void OnDestroy()
        {
            Disable();
            if (circleTapModeView.NextInSequence == null && circleTapModeView.RewardItemModel != null)
            {
                //inventoryController.RemoveItem();
                inventoryController.AddItem(circleTapModeView.RewardItemModel);
            }
            else
            {
                circleTapModeView.NextInSequence.ActivateSelf();
            }
        }

        
        
        public void Enable()
        {
            circleTapModeView.TapEvent += OnTap;
            circleTapModeView.DeathEvent += OnDestroy;
        }

        public void Disable()
        {
            circleTapModeView.TapEvent -= OnTap;
            circleTapModeView.DeathEvent -= OnDestroy;
        }
    }
}