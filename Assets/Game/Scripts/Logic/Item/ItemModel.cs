namespace Game.Scripts.Logic
{
    public class ItemModel
    {
        private ItemName itemName;

        public ItemName ItemName => itemName;

        public ItemModel(ItemName itemName)
        {
            this.itemName = itemName;
        }
    }
}