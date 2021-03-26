using UnityEngine;

namespace MarsRunner
{
    public class UIScreen : MonoBehaviour
    {
        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}