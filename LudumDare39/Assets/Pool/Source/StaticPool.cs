using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public static class StaticPool
    {
        private static Dictionary<string, GameObject> listPool = new Dictionary<string, GameObject>();

        /// <summary>
        /// Find specific Pool for obj
        /// </summary>
        public static SystemPool GetPool(GameObject obj)
        {
            return GetPool(obj, null, Mathf.Infinity, Mathf.Infinity);
        }

        /// <summary>
        /// Find specific Pool for obj
        /// </summary>
        public static SystemPool GetPool(GameObject obj, float max)
        {
            return GetPool(obj, null, max, Mathf.Infinity);
        }

        /// <summary>
        /// Find specific Pool for obj
        /// </summary>
        public static SystemPool GetPool(GameObject obj, Transform parent)
        {
            return GetPool(obj, parent, Mathf.Infinity, Mathf.Infinity);
        }

        /// <summary>
        /// Find specific Pool for obj
        /// </summary>
        public static SystemPool GetPool(GameObject obj, float max, float lifeForDeath)
        {
            return GetPool(obj, null, max, lifeForDeath);
        }

        /// <summary>
        /// Find specific Pool for obj
        /// </summary>
        public static SystemPool GetPool(GameObject obj, Transform parent, float max, float lifeForDeath)
        {
            string name = obj.name.Split('(')[0];
            if (max <= 0)
            {
                Debug.LogError("The number of Pool is zero or negative");
                return null;
            }
            if (obj == null)
            {
                Debug.LogError("The prefab is null");
                return null;
            }

            if (listPool.ContainsKey(name))
            {
                return listPool[name].GetComponent<SystemPool>();
            }
            else
            {
                GameObject poolContainer = new GameObject(obj.name + "Pool");
                poolContainer.transform.parent = parent;
                SystemPool pool = poolContainer.AddComponent<SystemPool>();
                listPool[obj.name] = poolContainer;
                pool.lifeForDeath = lifeForDeath;
                pool.max = max;
                pool.Prefab = obj;
                return pool;
            }
        }

        /// <summary>
        /// Remove specific Pool for obj
        /// </summary>
        public static void RemovePool(GameObject obj)
        {
            if (listPool.ContainsKey(obj.name))
            {
                GameObject.Destroy(listPool[obj.name]);
                listPool.Remove(obj.name);
            }
        }

        /// <summary>
        /// Remove all Pools
        /// </summary>
        public static void RemoveAllPool()
        {
            listPool.Clear();
        }
    }
}

