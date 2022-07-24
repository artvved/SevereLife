using System;
using System.Collections;
using Game.Scripts.Logic.Mode.Quest;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Move
{
    public class MoveActionView: QuestAction
    {
        [SerializeField] private Transform target;
        [SerializeField] private GameObject movable;
        [SerializeField] private float time;
        

        private Effect[] effects;

        private void Awake()
        {
            effects=GetComponentsInChildren<Effect>();
            MoveActionPresenter moveActionPresenter = new MoveActionPresenter(this);
            moveActionPresenter.Enable();
           
        }

        public void PlayEffects()
        {
            foreach (var ef in effects)
            {
                ef.StartEffect();
            }
        }



        public event Action FinishMoveEvent;
        public IEnumerator GoToTarget()
        {
          
            var startPos = movable.transform.position;
            var targetPos = target.position;
            targetPos.y = movable.transform.position.y;
            for (float i = 0; i < 1; i+=Time.deltaTime/time)
            {
                movable.transform.position = Vector3.Lerp(startPos, targetPos, i);
                yield return null;
            }

            movable.transform.position = targetPos;
            FinishMoveEvent?.Invoke();
        }



    }
}