using UnityEngine;

namespace MarsRunner
{
    public class ObstacleView : MonoBehaviour
    {
        private bool _hasHit;
        public bool HasHit
        {
            get
            {
                if (_hasHit)
                {
                    _hasHit = false;
                    return true;
                }
                
                return false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerView>())
            {
                _hasHit = true;
            }
        }
    }
}