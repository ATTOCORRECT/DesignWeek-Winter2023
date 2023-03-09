using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
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
        if(gameObject.CompareTag("Canvas"))
        {
            ToCanvas();
        }
    }
    
    public void ToGallery()
    {
        SceneManager.LoadScene("GalleryScene");
    }
    public void ToStudio()
    {
        SceneManager.LoadScene("PaintRoomScene");
    }
    public void ToCanvas()
    {
        SceneManager.LoadScene("PaintingEditorScene");
    }
}
