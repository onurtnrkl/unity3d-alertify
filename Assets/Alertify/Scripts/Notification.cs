using System.Collections;
using UnityEngine;

namespace Alertify
{
    public sealed class Notification : MonoBehaviour
	{
        private static Notification instance;

        private Pool pool;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                pool = new Pool(transform, 10);
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
            IEnumerator notify = instance.Notify(message, Color.gray);

            instance.StartCoroutine(notify);
        }

        public static void Success(string message)
        {
            IEnumerator notify = instance.Notify(message, Color.green);

            instance.StartCoroutine(notify);
        }

        public static void Error(string message)
        {
            IEnumerator notify = instance.Notify(message, Color.red);

            instance.StartCoroutine(notify);
        }

        public static void Warning(string message)
        {
            IEnumerator notify = instance.Notify(message, Color.yellow);

            instance.StartCoroutine(notify);
        }
	}   
}