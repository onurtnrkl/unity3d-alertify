using System.Collections;
using UnityEngine;

namespace Alertify
{
    public sealed class Notification : MonoBehaviour
	{
        private static Notification instance;

        private Pool pool;
        private Settings settings;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
               
                pool = new Pool(transform, Settings.GetPoolSize());
            }
            else
            {
                Destroy(gameObject);
            }
        }

        IEnumerator Notify(string message, Color color)
        {
            Notify notify = pool.GetNotify();

            notify.SetText(message);
            notify.SetColor(color);

            yield return new WaitForSeconds(5);

            pool.AddNotify(notify);
        }

        public static void Message(string message)
        {
            IEnumerator notify = instance.Notify(message, Settings.GetMessageColor());

            instance.StartCoroutine(notify);
        }

        public static void Success(string message)
        {
            IEnumerator notify = instance.Notify(message, Settings.GetSuccessColor());

            instance.StartCoroutine(notify);
        }

        public static void Error(string message)
        {
            IEnumerator notify = instance.Notify(message, Settings.GetErrorColor());

            instance.StartCoroutine(notify);
        }

        public static void Warning(string message)
        {
            IEnumerator notify = instance.Notify(message, Settings.GetWarningColor());

            instance.StartCoroutine(notify);
        }
	}   
}