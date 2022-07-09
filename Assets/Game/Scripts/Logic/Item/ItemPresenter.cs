namespace Game.Scripts.Logic
{
    public class ItemPresenter : IPresenter
    {
        private ItemView itemView;
        private ItemModel itemModel;

        public ItemPresenter( ItemView itemView,ItemModel itemModel)
        {
            this.itemView = itemView;
            this.itemModel = itemModel;
        }

        private void OnTap()
        {
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