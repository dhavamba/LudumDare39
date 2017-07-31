using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : Singleton<Dialogues>
{
    [SerializeField]
    private List<Dialogue> dialogues;
    [SerializeField] [Range(0, 5)]
    private float timeForDialog;

    [SerializeField]
    private List<Dialogue> Startdialogues;

    [SerializeField]
    private Dialogue piantinaElettrica;

    private List<Dialogue> actives;
    private bool active;

	// Use this for initialization
	void Awake ()
    {
        actives = new List<Dialogue>();
        foreach (Dialogue d in dialogues)
        {
            d.Init();
        }
        foreach (Dialogue d in Startdialogues)
        {
            d.Init();
        }
    }

    private void Start()
    {
        //AddDialogue(Startdialogues[0]);
        //AddDialogue(Startdialogues[1]);
    }

    public void Stop()
    {
        if (actives[0] != null)
        {
            actives[0].Reset();
            actives.RemoveAt(0);
        }

        CancelInvoke();
        UIDialogue.Instance().Clear();
        active = false;
    }

    public void AddDialogue()
    {
        int n = Random.Range(0, dialogues.Count - 1);
        actives.Add(dialogues[n]);
        if (!active)
        {
            active = true;
            RealDialogue();
        }
    }

    public void AddDialogue(Dialogue d)
    {
        actives.Add(d);
        if (!active)
        {
            active = true;
            RealDialogue();
        }
    }

    private void RealDialogue()
    {
        Dialogue d = actives[0];
        UIDialogue.Instance().Set(d.GetPerson(), d.GetDialog());
        if (!d.Next())
        {
            actives.RemoveAt(0);
            d.Reset();
            Invoke("Clear", timeForDialog);
        }
        else if (actives.Count > 0)
        {
            Invoke("RealDialogue", timeForDialog);
        }
    }

    private void Clear()
    {
        UIDialogue.Instance().Clear();
        if (actives.Count > 0)
        {
            Invoke("RealDialogue", 4f);
        }
        else
        {
            active = false;
        }
    }


}
