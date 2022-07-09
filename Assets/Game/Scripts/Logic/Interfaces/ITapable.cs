using System;

namespace Game.Scripts.Logic
{
    public interface ITapable
    {
        event Action TapEvent;

        void OnTap();
    }
}