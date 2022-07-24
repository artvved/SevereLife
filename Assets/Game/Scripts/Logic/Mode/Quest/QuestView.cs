using System;
using Game.Scripts.Logic.Mode.Quest;
using UnityEngine;

namespace Game.Scripts.Logic.Sequence
{
    public class QuestView : MonoBehaviour,ITapable
    {
        [SerializeField] private QuestAction[] actions;
        
        public QuestAction[] Actions => actions;

        private QuestPresenter presenter;
        private Collider2D col;

        private void Awake()
        {
            presenter = new QuestPresenter(this);
            presenter.Enable();
            col = GetComponent<Collider2D>();
        }

        public event Action TapEvent;
        public void OnTap()
        {
            TapEvent?.Invoke();
        }

        public void DisableCollider()
        {
            if (col!=null)
            {
                col.enabled=false;
            }
           
        }
    }
}