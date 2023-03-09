using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPainting : MonoBehaviour
{
    public Painting paint;
    //public Material paintMat;
    public List<Material> currentColors;
    //public Texture2D paintMask;
    public GameObject pallette;

    // Start is called before the first frame update
    void Start()
    {
        
        
        //paintMask = paint.paintingMask;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material = paint.paintingMat;
        pallette.GetComponent<PaletteManager>().colorPaletteMaterials = currentColors;
        for (int i = 0; i < paint.paintingColors.Count; i++)
        {
            currentColors.Add(paint.paintingColors[i]);
        }
    }
}
