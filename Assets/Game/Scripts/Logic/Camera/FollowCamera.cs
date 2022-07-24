using System;
using UnityEngine;

namespace Game.Scripts.Logic
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;

        [SerializeField] private Transform target;
        
        [SerializeField] private Camera camera;

        [Header("Borders")] 
        [SerializeField] private Transform leftBorder;
        [SerializeField] private Transform rightBorder;

        private float leftX;
        private float rightX;
        private float cameraWidth;

        public Transform Target
        {
            get => target;
            set => target = value;
        }

        private void Start()
        {
            cameraWidth = camera.orthographicSize * Screen.width / Screen.height;
            leftX = leftBorder.position.x+cameraWidth;
            rightX = rightBorder.position.x-cameraWidth;
        }

     

        private void Update()
        {
            if (target != null)
            {
                var targetPosition = target.position;
                targetPosition.x = Mathf.Clamp(target.position.x, leftX, rightX);
                var position = transform.position;
                targetPosition.y = position.y;
                targetPosition.z = position.z;
                position = targetPosition ;
                transform.position = position;
            }
        }
    }
}