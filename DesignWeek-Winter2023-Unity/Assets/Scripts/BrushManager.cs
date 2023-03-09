using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BrushManager : MonoBehaviour
{
    public Texture2D[] brushTextures;
    int brushIndex = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void GetBrush(GameObject PaintingCanvas)
    {
        switch (brushIndex) 
        {
            case 0: // cat          texture to use | type (1-stroke, 2-stamp) | degrees default rotation | 0 - 1 rotation randomization | pixel position variation x & y | pixel size | pixel size variation +/- value    
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[0], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 1: // computer mouse
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[1], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 2: // scrub daddy
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[2], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 3: // banana
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[3], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 4: // boxing glove
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[4], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 5: // boot
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[5], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 6: // eraser
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[6], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 7: // bread
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[7], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 8: // grass
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[8], 1, 45, 0.1f, new Vector2(100, 5), 50, 10);
                break;

            case 9: // mop
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[9], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 10: // rose
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[10], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 11: // spatula
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[11], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            case 12: // sponge
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[12], 1, 0, 0.1f, new Vector2(0, 0), 50, 10);
                break;

            default:
                PaintingCanvas.GetComponent<PaintingCanvasManager>().setBrushPattern(brushTextures[0], 1, 0, 0, new Vector2(0, 0), 64, 0);
                break;
        }
    }

    public void setBrushIndex(int brushIndex)
    {
        this.brushIndex = brushIndex;
    }
}
