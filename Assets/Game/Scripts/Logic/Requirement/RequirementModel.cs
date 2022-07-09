namespace Game.Scripts.Logic
{
    public class RequirementModel
    {
        private ItemName itemName;

        public ItemName ItemName => itemName;

        public RequirementModel(ItemName itemName)
        {
            this.itemName = itemName;
        }
    }
}