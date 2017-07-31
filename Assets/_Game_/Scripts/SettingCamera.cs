using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine.PostProcessing;

public class SettingCamera : Singleton<SettingCamera>
{

    public PostProcessingProfile profile;

	// Use this for initialization
	void Awake ()
    {
        ProCamera2D cam = GetComponent<ProCamera2D>();
        Transform pl = GameObject.FindGameObjectWithTag("Player").transform;

        cam.AddCameraTarget(pl);
	}


    public void AddProfile()
    {
        GetComponent<PostProcessingBehaviour>().profile = profile;
    }

    public void RemoveProfile()
    {
        GetComponent<PostProcessingBehaviour>().profile = null;
    }




}
