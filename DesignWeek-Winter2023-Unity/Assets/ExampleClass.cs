using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExampleClass : MonoBehaviour
{
    Texture2D texture;
    void Start()
    {
        texture = new Texture2D(128, 128);
        GetComponent<RawImage>().texture = texture;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = ((x & y) != 0 ? Color.white : Color.gray);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }

    private void Update()
    {
        Debug.Log(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            texture.SetPixel((int)Input.mousePosition[0], (int)Input.mousePosition[1], Color.red);
            texture.Apply();
        }
    }
}