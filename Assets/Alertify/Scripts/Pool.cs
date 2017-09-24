using System.Collections.Generic;
using UnityEngine;

namespace Alertify
{
    public sealed class Pool
    {
        private readonly GameObject prefab;
        private readonly Queue<Notify> objects;

        public Pool(Transform parent, ushort amount)
        {
            prefab = Resources.Load<GameObject>("Prefabs/Notify");
            objects = new Queue<Notify>();

            for (ushort i = 0; i < amount; i++)
            {
                Notify notify = Object.Instantiate(prefab, parent).GetComponent<Notify>();

                AddNotify(notify);
            }
        }

        public Notify GetNotify()
        {
            Notify notify = objects.Dequeue();

            notify.FadeIn();

            return notify;
        }

        public void AddNotify(Notify notify)
        {
            notify.FadeOut();
            objects.Enqueue(notify);
        }
    }
}