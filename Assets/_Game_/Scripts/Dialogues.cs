using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : Singleton<Dialogues>
{
    [SerializeField]
    private List<Dialogue> dialogues;
    [SerializeField] [Range(0, 5)]
    private float timeForDialog;

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
	}

    public void AddDialogue()
    {
        int n = Random.Range(0, dialogues.Count);
        actives.Add(dialogues[n]);
        dialogues.RemoveAt(n);
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
            Invoke("Clear", timeForDialog);
        }
        if (actives.Count > 0)
        {
            Invoke("RealDialogue", timeForDialog);
        }
    }

    private void Clear()
    {
        UIDialogue.Instance().Clear();
        if (actives.Count > 0)
        {
            RealDialogue();
        }
        else
        {
            active = false;
        }
    }


}
