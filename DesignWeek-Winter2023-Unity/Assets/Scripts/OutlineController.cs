using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    Outline outlineScript;
    // Start is called before the first frame update
    void Start()
    {
        outlineScript = this.GetComponent<Outline>();
        outlineScript.enabled = false;
    }

    private void OnMouseEnter()
    {
        outlineScript.enabled = true;
    }
    private void OnMouseExit()
    {
        outlineScript.enabled = false;
    }
}
