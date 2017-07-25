using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UITemplate
{
    public class ChangeSelectedEvent : MonoBehaviour
    {
        public GameObject firstOptionSelect;
        public GameObject firstMenuSelect;
        public GameObject firstPauseSelect;
        public GameObject flag;

        public Dictionary<string, GameObject> dictonaryObjects;

        private GameObject preSelect;

        // Use this for initialization
        void Awake()
        {
            dictonaryObjects = new Dictionary<string, GameObject>();
            dictonaryObjects.Add("Option", firstOptionSelect);
            dictonaryObjects.Add("Pause", firstPauseSelect);
            dictonaryObjects.Add("Menu", firstMenuSelect);
            dictonaryObjects.Add("PreSelect", preSelect);
            dictonaryObjects.Add("Flag", flag);
        }

        public void ChangeSelect(string s)
        {
            GameObject a = preSelect;
            preSelect = EventSystem.current.currentSelectedGameObject;
            if (s != "PreSelect")
            {
                EventSystem.current.SetSelectedGameObject(dictonaryObjects[s]);
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(a);
            }
        }
    }


}