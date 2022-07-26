using System;
using Game.Scripts.Logic.Destroy;
using Game.Scripts.Logic.Dialog;
using Game.Scripts.Logic.Mode;
using Game.Scripts.Logic.Mode.LevelChanger;
using Game.Scripts.Logic.NearInteractable;
using Game.Scripts.Logic.Terrain;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class LevelView : MonoBehaviour
    {
        [Header("Items")] [SerializeField] private ItemView[] itemViews;


        [Header("Requirements")] [SerializeField]
        private RequirementView[] requirementViews;


        [Header("Dialogs")] [SerializeField] private DialogTriggerView[] dialogViews;

        [Header("Circle tap Views")] [SerializeField] private CircleTapModeTriggerView[] modeViews;
        [Header("Destroy Views")] [SerializeField] private DestroyActionView[] destroyActionViews;

        [Header("NearInteractableViews")] [SerializeField]
        private NearInteractableView[] nearInteractableViews;

        [Header("WaitModeViews")] [SerializeField]
        private WaitModeView[] waitModeViews;

        [Header("LevelChangeModeView")] [SerializeField]
        private LevelChangeModeView[] levelChangeModeViews;
        
        [Header("Player controls showers")] [SerializeField]
        private ControlsShowerView[] controlsShowerViews;

        [Header("Player place")] [SerializeField]
        private Transform startPos;

        [SerializeField] private Vector2 direction;
        
        [Header("Player place")] [SerializeField]
        private Transform cameraTarget;
        [SerializeField]  private Transform leftBorder;
        [SerializeField]  private Transform rightBorder;


        public void SetupCamera()
        {
            var cam=Camera.main.GetComponent<FollowCamera>(); 
            cam.Setup(cameraTarget,leftBorder,rightBorder);
        }

        public void InitItems(InventoryController inventoryController)
        {
            for (int i = 0; i < itemViews.Length; i++)
            {
                var view = itemViews[i];
                ItemModel m = new ItemModel(view.ItemName, view.MergeName, view.Level);
                ItemPresenter p = new ItemPresenter(view, m, inventoryController);
                p.Enable();
            }
        }

        public void InitReqs(InventoryController inventoryController)
        {
            for (int i = 0; i < requirementViews.Length; i++)
            {
                var view = requirementViews[i];
                RequirementModel m = new RequirementModel(view.ItemName);
                RequirementPresenter rp = new RequirementPresenter(view, m, inventoryController);
                rp.Enable();
            }
        }

        public void InitDialogTriggers(InventoryController inventoryController, PlayerView playerView)
        {
            for (int i = 0; i < dialogViews.Length; i++)
            {
                var view = dialogViews[i];

                DialogTriggerPresenter p = new DialogTriggerPresenter(view, inventoryController, playerView);
                p.Enable();
            }
        }
        public void InitPlayerShowers(PlayerView playerView)
        {
            for (int i = 0; i < controlsShowerViews.Length; i++)
            {
                var view = controlsShowerViews[i];

                ControlsShowerPresenter p = new ControlsShowerPresenter(view,  playerView);
                p.Enable();
            }
        }

        public void InitCircleModes( CircleSpawner circleSpawner)
        {
            for (int i = 0; i < modeViews.Length; i++)
            {
                var view = modeViews[i];

                CircleTapModeTriggerPresenter p =
                    new CircleTapModeTriggerPresenter(view, circleSpawner);
                p.Enable();
            }
        }
        
        public void InitDestroyModes( InventoryController inventoryController)
        {
            for (int i = 0; i < destroyActionViews.Length; i++)
            {
                var view = destroyActionViews[i];

                DestroyActionPresenter p =
                    new DestroyActionPresenter(view, inventoryController);
                p.Enable();
            }
        }

        public void InitNearInteractableViews(PlayerView playerView, InventoryController inventoryController)
        {
            for (int i = 0; i < nearInteractableViews.Length; i++)
            {
                var view = nearInteractableViews[i];

                NearInteractablePresenter p = new NearInteractablePresenter(view, playerView, inventoryController);
                p.Enable();
            }
        }

        public void InitWaitModes(PlayerView playerView, InventoryController inventoryController)
        {
            for (int i = 0; i < waitModeViews.Length; i++)
            {
                var view = waitModeViews[i];

                WaitModePresenter p = new WaitModePresenter(view, playerView, inventoryController);
                p.Enable();
            }
        }

        public void InitLevelChangers(LevelController levelController, PlayerView playerView)
        {
            for (int i = 0; i < levelChangeModeViews.Length; i++)
            {
                var view = levelChangeModeViews[i];

                LevelChangeModePresenter p = new LevelChangeModePresenter(view, levelController, playerView);
                p.Enable();
            }
        }

        public void PlacePlayer(PlayerView playerView)
        {
            playerView.transform.position = startPos.position;
            playerView.transform.SetParent(startPos.parent);
            playerView.OnTurn(direction);
        }
    }
}