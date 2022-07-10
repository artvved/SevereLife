using System;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class PlayerModel
    {
        

        public Vector2 MovingDirection { get; set; }

        public float Speed { get; set; }

        public bool IsMoving { get; set; }

       

        public PlayerModel(float speed)
        {
            this.Speed = speed;
            this.IsMoving = false;
            MovingDirection = Vector2.left;
            
        }

       
    }
}