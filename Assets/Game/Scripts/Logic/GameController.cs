using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerView playerView;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float playerSpeed;
    [SerializeField] private RequirementView playerRequirementView;
    private PlayerModel playerModel;
    
    [Header("Level")]
    [SerializeField] private Level[] levels;
    private int curLevel = 0;
    
    [Header("Controller")]
    [SerializeField] private InputController inputController;
    private MoveController moveController;
    
    [Header("Entrance")]
    [SerializeField] private Entrance toInside;
    [SerializeField] private Entrance toOutside;
    

    public Entrance ToInside => toInside;
    public Entrance ToOutside => toOutside;


    private void InitFields()
    {
        playerModel = new PlayerModel(playerSpeed);
        moveController = new MoveController(playerView,playerModel);
    }

    private void InitLevel()
    {
        levels[curLevel].gameObject.SetActive(true);
    }

    void Start()
    {
        InitFields();
        InitLevel();
        
        //filling events
        inputController.HitEvent += hit2D =>
        {
            GameObject hitGO = hit2D.collider.gameObject;
            RequirementHolder requirementHolder =hitGO.GetComponent<RequirementHolder>();
            if (requirementHolder != null)
            {
                requirementHolder.RequirementView.Animator.SetTrigger("Show");
            }
            else
            {
                var pickable = hitGO.GetComponent<Pickable>();
                if (pickable!=null)
                {
                    //pick obj
                    Destroy(pickable.gameObject);
                }
            }
        };
      

    }

    private void PlayerMove(string animationTrigger,Vector2 direction)
    {
        if (!direction.Equals(playerModel.MovingDirection))
        {
            FlipPLayer();
        }
        playerModel.IsMoving = true;
        playerModel.MovingDirection = direction;
        playerAnimator.SetTrigger(animationTrigger);
    }

    private void FlipPLayer()
    {
        var scale =  playerView.transform.localScale;
        scale.x *= -1;
        playerView.transform.localScale = scale;
    }

    public void MoveLeft()
    {
        PlayerMove("Walk",Vector2.left);
    }
    public void MoveRight()
    {
        PlayerMove("Walk",Vector2.right);
    }

    public void StopMoving()
    {
        playerModel.IsMoving = false;
        playerAnimator.SetTrigger("Idle");
    }

    public void ShowPlayerReq()
    {
        playerRequirementView.Animator.SetTrigger("Show");
    }

    public void Enter()
    {
        GameObject[] toEnable;
        GameObject[] toDisable;
        if (toInside.gameObject.activeSelf)
        {
            toEnable = toInside.ToEnable;
            toDisable = toInside.ToDisable;
            toInside.gameObject.SetActive(false);
            playerView.transform.position = toOutside.SpawnPoint.transform.position;
        }
        else
        {
            toEnable = toOutside.ToEnable;
            toDisable = toOutside.ToDisable;
            toOutside.gameObject.SetActive(false);
            playerView.transform.position = toInside.SpawnPoint.transform.position;
        }

        foreach (var o in toDisable)
        {
            o.SetActive(false);
        }
        foreach (var o in toEnable)
        {
            o.SetActive(true);
        }
    }


    void FixedUpdate()
    {
        if (playerModel.IsMoving)
        {
            moveController.MovePlayer();
        }
    }
}
