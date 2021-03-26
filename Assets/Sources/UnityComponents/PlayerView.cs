using UnityEngine;

namespace MarsRunner
{
    public class PlayerView : GameView
    {
        private Animator _animator;
        
        public Animator Animator
        {
            get
            {
                if (!_animator) _animator = GetComponent<Animator>();
                return _animator;
            }    
        }
    }
}