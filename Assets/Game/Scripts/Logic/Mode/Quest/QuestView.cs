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

        private void Awake()
        {
            presenter = new QuestPresenter(this);
            presenter.Enable();
        }

        public event Action TapEvent;
        public void OnTap()
        {
            TapEvent?.Invoke();
        }
    }
}