using System.Collections;
using UnityEngine;

namespace Alertify
{
    public sealed class Notification : MonoBehaviour
	{
        private static Notification instance;

        private NotificationPool pool;
        private NotificationSettings settings;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                Init();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Init()
        {
            settings = Settings.Instance.NotificationSettings;
            pool = new NotificationPool(transform, settings.PoolSize);
        }

        IEnumerator Notify(string message, Color color)
        {
            NotificationElement element = pool.GetElement();
            float duration = settings.Duration;

            element.SetText(message);
            element.SetColor(color);

            yield return new WaitForSeconds(duration);

            pool.AddElement(element);
        }

        public static void Message(string message)
        {
            IEnumerator notify = instance.Notify(message, instance.settings.MessageColor);

            instance.StartCoroutine(notify);
        }

        public static void Success(string message)
        {
            IEnumerator notify = instance.Notify(message, instance.settings.SuccessColor);

            instance.StartCoroutine(notify);
        }

        public static void Error(string message)
        {
            IEnumerator notify = instance.Notify(message, instance.settings.ErrorColor);

            instance.StartCoroutine(notify);
        }

        public static void Warning(string message)
        {
            IEnumerator notify = instance.Notify(message, instance.settings.WarningColor);

            instance.StartCoroutine(notify);
        }
	}   
}