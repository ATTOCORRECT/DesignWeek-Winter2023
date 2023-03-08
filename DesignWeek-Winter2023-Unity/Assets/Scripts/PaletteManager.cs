using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] colorPaletteMaterials;
    public GameObject PaintingCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setColorToPalette(int colorIndex)
    {
        Color color = colorPaletteMaterials[colorIndex].color;
        PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushColor(color);
    }
}
