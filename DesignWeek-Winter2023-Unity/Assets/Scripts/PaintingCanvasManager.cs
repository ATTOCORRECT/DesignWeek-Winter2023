using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PaintingCanvasManager : MonoBehaviour
{
    public RenderTexture renderTexture;

    public Texture2D brushPattern;
    Color brushColor = Color.magenta;
    int brushType = 1;
    int rotation = 0;
    float rotationVariance = 0f;
    Vector2 positionVariance = new Vector2(0,0);
    int scale = 64;
    int scaleVariance = 0;

    Vector2 topLeft;
    Vector2 paintingCanvasSize;

    Vector2 mousePosition;

    BrushManager brushManager;

    bool mouseDown = false;
    bool dynamicRotation = false;

    int count = 0;

    void Start()
    {
        brushManager = GameObject.Find("Brush Manager").GetComponent<BrushManager>();

        renderTextureSize();
        paintingCanvasValues();
    }

    private void Update()
    {



        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            brushManager.setLastUsedColor(brushColor , gameObject);
            brushManager.GetBrush(gameObject);  
        }
        

        switch (brushType)
        {
            case 1: // stroke
                mouseDown = UnityEngine.Input.GetMouseButton(0);
                if (UnityEngine.Input.touchCount > 0)
                {
                    mouseDown = true;
                }
                dynamicRotation = true;
                break;

            case 2: // stamp
                mouseDown = UnityEngine.Input.GetMouseButtonDown(0);
                break;

            case 3: // directional stamp
                Debug.Log("NOT IMPLEMENTED");
                break;
                    
            default: // no brush
                Debug.Log("NO BRUSH");
                mouseDown = false;
                break;
        }
    }

    private void OnGUI()
    {

        if (mouseDown)
        {
            if (Event.current.type.Equals(EventType.Repaint)) 
            {
                mouseDown = false;

                Vector2 oldMousePosition = mousePosition;

                mousePosition = new Vector2(UnityEngine.Input.mousePosition.x - topLeft.x, topLeft.y - UnityEngine.Input.mousePosition.y);

                Vector2 displacement = mousePosition - oldMousePosition;

                if (displacement.magnitude > 0.01f) {
                    RenderTexture.active = renderTexture;
                    GL.PushMatrix();

                    int dynamicRotationAngle = 0;
                    if (dynamicRotation)
                    {
                        dynamicRotationAngle = (int)(Mathf.Rad2Deg * Mathf.Atan2(displacement.y, displacement.x));
                        dynamicRotation = false;

                        //Debug.Log("trigger");
                    }

                    GUIUtility.RotateAroundPivot(dynamicRotationAngle + rotation + Random.Range(-180 * rotationVariance, 180 * rotationVariance), new Vector2(mousePosition.x, mousePosition.y));

                    int size = scale + Random.Range(-scaleVariance, scaleVariance);
                    Vector2 position = new Vector2(mousePosition.x + Random.Range(-positionVariance.x, positionVariance.x), mousePosition.y + Random.Range(-positionVariance.y, positionVariance.y));

                    Graphics.DrawTexture(new Rect(position.x - size / 2, position.y - size / 2, size, size), brushPattern, new Rect(0, 0, 1, 1), 0, 0, 0, 0, brushColor, null, -1);

                    GL.PopMatrix();
                    RenderTexture.active = null;
                }
            }
        }
    }

    private void renderTextureSize()
    {
        //WIP
    }

    void paintingCanvasValues()
    {
        float minX = gameObject.GetComponent<RectTransform>().position.x + gameObject.GetComponent<RectTransform>().rect.xMin;
        float maxY = gameObject.GetComponent<RectTransform>().position.y + gameObject.GetComponent<RectTransform>().rect.yMax;

        topLeft = new Vector2(minX, maxY);

        float width = gameObject.GetComponent<RectTransform>().rect.xMax * 2;
        float height = gameObject.GetComponent<RectTransform>().rect.yMax * 2;

        paintingCanvasSize = new Vector2(width, height);
    }

    //brush specific
    public void setBrushPattern(Texture2D brushPattern, int brushType, int rotation, float rotationVariance, Vector2 positionVariance, int scale, int scaleVariance)
    {                          //         texture to use    type           degrees         0 - 1                     pixels                pixels     scale +/- value    
        this.brushPattern = brushPattern;
        this.brushType = brushType;
        this.rotation = rotation;
        this.rotationVariance = rotationVariance;
        this.positionVariance = positionVariance;
        this.scale = scale;
        this.scaleVariance = scaleVariance;

        Debug.Log(brushPattern);
    }

    //color specific
    public void setBrushColor(Color brushColor)
    {
        this.brushColor = brushColor;
    }
    public void ExportPaintingCanvas()
    {
        Debug.Log("Export painting");
        string pngOutPath = @"";

        Texture2D texture1 = GameObject.Find("PaintingDisplay").GetComponent<DisplayPainting>().GetPaitningTexture();

        Texture2D texture2 = new Texture2D(renderTexture.width, renderTexture.height);
        RenderTexture.active = renderTexture;
        texture2.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2.Apply();
        RenderTexture.active = null;


        Texture2D finalTexture = AddWatermark(texture1, texture2);

        File.WriteAllBytes(pngOutPath + System.DateTime.Now.ToString("yyyy-mm-dd-hh-mm-ss") + ".png", finalTexture.EncodeToPNG());
        //File.WriteAllBytes("texture.png", tex.EncodeToPNG());

        ClearOutRenderTexture(renderTexture);
    }

    public Texture2D AddWatermark(Texture2D background, Texture2D watermark)
    {

        int startX = 0;
        int startY = background.height - watermark.height;

        for (int x = startX; x < background.width; x++)
        {

            for (int y = startY; y < background.height; y++)
            {
                Color bgColor = background.GetPixel(x, y);
                Color wmColor = watermark.GetPixel(x - startX, y - startY);

                Color final_color = Color.Lerp(bgColor, wmColor, wmColor.a / 1.0f);

                background.SetPixel(x, y, final_color);
            }
        }

        background.Apply();
        return background;
    }

    public void ClearOutRenderTexture(RenderTexture renderTexture)
    {
        RenderTexture rt = RenderTexture.active;
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = rt;
    }
}