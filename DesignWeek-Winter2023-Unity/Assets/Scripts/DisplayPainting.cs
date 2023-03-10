using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPainting : MonoBehaviour
{
    public static DisplayPainting instance { get; private set; }
    public Painting paint;
    public GameObject pallette;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //pallette.GetComponent<PaletteManager>().colorPaletteMaterials.AddRange(paint.paintingColors);
        //paintMask = paint.paintingMask;
    }

    // Update is called once per frame
    void Update()
    {
        if(paint != null)
        {
            GetComponent<MeshRenderer>().material.mainTexture = paint.paintingTexture;
        } 
    }

    public Texture2D GetPaitningTexture()
    {
        Texture2D texure =  paint.paintingTexture as Texture2D;
        return texure;
    }

    public void GeneratePainting()
    {
        
    }
}
