using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PaintingCanvasManager : MonoBehaviour
{
    public RenderTexture renderTexture;
    public Texture2D brushPattern;
    Vector2 topLeft;
    Vector2 paintingCanvasSize;
    void Start()
    {

        float minX = gameObject.GetComponent<RectTransform>().position.x + gameObject.GetComponent<RectTransform>().rect.xMin;
        float maxY = gameObject.GetComponent<RectTransform>().position.y + gameObject.GetComponent<RectTransform>().rect.yMax;

        topLeft = new Vector2(minX, maxY);

        float width = gameObject.GetComponent<RectTransform>().rect.xMax * 2;
        float height = gameObject.GetComponent<RectTransform>().rect.yMax * 2;

        paintingCanvasSize = new Vector2(width, height);
    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            RenderTexture.active = renderTexture;
            GL.PushMatrix();
            GL.LoadPixelMatrix(0, paintingCanvasSize.x, paintingCanvasSize.y, 0);
            float xCoordinate = Input.mousePosition.x;
            float yCoordinate = Input.mousePosition.y;

            Graphics.DrawTexture(new Rect(xCoordinate - topLeft.x - brushPattern.width / 2, topLeft.y - yCoordinate - brushPattern.height / 2, brushPattern.width, brushPattern.height), brushPattern);
            
            GL.PopMatrix();
            RenderTexture.active = null;
        }
    }
}