using UnityEngine;
using UnityEngine.SceneManagement;

namespace UITemplate
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        [SerializeField]
        private bool allowDuplicate;
        public bool isFirst;

        private void Awake()
        {
            SceneManager.sceneLoaded += SeeDuplicate;
            DontDestroyOnLoad(gameObject);
        }

        public void SeeDuplicate(Scene scene, LoadSceneMode mode)
        {
            if (!isFirst)
            {
                DontDestroyOnLoad[] names = GameObject.FindObjectsOfType<DontDestroyOnLoad>();

                foreach (DontDestroyOnLoad s in names)
                {
                    if (s.gameObject.name == gameObject.name && s.isFirst)
                    {
                        Destroy(gameObject);
                    }
                }
                isFirst = true;
            }
        }
    }
}
