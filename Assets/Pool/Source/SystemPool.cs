using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class SystemPool : MonoBehaviour
    { 
        public float lifeForDeath;
        public float max;
        public GameObject Prefab { private get; set; }

        private List<GameObject> listDisable;
        private List<GameObject> listAble;
        private GameObject aux;

        private void Awake()
        {
            listDisable = new List<GameObject>();
            listAble = new List<GameObject>();
        }

        private void OnDestroy()
        {
            StaticPool.RemovePool(gameObject);
        }

        /// <summary>
        /// Disable GameObject
        /// </summary>
        public void Disable(GameObject obj)
        {
            obj.SetActive(false);
            listAble.Remove(obj);
            listDisable.Add(obj);
        }

        public GameObject InstantiateObject(GameObject obj, Vector3 position)
        {
            return InstantiateObject(obj, position, ModePosition.World);
        }

        public GameObject InstantiateObject(GameObject obj)
        {
            return InstantiateObject(obj, Vector3.zero, ModePosition.World);
        }

        /// <summary>
        /// Create or Recycle GameObject
        /// </summary>
        public GameObject InstantiateObject(GameObject obj, Vector3 position, ModePosition mode)
        {
            GameObject aux = null;
            if (mode == ModePosition.Local)
            {
                position = obj.transform.position + position;
            }

            if (listDisable.Count == 0)
            {
                if (listAble.Count >= max)
                {
                    Disable(listAble[0]);
                    aux = _RecycleObject(position);
                }
                else
                {
                    aux = _IstantiateNewObject(position);
                }
            }
            else
            {
                aux = _RecycleObject(position);
            }

            if (obj.GetComponent<IPool>() != null)
            {
                obj.GetComponent<IPool>().Reset(aux);
                obj.GetComponent<IPool>().DestroyForTime(aux, lifeForDeath);
            }

            return aux;
        }

        private GameObject _RecycleObject(Vector3 position)
        {
            aux = listDisable[0];
            aux.transform.position = position;
            aux.SetActive(true);
            listDisable.Remove(aux);
            listAble.Add(aux);
            return aux;
        }

        private GameObject _IstantiateNewObject(Vector3 position)
        {
            aux = GameObject.Instantiate(Prefab, position, Quaternion.identity, transform);
            listAble.Add(aux);
            return aux;
        }

    }
}

