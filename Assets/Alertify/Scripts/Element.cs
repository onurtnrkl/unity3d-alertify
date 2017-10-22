using UnityEngine;

namespace Alertify
{
    public abstract class Element : MonoBehaviour
    {
        public void FadeIn()
        {
            //TODO: Add fade in animation.
            gameObject.SetActive(true);
        }

        public void FadeOut()
        {
            //TODO: Add fade out animation.
            gameObject.SetActive(false);
        }
    }
}
