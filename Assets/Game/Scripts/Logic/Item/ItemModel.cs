namespace Game.Scripts.Logic
{
    public class ItemModel
    {
        private ItemName itemName;
        private MergeName mergeName;
        private  int level;

        public ItemName ItemName => itemName;

        public MergeName MergeName => mergeName;

        public int Level => level;

        public ItemModel(ItemName itemName, MergeName mergeName, int level)
        {
            this.itemName = itemName;
            this.mergeName = mergeName;
            this.level = level;
        }

        
    }
}