using UnityEngine;

namespace Alertify
{
    public class Loader : MonoBehaviour
    {
        private static Loader instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
