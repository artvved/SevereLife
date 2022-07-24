using UnityEngine;

namespace Game.Scripts.Logic.Mode.Move
{
    public abstract  class Effect : MonoBehaviour
    {
        public abstract void StartEffect();
        public abstract void StopEffect();
    }
}