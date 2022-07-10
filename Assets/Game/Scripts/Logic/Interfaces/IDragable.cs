using System;

namespace Game.Scripts.Logic
{
    public interface IDragable
    
    {
        event Action DragEvent;

        void OnDrag();
    }
}