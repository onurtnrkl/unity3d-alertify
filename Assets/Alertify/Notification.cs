using UnityEngine;

namespace Alertify
{
    public sealed class Notification : MonoBehaviour
	{
        private static Notification instance;

		private void Awake()
		{
			if (instance != null && instance != this)
			{
				Destroy(gameObject);
			}
			else
			{
				instance = this;
			}

			//FIXME: DontDestroyOnLoad only work for root GameObjects or components on root GameObjects.
			DontDestroyOnLoad(gameObject);
		}

        private void Notify(string message, Color color)
        {
            
        }

        public static void Message(string message)
        {
            instance.Notify(message, Color.gray);
        }

        public static void Success(string message)
        {
            instance.Notify(message, Color.green);
        }

        public static void Error(string message)
        {
            instance.Notify(message, Color.red);
        }

        public static void Warning(string message)
        {
            instance.Notify(message, Color.yellow);
        }
	}   
}