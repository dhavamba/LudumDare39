using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text.RegularExpressions;

[Serializable]
public class Dialogue
{
    [SerializeField]
    private string dialog;

    private static int max = 40;

    private int index;

    private List<string> people = new List<string>();
    private List<string> dialogs = new List<string>();
    private int numberLine;
    private string aux;


	// Use this for initialization
	public void Init ()
    {
        people = new List<string>();
        dialogs = new List<string>();
        string[] strings = dialog.Split(new string[] { "/" }, StringSplitOptions.None);
        strings = new List<string>(strings).GetRange(1, strings.Length - 1).ToArray();
        List<string> newStrings = new List<string>();

        foreach (string s in strings)
        {
            if (s.Length < max)
            {
                newStrings.Add(s);
                aux = s;
            }
            else
            {
                List<string> divides = new List<string>();
                int count = 0;
                int init = 0;
                for (int d = 0; d < s.Length; d++)
                {
                    count++;
                    if (count > max && ( s[d-1] == ' ' || s[d-1] == '.' || d == s.Length))
                    {
                        divides.Add(s.Substring(init, d - init));
                        init = d;
                        count = 0;
                    }
                }

                newStrings.Add(divides[0]);

                for (int d = 1; d < divides.Count; d++)
                {
                    newStrings.Add(aux);
                    newStrings.Add(divides[d]);
                }
            }
        }

        int i = 0;
        foreach (string s in newStrings)
        {
            if (i % 2 == 0)
            {
                people.Add(s);
            }
            else
            {
                dialogs.Add(s);
            }
            i++;
        }

        numberLine = (int)(newStrings.Count / 2);
    }

    public bool Next()
    {
        index++;
        return index < numberLine;
    }

    public void Reset()
    {
        index = 0;
    }

    public FacesEnum GetPerson()
    {
        if (people[index] == "radio")
        {
            return FacesEnum.Radio;
        }
        else
        {
            return FacesEnum.Spaceman;
        }
    }

    public string GetDialog()
    {
        if (dialogs.Count == 0)
        {
            Init();
        }
        return dialogs[index];
    }
}
