using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPainting : MonoBehaviour
{
    public Painting paint;
    public GameObject pallette;

    // Start is called before the first frame update
    void Start()
    {
        pallette.GetComponent<PaletteManager>().colorPaletteMaterials.AddRange(paint.paintingColors);
        //paintMask = paint.paintingMask;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material = paint.paintingMat;
        pallette.GetComponent<PaletteManager>().colorPaletteMaterials.AddRange(paint.paintingColors);
    }
}
