using UnityEngine;
using System.Collections.Generic;
using System;

//Base 75 Reimplimentation of the Unity tag system to allow for multiple tags on the same game object.

[SerializableAttribute]
public class MultiTags : MonoBehaviour
{
	[Tooltip("This is the list of current Tags on this GameObject")]
	public List<MT> localTagList = new List<MT>();


    /// <summary>
    /// Create GameObject with MultiTags component
    /// </summary>
    public static GameObject CreateMultiTagsGameObject(string tag1)
    {
        GameObject obj = new GameObject();
        obj.AddComponent<MultiTags>();
        return obj;
    }

    /// <summary>
    /// Search gameobjects with tags extension.
    /// </summary>
    public static GameObject[] FindGameObjectsWithMultiTags(string[] tags)
    {
        MultiTags[] tempMT = GameObject.FindObjectsOfType(typeof(MultiTags)) as MultiTags[];
        List<GameObject> tempGOList = new List<GameObject>();

        foreach (MultiTags itemMT in tempMT)
        {
            int exist = 0;
            foreach (var itemtag in itemMT.localTagList)
            {
                foreach (string tag in tags)
                {
                    if (string.Equals(itemtag.Name.ToLower(), tag.ToLower(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        exist++;
                        break;
                    }
                }
                if (exist == tags.Length)
                {
                    tempGOList.Add(itemMT.gameObject);
                    break;
                }
            }
        }

        if (tempGOList.Count > 0)
        {
            return tempGOList.ToArray();
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Search gameobjects with tags extension.
    /// </summary>
    public static GameObject[] FindGameObjectsWithMultiTags(string tag1)
    {
        return FindGameObjectsWithMultiTags(new string[] { tag1 });
    }

    /// <summary>
    /// Search gameobjects with tags extension.
    /// </summary>
    public static GameObject[] FindGameObjectsWithMultiTags(string tag1, string tag2)
    {
        return FindGameObjectsWithMultiTags(new string[] { tag1, tag2 });
    }

    /// <summary>
    /// Search gameobject with tags extension.
    /// </summary>
    public static GameObject FindGameObjectWithMultiTags(string[] tags)
    {
        GameObject[] objects = FindGameObjectsWithMultiTags(tags);
        if (objects != null)
        {
            return FindGameObjectsWithMultiTags(tags)[0];
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Search gameobject with tags extension.
    /// </summary>
    public static GameObject FindGameObjectWithMultiTags(string tag1)
    {
        return FindGameObjectWithMultiTags(new string[] { tag1 });
    }

    /// <summary>
    /// Search gameobject with tags extension.
    /// </summary>
    public static GameObject FindGameObjectWithMultiTags(string tag1, string tag2)
    {
        return FindGameObjectWithMultiTags(new string[] { tag1, tag2 });
    }

}

public static class MultiTagsHelperMethods
{

    /// <summary>
    /// Have these tags in GameObject
    /// </summary>
    public static bool HaveTags(this GameObject value, string[] tags)
    {
        MultiTags CurrentGameComponent = value.GetComponent<MultiTags>();
        if (CurrentGameComponent == null || tags == null || tags.Length == 0)
        {
            return false;
        }

        bool aux = false;

        foreach (string tag in tags)
        {
            aux = false;
            foreach (var item in CurrentGameComponent.localTagList)
            {
                if (string.Equals(item.Name.ToLower(), tag.ToLower(), StringComparison.CurrentCultureIgnoreCase))
                {
                    aux = true;
                    break;
                }
            }

            if (!aux)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Have these tags in GameObject
    /// </summary>
    public static bool HaveTags(this GameObject value, string tag1)
    {
        return value.HaveTags(new string[] { tag1 });
    }

    /// <summary>
    /// Have these tags in GameObject
    /// </summary>
    public static bool HaveTags(this GameObject value, string tag1, string tag2)
    {
        return value.HaveTags(new string[] { tag1, tag2 });
    }

    /// <summary>
    /// Return these tags in GameObject
    /// </summary>
    public static string[] ReturnTags(this GameObject value)
    {
        MultiTags multiTags = value.GetComponent<MultiTags>();
        if (multiTags && multiTags.localTagList.Count > 0)
        {
            List<MT> mts = multiTags.localTagList;
            string[] tags = new string[mts.Count];
            for (int i = 0; i < tags.Length; i++)
            {
                tags[i] = mts[i].Name;
            }
            return tags;
        }
        else return null;
    }

    /// <summary>
    /// Add these tags in GameObject
    /// </summary>
    public static void AddTags(this GameObject value, string[] tags)
    {
        MultiTags CurrentGameComponent = value.GetComponent<MultiTags>();

        if (CurrentGameComponent == null)
        {
            value.AddComponent<MultiTags>();
            CurrentGameComponent = value.GetComponent<MultiTags>();
        }

        foreach (string tag in tags)
        {
            if (!HasTagPrivate(CurrentGameComponent, tag))
            {
                MT newItem = new MT();
                newItem.Name = tag;
                CurrentGameComponent.localTagList.Add(newItem);
            }
        }
    }

    /// <summary>
    /// Add these tags in GameObject
    /// </summary>
    public static void AddTags(this GameObject value, string tag1)
    {
        AddTags(value, new string[] { tag1 });
    }

    /// <summary>
    /// Add these tags in GameObject
    /// </summary>
    public static void AddTags(this GameObject value, string tag1, string tag2)
    {
        AddTags(value, new string[] { tag1, tag2 });
    }

    /// <summary>
    /// Remove these tags in GameObject
    /// </summary>
    public static void RemoveTags(this GameObject value, string[] tags)
    {
        MultiTags CurrentGameComponent = value.GetComponent<MultiTags>();
        if (CurrentGameComponent == null)
        {
            return;
        }

        foreach (string tag in tags)
        {
            MT tempItem = GetTagItem(CurrentGameComponent, tag);
            if (tempItem != null)
            {
                CurrentGameComponent.localTagList.Remove(tempItem);
            }
        }
    }

    /// <summary>
    /// Remove these tags in GameObject
    /// </summary>
    public static void RemoveTags(this GameObject value, string tag1)
    {
        RemoveTags(value, new string[] { tag1 });
    }

    /// <summary>
    /// Remove these tags in GameObject
    /// </summary>
    public static void RemoveTags(this GameObject value, string tag1, string tag2)
    {
        RemoveTags(value, new string[] { tag1, tag2 });
    }

    //HAS TAG Private
    private static bool HasTagPrivate(MultiTags go, string tagToCheck)
    {
        foreach (var item in go.localTagList)
        {
            if (string.Equals(item.Name, tagToCheck, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    //Private GetTagItem
    private static MT GetTagItem(MultiTags CGC, string tagToCheck)
    {
        foreach (var item in CGC.localTagList)
        {

            if (string.Equals(item.Name, tagToCheck, StringComparison.CurrentCultureIgnoreCase))
            {
                return item;
            }
        }
        return null;
    }
}

[System.Serializable] 
public class MT
{
	public string Name;
	public byte ID;
}


