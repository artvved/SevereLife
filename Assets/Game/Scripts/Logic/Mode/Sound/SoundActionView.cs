using System;
using Game.Scripts.Logic.Audio;
using Game.Scripts.Logic.Mode.Quest;
using UnityEngine;

namespace Game.Scripts.Logic.Mode.Sound
{
    [RequireComponent(typeof(SoundEffect))]
    public class SoundActionView : QuestAction
    {
        private SoundEffect soundEffect;

        private void Start()
        {
            soundEffect = GetComponent<SoundEffect>();
            SoundActionPresenter presenter = new SoundActionPresenter(this);
            presenter.Enable();
        }

        public void PlaySound()
        {
            soundEffect.StartEffect();
        }
    }
}