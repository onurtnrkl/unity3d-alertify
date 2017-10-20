using System.Collections.Generic;
using UnityEngine;

namespace Alertify
{
    public sealed class Pool
    {
        private readonly GameObject prefab;
        private readonly Queue<NotificationElement> objects;

        public Pool(Transform parent, int amount)
        {
            prefab = Resources.Load<GameObject>("Prefabs/NotificationElement");
            objects = new Queue<NotificationElement>();

            for (ushort i = 0; i < amount; i++)
            {
                NotificationElement notify = Object.Instantiate(prefab, parent).GetComponent<NotificationElement>();

                AddElement(notify);
            }
        }

        public NotificationElement GetElement()
        {
            NotificationElement notify = objects.Dequeue();

            notify.FadeIn();

            return notify;
        }

        public void AddElement(NotificationElement element)
        {
            element.FadeOut();
            objects.Enqueue(element);
        }
    }
}