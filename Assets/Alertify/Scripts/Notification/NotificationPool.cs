using System.Collections.Generic;
using UnityEngine;

namespace Alertify
{
    public sealed class NotificationPool
    {
        private readonly GameObject prefab;
        private readonly Queue<NotificationElement> objects;

        /// <summary>
        /// Creates pool for notification elements.
        /// </summary>
        /// <param name="parent">Parent transform of pool.</param>
        /// <param name="amount">Pool size.</param>
        public NotificationPool(Transform parent, int amount)
        {
            prefab = Resources.Load<GameObject>("Prefabs/NotificationElement");
            objects = new Queue<NotificationElement>();

            for (int i = 0; i < amount; i++)
            {
                NotificationElement element = Object.Instantiate(prefab, parent).GetComponent<NotificationElement>();

                AddElement(element);
            }
        }

        public NotificationElement GetElement()
        {
            NotificationElement element = objects.Dequeue();

            element.FadeIn();

            return element;
        }

        public void AddElement(NotificationElement element)
        {
            element.FadeOut();
            objects.Enqueue(element);
        }
    }
}