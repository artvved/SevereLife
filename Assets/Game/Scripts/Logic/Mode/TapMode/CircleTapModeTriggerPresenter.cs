using Game.Scripts.Logic.Mode;

namespace Game.Scripts.Logic
{
    public class CircleTapModeTriggerPresenter : IPresenter
    {
        private CircleTapModeTriggerView circleTapModeTriggerView;
       
        private InventoryController inventoryController;
        private CircleSpawner circleSpawner;

        public CircleTapModeTriggerPresenter(CircleTapModeTriggerView circleTapModeTriggerView,  InventoryController inventoryController, CircleSpawner circleSpawner)
        {
            this.circleTapModeTriggerView = circleTapModeTriggerView;
           
            this.inventoryController = inventoryController;
            this.circleSpawner = circleSpawner;
        }

        private void OnModeTrigger()
        {
            circleSpawner.StartSpawn(circleTapModeTriggerView);
        }
        
        
        private void OnDestroy()
        {
            Disable();
            if (circleTapModeTriggerView.NextInSequence == null && circleTapModeTriggerView.RewardItemModel != null)
            {
                //inventoryController.RemoveItem();
                inventoryController.AddItem(circleTapModeTriggerView.RewardItemModel);
            }
            else
            {
                circleTapModeTriggerView.NextInSequence.ActivateSelf();
            }
        }

        
        
        public void Enable()
        {
            circleTapModeTriggerView.ModeEvent += OnModeTrigger;
            circleTapModeTriggerView.DeathEvent += OnDestroy;
        }

        public void Disable()
        {
            circleTapModeTriggerView.ModeEvent -= OnModeTrigger;
            circleTapModeTriggerView.DeathEvent -= OnDestroy;
        }
    }
}