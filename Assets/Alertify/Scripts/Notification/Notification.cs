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

        IEnumerator Notify(string text, Color color)
        {
            NotificationElement element = pool.GetElement();
            float duration = settings.Duration;

            element.SetText(text);
            element.SetColor(color);

            yield return new WaitForSeconds(duration);

            pool.AddElement(element);
        }

        /// <summary>
        /// Creates notification with message color.
        /// </summary>
        /// <param name="text">Message text.</param>
        public static void Message(string text)
        {
            IEnumerator notify = instance.Notify(text, instance.settings.MessageColor);

            instance.StartCoroutine(notify);
        }

        /// <summary>
        /// Creates notification with success color.
        /// </summary>
        /// <param name="text">Message text.</param>
        public static void Success(string text)
        {
            IEnumerator notify = instance.Notify(text, instance.settings.SuccessColor);

            instance.StartCoroutine(notify);
        }

        /// <summary>
        /// Creates notification with error color.
        /// </summary>
        /// <param name="text">Message text.</param>
        public static void Error(string text)
        {
            IEnumerator notify = instance.Notify(text, instance.settings.ErrorColor);

            instance.StartCoroutine(notify);
        }

        /// <summary>
        /// Creates notification with warning color.
        /// </summary>
        /// <param name="text">Message text.</param>
        public static void Warning(string text)
        {
            IEnumerator notify = instance.Notify(text, instance.settings.WarningColor);

            instance.StartCoroutine(notify);
        }
	}   
}