using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerView playerView;
    [SerializeField] private float playerSpeed;
    private PlayerPresenter playerPresenter;
    private PlayerModel playerModel;
    [SerializeField] private RequirementView playerRequirementView;
    private RequirementModel playerRequirementModel;
    private RequirementPresenter playerRequirementPresenter;

    [Header("Level")]
    [SerializeField] private LevelController[] levels;
    private int curLevel = 0;
    
  
    
    [Header("Entrance")]
    [SerializeField] private EntranceView toInside;

    private EntrancePresenter inEntrancePresenter;
    [SerializeField] private EntranceView toOutside;
    private EntrancePresenter outEntrancePresenter;
    

    public EntranceView ToInside => toInside;
    public EntranceView ToOutside => toOutside;


    private void InitFields()
    {
        playerModel = new PlayerModel(playerSpeed);
        playerPresenter = new PlayerPresenter(playerView, playerModel);
        playerPresenter.Enable();
        
        playerRequirementModel = new RequirementModel(playerRequirementView.ItemName);
        playerRequirementPresenter = new RequirementPresenter(playerRequirementView, playerRequirementModel);
        playerRequirementPresenter.Enable();

        inEntrancePresenter = new EntrancePresenter(toInside);
        inEntrancePresenter.Enable();
        
        outEntrancePresenter = new EntrancePresenter(toOutside);
        outEntrancePresenter.Enable();

    }

    private void InitLevel()
    {
        levels[curLevel].gameObject.SetActive(true);
    }

    void Start()
    {
        InitFields();
        InitLevel();
    }

    public void Enter()
    {
        if (toInside.gameObject.activeSelf)
        {
            inEntrancePresenter.Enter(playerView);
        }
        else
        {
            outEntrancePresenter.Enter(playerView);
        }
    }

    public void MoveLeft()
    {
        playerPresenter.MoveLeft();
    }
    public void MoveRight()
    {
        playerPresenter.MoveRight();
    }

    public void StopMoving()
    {
        playerPresenter.StopMoving();
    }

    public void ShowPlayerReq()
    {
        playerRequirementView.ShowRequirement();
    }

    


    void FixedUpdate()
    {
        if (playerModel.IsMoving)
        {
            playerPresenter.MovePlayer();
        }
    }
}
