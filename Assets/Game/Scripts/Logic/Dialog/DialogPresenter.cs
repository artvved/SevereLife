namespace Game.Scripts.Logic.Dialog
{
    public class DialogPresenter : IPresenter
    {
        private DialogView dialogView;
        private InventoryController inventoryController;


        public DialogPresenter(DialogView dialogView, InventoryController inventoryController)
        {
            this.dialogView = dialogView;
            this.inventoryController = inventoryController;
        }

        private void OnTap()
        {
            dialogView.ShowDialog();
        }

        public void Enable()
        {
            dialogView.TapEvent += OnTap;
        }

        public void Disable()
        {
            dialogView.TapEvent -= OnTap;
        }
    }
}