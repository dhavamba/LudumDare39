using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine.PostProcessing;

public class SettingCamera : Singleton<SettingCamera>
{

    public PostProcessingProfile profileAdd;
    public PostProcessingProfile profileRemove;

    // Use this for initialization
    void Awake ()
    {
        ProCamera2D cam = GetComponent<ProCamera2D>();
        Transform pl = GameObject.FindGameObjectWithTag("Player").transform;

        cam.AddCameraTarget(pl);
	}


    public void EnterFade()
    {
        GetComponent<ProCamera2DTransitionsFX>().TransitionEnter();
    }

    public void ExitFade()
    {
        GetComponent<ProCamera2DTransitionsFX>().TransitionExit();
    }

    public void AddProfile()
    {
        GetComponent<PostProcessingBehaviour>().profile = profileAdd;
    }

    public void RemoveProfile()
    {
        GetComponent<PostProcessingBehaviour>().profile = profileRemove;
    }




}
