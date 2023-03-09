using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour
{
    public GameObject PaintingFrame;
    [SerializeField] List<Material> paintingMats;
    [SerializeField] List<Material> usedMats;
    Material currentMat;
    bool movedPainting;
    // Start is called before the first frame update
    void Start()
    {
        PaintingFrame.GetComponent<MeshRenderer>().material = PaintingRandomizer();
    }

    // Update is called once per frame
    void Update()
    {

    }
    Material PaintingRandomizer()
    {
        int randomMatIndex = Random.Range(0, paintingMats.Count);
        Material randomMat = paintingMats[randomMatIndex];
        return randomMat;
    }
    public void NextPainting()
    {
        PaintingFrame.GetComponent<MeshRenderer>().material = PaintingRandomizer();
    }
    //void MovePainting()
    //{
    //    usedMats.Add(PaintingFrame.GetComponent<MeshRenderer>().material);
    //    paintingMats.Remove(PaintingFrame.GetComponent<MeshRenderer>().material);
    //    movedPainting = true;
    //}
}
