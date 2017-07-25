using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UITemplate
{
    public class StandaloneInputModuleCustom : StandaloneInputModule
    {
        private bool isFirst;

        protected override void Awake()
        {
            base.Awake();
        }

        public PointerEventData GetLastPointerEventDataPublic(int id)
        {
            return GetLastPointerEventData(id);
        }

        public PointerEventData GetLastPointerEventDataPublic()
        {
            return GetLastPointerEventData(-1);
        }
    }
}

