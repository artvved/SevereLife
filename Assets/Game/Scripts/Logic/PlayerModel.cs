using UnityEngine;

namespace Game.Scripts.Logic
{
    public class PlayerModel
    {
        private float speed;
        private bool isMoving;
        private Vector2 movingDirection;

        public Vector2 MovingDirection
        {
            get => movingDirection;
            set => movingDirection = value;
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public bool IsMoving
        {
            get => isMoving;
            set => isMoving = value;
        }

        public PlayerModel(float speed)
        {
            this.speed = speed;
            this.isMoving = false;
            movingDirection = Vector2.left;
        }
    }
}