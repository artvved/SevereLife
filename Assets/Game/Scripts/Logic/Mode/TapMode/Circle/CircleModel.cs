namespace Game.Scripts.Logic.Mode
{
    public class CircleModel
    {
        private bool isFinal;

        public CircleModel(bool isFinal)
        {
            this.isFinal = isFinal;
        }

        public bool IsFinal => isFinal
        ;
    }
}