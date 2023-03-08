using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameObject.CompareTag("Door"))
        {
            ToGallery();
        }
    }
    
    public void ToGallery()
    {
        SceneManager.LoadScene("Title Screen");
    }
    public void ToStudio()
    {
        SceneManager.LoadScene("Samuel's Test Scene");
    }
}
