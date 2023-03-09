using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] List<GameObject> brushObjs;
    [SerializeField] List<GameObject> icons;
    int itemInHand;
    bool itemResetComplete;
    bool iconResetComplete;

    private void OnMouseDown()
    {
        itemInHand = brushObjs.IndexOf(gameObject);
        //itemInHand = brushObjs.IndexOf(gameObject);
        //icons[itemInHand].gameObject.SetActive(true);
        for (int i = 0; i < brushObjs.Count; i++)
        {
            brushObjs[i].gameObject.SetActive(true);
            if(i == brushObjs.Count - 1)
            {
                itemResetComplete = true;
            }
        }
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].gameObject.SetActive(false);
            if (i == brushObjs.Count - 1)
            {
                iconResetComplete = true;
            }
        }
        if (itemResetComplete && iconResetComplete)
        {
            itemInHand = brushObjs.IndexOf(gameObject);
            icons[itemInHand].gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        Debug.Log(itemInHand);
        GameObject.Find("Brush Manager").GetComponent<BrushManager>().setBrushIndex(itemInHand);
    }
}
