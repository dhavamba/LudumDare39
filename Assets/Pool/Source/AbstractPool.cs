using HeavyDutyInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Pool
{
    public abstract class AbstractPool : MonoBehaviour, IPool
    {

        [SerializeField]
        [Tooltip("The prefab pool")]
        private GameObject prefab;

        [SerializeField]
        [Tooltip("The capacity of pool")]
        private int maxInPool;

        private List<GameObject> gameobjects = new List<GameObject>();

        public abstract void Reset(GameObject obj);

        public void Disable(GameObject obj)
        {
            StopCoroutine("DestroyForTime");
            StaticPool.GetPool(prefab).Disable(obj);
            gameobjects.Remove(obj);
        }

        public void AllDisable()
        {
            StopCoroutine("DestroyForTime");
            foreach (GameObject obj in gameobjects)
            {
                StaticPool.GetPool(prefab).Disable(obj);
            }
            gameobjects.Clear();
        }

        public void DestroyForTime(GameObject obj, float time)
        {
            if (time != Mathf.Infinity)
            {
                StartCoroutine(_DestroyForTime(time, obj));
            }
        }

        IEnumerator _DestroyForTime(float time, GameObject obj)
        {
            yield return new WaitForSeconds(time);
            Disable(obj);
        }

        public void _DestroyForTime()
        {
            AllDisable();
        }

        public void CreatePool()
        {
            if (maxInPool == 0)
            {
                maxInPool = int.MaxValue;  //Specific the size of Pool
            }
            Pool.StaticPool.GetPool(prefab, maxInPool);
        }

        public GameObject InstantiateObject()
        {
            GameObject aux = Pool.StaticPool.GetPool(prefab).InstantiateObject(gameObject);
            gameobjects.Add(aux);
            return aux;
        }
    }
}

