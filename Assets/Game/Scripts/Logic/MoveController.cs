using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Logic;
using UnityEngine;

public class MoveController
{
    private PlayerView playerView;
    private PlayerModel playerModel;

    public MoveController(PlayerView playerView, PlayerModel playerModel)
    {
        this.playerView = playerView;
        this.playerModel = playerModel;
    }

    public void MovePlayer()
    {
        playerView.transform.Translate(playerModel.MovingDirection.normalized * playerModel.Speed);
    }
}