using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> colorsInScene = new List<GameObject>();
    public List<Material> colorPaletteMaterials = new List<Material>();
    public GameObject PaintingCanvas;

    private void Start()
    {

    }
    private void Update()
    {
        
    }
    public void setColorToPalette(int colorIndex)
    {
        for (int i = 0; i < colorPaletteMaterials.Count; i++)
        {
            colorsInScene[i].GetComponent<MeshRenderer>().material = colorPaletteMaterials[i];
        }
        Color color = colorPaletteMaterials[colorIndex].color;
        PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushColor(color);
    }
}
