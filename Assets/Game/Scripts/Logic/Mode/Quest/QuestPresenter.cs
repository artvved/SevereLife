using System;
using Game.Scripts.Logic.Mode.Quest;

namespace Game.Scripts.Logic.Sequence
{
    public class QuestPresenter : IPresenter
    {
        private QuestView questView;
        private QuestAction[] actions;

        public QuestPresenter(QuestView questView)
        {
            this.questView = questView;
            actions = questView.Actions;
        }

        private void ActiveDoAction()
        {
            foreach (var el in actions)
            {
                if (el.IsActive)
                {
                    el.DoAction();
                    return;
                }
            }
        }

        public void Enable()
        {
            questView.TapEvent += ActiveDoAction;
            
            for (int i = 0; i < actions.Length; i++)
            {
                var el = actions[i];
                
                
                
                if (i!=actions.Length-1)
                {
                    var i1 = i;
                    el.NextEvent += () =>
                    {
                        el.IsActive = false;
                        actions[i1 + 1].IsActive = true;
                    };
                    
                    el.NextDoActionEvent+= () =>
                    {
                        el.IsActive = false;
                        actions[i1 + 1].IsActive = true;
                        actions[i1 + 1].DoAction();
                    };
                }

                 
                if (i!=0)
                {
                    var i1 = i;
                    el.BackEvent += () =>
                    {
                        el.IsActive = false;
                        actions[i1 - 1].IsActive = true;
                    };
                }

                if (i==0)
                {
                    el.IsActive = true;
                }
               


            }
        }

        private void OnNext()
        {
            
        }



        public void Disable()
        {
           
        }
    }
}