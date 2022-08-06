using Game.Scripts.Logic.Mode;

namespace Game.Scripts.Logic
{
    public class LevelController
    {
        private int curLevel = -1;
        private LevelView[] levels;

        private InventoryController inventoryController;
        private PlayerView playerView;
        private CircleSpawner circleSpawner;
        private AdController adController;

        public LevelController(LevelView[] levels, InventoryController inventoryController, PlayerView playerView, CircleSpawner circleSpawner, AdController adController)
        {
            this.levels = levels;
            this.inventoryController = inventoryController;
            this.playerView = playerView;
            this.circleSpawner = circleSpawner;
            this.adController = adController;
        }

        public void InitNewLevel()
        {   
            curLevel++;
            var l=levels[curLevel];
            l.InitItems(inventoryController);
            l.InitReqs(inventoryController);
            l.InitDialogTriggers(inventoryController,playerView);
            l.InitDealDialogTriggers(inventoryController,playerView);
            l.InitCircleModes(circleSpawner);
            l.InitDestroyModes(inventoryController);
            l.InitNearInteractableViews(playerView,inventoryController);
            l.InitWaitModes(playerView,inventoryController);
            l.InitLevelChangers(this,playerView,adController);
            l.InitPlayerShowers(playerView);
            l.PlacePlayer(playerView);
            l.SetupCamera();
            l.gameObject.SetActive(true);
            if (curLevel!=0)
            {
                levels[curLevel-1].gameObject.SetActive(false);
            }
            
        }
    }
}