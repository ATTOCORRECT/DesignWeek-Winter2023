using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
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
