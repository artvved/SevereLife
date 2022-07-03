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
    

    private MoveController moveController;
    private PlayerModel playerModel;

    private void InitFields()
    {
        playerModel = new PlayerModel(playerSpeed);
        moveController = new MoveController(playerView,playerModel);
    }

    void Start()
    {
        InitFields();
        
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


    void FixedUpdate()
    {
        if (playerModel.IsMoving)
        {
            moveController.MovePlayer();
        }
    }
}
