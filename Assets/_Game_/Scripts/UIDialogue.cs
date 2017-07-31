using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogue : Singleton<UIDialogue>
{
    private Text text;
    private Image radio;
    private Image spaceman;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        radio = transform.Find("Radio").GetComponent<Image>();
        spaceman = transform.Find("Spaceman").GetComponent<Image>();
        UIDialogue.Instance();
        Clear();
    }

    public void Set(FacesEnum faces, string dialog)
    {
        gameObject.SetActive(true);
        if (faces == FacesEnum.Radio)
        {
            radio.enabled = true;
            spaceman.enabled = false;
            text.alignment = TextAnchor.MiddleLeft;
        }
        else
        {
            spaceman.enabled = true;
            radio.enabled = false;
            text.alignment = TextAnchor.MiddleRight;
        }

        text.text = dialog;
    }

    public void Clear()
    {
        gameObject.SetActive(false);
        text.text = "";
        radio.enabled = false;
        spaceman.enabled = false;
    }
}
