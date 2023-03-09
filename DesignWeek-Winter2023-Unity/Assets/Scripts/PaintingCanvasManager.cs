using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    void Start()
    {
        brushManager = GameObject.Find("Brush Manager").GetComponent<BrushManager>();

        renderTextureSize();
        paintingCanvasValues();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            brushManager.setLastUsedColor(brushColor , gameObject);
            brushManager.GetBrush(gameObject);  
        }
        

        switch (brushType)
        {
            case 1: // stroke
                mouseDown = Input.GetMouseButton(0);
                if (Input.touchCount > 0)
                {
                    mouseDown = true;
                }
                dynamicRotation = true;
                break;

            case 2: // stamp
                mouseDown = Input.GetMouseButtonDown(0);
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

                mousePosition = new Vector2(Input.mousePosition.x - topLeft.x, topLeft.y - Input.mousePosition.y);

                Vector2 displacement = mousePosition - oldMousePosition;

                RenderTexture.active = renderTexture;
                GL.PushMatrix();

                if (dynamicRotation)
                {
                    rotation = (int)(Mathf.Rad2Deg * Mathf.Atan2(displacement.y, displacement.x));
                    dynamicRotation = false;

                    Debug.Log("trigger");
                }

                GUIUtility.RotateAroundPivot(rotation + Random.Range(-180 * rotationVariance, 180 * rotationVariance), new Vector2(mousePosition.x, mousePosition.y));

                int size = scale + Random.Range(-scaleVariance, scaleVariance);
                Vector2 position = new Vector2(mousePosition.x + Random.Range(-positionVariance.x, positionVariance.x), mousePosition.y + Random.Range(-positionVariance.y, positionVariance.y));

                Graphics.DrawTexture(new Rect(position.x - size / 2, position.y - size / 2, size, size), brushPattern, new Rect(0, 0, 1, 1), 0, 0, 0, 0, brushColor, null, -1);
                
                GL.PopMatrix();
                RenderTexture.active = null;
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
}