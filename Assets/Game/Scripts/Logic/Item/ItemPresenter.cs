using Game.Scripts.UI;

namespace Game.Scripts.Logic
{
    public class ItemPresenter : IPresenter
    {
        private ItemView itemView;
        private ItemModel itemModel;
        private InventoryController inventoryController;
     

        public ItemPresenter( ItemView itemView,ItemModel itemModel,InventoryController inventoryController)
        {
            this.itemView = itemView;
            this.itemModel = itemModel;
            this.inventoryController = inventoryController;
        }

        private void OnTap()
        {
            inventoryController.AddItem(itemModel.ItemName);
            Disable();
            itemView.Destroy();
        }
        

        public void Enable()
        {
            itemView.TapEvent += OnTap;
        }

        public void Disable()
        {
            itemView.TapEvent -= OnTap;
        }
    }
}