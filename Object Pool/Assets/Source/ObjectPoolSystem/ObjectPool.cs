using PlayerSystem;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPoolSystem
{
    public class ObjectPool <T> where T : Object, IPoolabel<T>
    {
        private List<T> objects = new List<T>();
        private int startPoolSize = 5;
        private int maxPoolSize = 15;
        private List<T> usedObjects = new List<T>();
        private T Prefab;

        public ObjectPool(T prefab)
        {
            Prefab = prefab;

            for (int i = 0; i < startPoolSize; i++)
            {
                T item = Object.Instantiate(Prefab);
                item.Init(this);
                objects.Add(item);
            }
        }

        public void PushToPool(T item)
        {
            if (usedObjects.Contains(item))
            {
                usedObjects.Remove(item);
                objects.Add(item);
            }
        }

        public T TryGetFromPool()
        {
            if(objects.Count > 0)
            {
                T item = objects[0];
                usedObjects.Add(item);
                objects.Remove(item);
                return item;
            }
            else if(usedObjects.Count < maxPoolSize)
            {
                T newItem = Object.Instantiate(Prefab);
                newItem.Init(this);
                usedObjects.Add(newItem);
                return newItem;
            }

            return null;
        }
    }
}