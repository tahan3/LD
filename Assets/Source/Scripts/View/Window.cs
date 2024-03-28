using UnityEngine;

namespace Source.Scripts.View
{
    public class Window : AWindow
    {
        [SerializeField] protected Canvas canvas;
        
        public override void Open()
        {
            canvas.enabled = true;
        }

        public override void Close()
        {
            canvas.enabled = false;
        }
    }
}