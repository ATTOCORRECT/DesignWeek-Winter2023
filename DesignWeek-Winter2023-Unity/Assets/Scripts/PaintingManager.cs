using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour
{
    public GameObject PaintingDisplay, pallette;
    [SerializeField] List<Painting> paintings;
    //[SerializeField] List<Material> usedMats;
    //Material currentMat;
    //bool movedPainting;
    // Start is called before the first frame update
    void Start()
    {
        PaintingDisplay.GetComponent<DisplayPainting>().paint = PaintingRandomizer();
    }

    Painting PaintingRandomizer()
    {
        int randomPaintIndex = Random.Range(0, paintings.Count);
        Painting randomPaint = paintings[randomPaintIndex];
        return randomPaint;
    }
    public void NextPainting()
    {
        //paint = PaintingRandomizer();
        PaintingDisplay.GetComponent<DisplayPainting>().paint = PaintingRandomizer();
        pallette.GetComponent<PaletteManager>().colorPaletteMaterials.Clear();
        pallette.GetComponent<PaletteManager>().colorPaletteMaterials.AddRange(PaintingDisplay.GetComponent<DisplayPainting>().paint.paintingColors);
    }
    //void MovePainting()
    //{
    //    usedMats.Add(PaintingFrame.GetComponent<MeshRenderer>().material);
    //    paintingMats.Remove(PaintingFrame.GetComponent<MeshRenderer>().material);
    //    movedPainting = true;
    //}
}
