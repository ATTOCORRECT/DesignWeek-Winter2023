using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour
{
    public GameObject PaintingFrame;
    [SerializeField] List<Material> paintingMats;
    List<Material> usedMats;
    Material currentMat;
    bool movedPainting;
    // Start is called before the first frame update
    private void Awake()
    {
        currentMat = PaintingFrame.GetComponent<MeshRenderer>().material;
    }
    void Start()
    {
        currentMat = PaintingRandomizer();
    }

    // Update is called once per frame
    void Update()
    {
        if(paintingMats.Count == 0)
        {
            foreach (Material usedMat in usedMats)
            {
                paintingMats.Add(usedMat);
            }
        }
    }
    Material PaintingRandomizer()
    {
        int randomMatIndex = Random.Range(0, paintingMats.Count);
        Material randomMat = paintingMats[randomMatIndex];
        return randomMat;
    }
    public void NextPainting()
    {
        //save current painting
        if(movedPainting)
        {
            currentMat = PaintingRandomizer();
        }
    }
    void MovePainting()
    {
        usedMats.Add(currentMat);
        paintingMats.Remove(currentMat);
        movedPainting = true;
    }
}
