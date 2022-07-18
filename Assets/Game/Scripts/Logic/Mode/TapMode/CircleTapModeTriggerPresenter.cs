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

        private void OnDoAction()
        {
            circleSpawner.StartSpawn(circleTapModeTriggerView);
        }
        
        
        private void OnDestroy()
        {
            Disable();
            if (circleTapModeTriggerView.RewardItemModel != null)
            {
                inventoryController.AddItem(circleTapModeTriggerView.RewardItemModel);
            }
            else
            {
                circleTapModeTriggerView.OnNext();
            }
        }

        
        
        public void Enable()
        {
            circleTapModeTriggerView.DoActionEvent += OnDoAction;
            circleTapModeTriggerView.DeathEvent += OnDestroy;
        }

        public void Disable()
        {
            circleTapModeTriggerView.DoActionEvent -= OnDoAction;
            circleTapModeTriggerView.DeathEvent -= OnDestroy;
        }
    }
}