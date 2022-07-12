namespace Game.Scripts.Logic
{
    public class ItemMerger
    {
        private ItemModel[] items;

        public ItemMerger()
        {
            items = new[]
            {
                new ItemModel(ItemName.SCYTHE,MergeName.SCYTHE_PART,1),
                new ItemModel(ItemName.BLADE,MergeName.SCYTHE_PART,0),
                new ItemModel(ItemName.STICK,MergeName.SCYTHE_PART,0)
            };
        }

        public bool CanMerge(ItemModel m1, ItemModel m2)
        {
            //mergename && level are equal and mergable
            if (m1.MergeName.Equals(m2.MergeName)&& !m1.MergeName.Equals(MergeName.NOTHING) && m1.Level.Equals(m2.Level))
            {
                return true;
            }else return false;
        }

        public ItemModel Merge(ItemModel m1, ItemModel m2)
        {
            if (CanMerge(m1,m2))
            {
                int newLvl = m1.Level + 1;
                return GetNewItem(m1.MergeName, newLvl);
            }

            return null;

        }


        private ItemModel GetNewItem(MergeName mergeName, int lvl)
        {
            foreach (var item in items)
            {
                if (item.MergeName.Equals(mergeName) && item.Level.Equals(lvl))
                {
                    return item;
                }
            }

            return null;
        }
    }
}