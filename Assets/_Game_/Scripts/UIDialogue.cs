﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogue : Singleton<UIDialogue>
{
    private Text text;
    private Image radio;
    private Image spaceman;

    [SerializeField]
    private AudioClip rd;
    [SerializeField]
    private AudioClip[] ps;

    private AudioSource src;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        radio = transform.Find("Radio").GetComponent<Image>();
        spaceman = transform.Find("Spaceman").GetComponent<Image>();
        src = GetComponent<AudioSource>();
        UIDialogue.Instance();
        Clear();
    }

    public void Set(FacesEnum faces, string dialog)
    {
        gameObject.SetActive(true);
        text.enabled = true;
        if (faces == FacesEnum.Radio)
        {
            radio.enabled = true;
            spaceman.enabled = false;

            src.clip = rd;
            src.Play();

            text.alignment = TextAnchor.MiddleLeft;
        }
        else
        {
            spaceman.enabled = true;
            radio.enabled = false;

            int n = Random.Range(0, ps.Length - 1);
            src.clip = ps[n];
            src.Play();

            text.alignment = TextAnchor.MiddleRight;
        }

        text.text = dialog;
    }

    public void Clear()
    {
        src.Stop();
        gameObject.SetActive(false);
        text.text = "";
        radio.enabled = false;
        spaceman.enabled = false;
    }
}
