using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

    public static GameObject getGrandParent(GameObject obj)
    {
        return obj.GetComponentInParent<Transform>().gameObject.GetComponentInParent<Transform>().gameObject;
    }

    public static T getComponentInGrandParent<T>(GameObject obj)
    {
        return obj.GetComponentInParent<Transform>().gameObject.GetComponentInParent<T>();
    }

    public static GameObject getGrandChild(GameObject obj, string parentTag, string childTag)
    {
        return getChildWithTag(getChildWithTag(obj, parentTag), childTag);
    }

    public static GameObject getGrandChild(GameObject obj, int parent, int child)
    {
        return obj.transform.GetChild(parent).transform.GetChild(child).gameObject;
    }

    public static GameObject getGrandChild(GameObject obj, int parent, string childTag)
    {
        return getChildWithTag(obj.transform.GetChild(parent).gameObject, childTag);
    }

    public static GameObject getChildWithTag(GameObject parent, string tag)
    {
        Transform T = parent.transform;
        foreach(Transform tr in T)
        {
            if(tr.tag == tag)
            {
                return tr.gameObject;
            }
        }

        return null;
    }

    public static T getComponentInChildWithTag<T>(GameObject parent, string tag)
    {
        Transform t = parent.transform;
        foreach (Transform tr in t)
        {
            if (tr.tag == tag)
            {
                return tr.GetComponent<T>();
            }
        }

        Debug.Log("Component doesnt exist");
        return default(T);
    }
}
