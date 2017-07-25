using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UITemplate
{
    public class IsSaidNoMouse : MonoBehaviour
    {
        private GameObject selectedObj;

        private StandaloneInputModuleCustom inputModule;
        private GameObject aux;

        void Awake()
        {
            selectedObj = EventSystem.current.currentSelectedGameObject;
            inputModule = GameObject.FindObjectOfType<StandaloneInputModuleCustom>();
        }

        void Update()
        {
            PointerEventData pointerData = inputModule.GetLastPointerEventDataPublic();

            if (pointerData != null && aux != pointerData.pointerEnter)
            {
                aux = pointerData.pointerEnter;

                if (pointerData.pointerEnter != null && pointerData.pointerEnter.transform.GetComponentInParent<Button>())
                {
                    EventSystem.current.SetSelectedGameObject(aux.transform.GetComponentInParent<Button>().gameObject);
                }
            }

            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(selectedObj);
            }

            selectedObj = EventSystem.current.currentSelectedGameObject;
        }
    }
}
