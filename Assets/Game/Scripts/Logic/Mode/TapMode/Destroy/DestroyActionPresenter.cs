namespace Game.Scripts.Logic.Destroy
{
    public class DestroyActionPresenter : IPresenter
    {
        private DestroyActionView view;
        private InventoryController inventoryController;

        public DestroyActionPresenter(DestroyActionView view, InventoryController inventoryController)
        {
            this.view = view;
            this.inventoryController = inventoryController;
        }

        private void OnAction()
        {
            
            if (view.RewardItemModel != null)
            {
                inventoryController.AddItem(view.RewardItemModel);
            } 
            view.VisualDestroy();
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