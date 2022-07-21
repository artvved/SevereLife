using Game.Scripts.Logic.Mode;

namespace Game.Scripts.Logic
{
    public class LevelController
    {
        private LevelView[] levels;
        private int curLevel = -1;

        private InventoryController inventoryController;
        private PlayerView playerView;
        private CircleSpawner circleSpawner;

        public LevelController(LevelView[] levels, InventoryController inventoryController, PlayerView playerView, CircleSpawner circleSpawner)
        {
            this.levels = levels;
            this.inventoryController = inventoryController;
            this.playerView = playerView;
            this.circleSpawner = circleSpawner;
        }

        public void InitNewLevel()
        {   //
            curLevel = 0;
            //
            curLevel++;
            var l=levels[curLevel];
            l.InitItems(inventoryController);
            l.InitReqs(inventoryController);
            l.InitDialogTriggers(inventoryController,playerView);
            l.InitCircleModes(inventoryController,circleSpawner);
            l.InitNearInteractableViews(playerView,inventoryController);
            l.InitWaitModes(playerView,inventoryController);
            l.InitLevelChangers(this,playerView);
            l.PlacePlayer(playerView);
            l.gameObject.SetActive(true);
            if (curLevel!=0)
            {
                levels[curLevel-1].gameObject.SetActive(false);
            }
            
        }
    }
}