using Game.Scripts.Logic.Audio;
using UnityEngine;

namespace Game.Scripts.Logic.Terrain
{
    public class VisualEffect : MonoBehaviour

    {
        [SerializeField] private Animator wheelAnimator;
        [SerializeField] private SoundView soundView;
        
        
        public void StartAnimation()
        {
            soundView.Play();
            wheelAnimator.SetTrigger("Spin");
        }

        public void StopAnimation()
        {
            wheelAnimator.SetTrigger("Idle");
        }
    }
}