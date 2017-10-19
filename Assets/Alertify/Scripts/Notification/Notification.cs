using System.Collections;
using UnityEngine;

namespace Alertify
{
    public sealed class Notification : MonoBehaviour
	{
        private static Notification instance;

        private Pool pool;
        private NotificationSettings settings;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                settings = Resources.Load<Settings>("AlertifySettings").NotificationSettings;
                pool = new Pool(transform, settings.PoolSize);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        IEnumerator Notify(string message, Color color)
        {
            Notify notify = pool.GetNotify();
            float duration = settings.Duration;

            notify.SetText(message);
            notify.SetColor(color);

            yield return new WaitForSeconds(duration);

            pool.AddNotify(notify);
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