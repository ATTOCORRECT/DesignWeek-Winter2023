using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskComparison : MonoBehaviour
{

    public float PerecentageMatch(Texture2D original, Texture2D modified)
    {
        //Get width and height of paintings
        int height = original.height;
        int width = original.width;

        //Array of booleans containing a true or false value for each pixel on the mask, true means that that spot on the mask is filled
        bool[] originalWhite = getWhitePixels(original, height, width);
        bool[] modifiedColored = getColoredPixels(modified, height, width);

        int totalPixels = height * width;
        int matchedPixels = 0;

        //Add one to matchedPixels everytime the original an modified mask share a white pixel at a location
        for (int i = 0; i < originalWhite.Length; i++)
        {
            if (originalWhite[i] == modifiedColored[i])
                matchedPixels++;
        }

        float percentMatch = Mathf.Round(((float)matchedPixels / (float)totalPixels) * 100); //Percentage of pixels that match between the two masks
        return percentMatch;
    }

    //Fills array with true or false values based on wheter or not the pixels on the mask are white
    bool[] getWhitePixels(Texture2D texture, int height, int width)
    {
        bool[] blackPixels = new bool[width * height];
        int counter = 0;

        for (int i = 1; i <= width; i++)
        {
            for (int j = 1; j <= height; j++)
            {
                if (texture.GetPixel(i, j) == Color.white)
                    blackPixels[counter] = true;

                counter++;
            }
        }

        return blackPixels;
    }

    //Fills array with true or false values based on wheter or not the pixels on the mask a
    bool[] getColoredPixels(Texture2D texture, int height, int width)
    {
        bool[] coloredPixels = new bool[width * height];
        int counter = 0;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Color pixelColor = texture.GetPixel(i, j);
                if (pixelColor.a > 0)
                    coloredPixels[counter] = true;

                counter++;
            }
        }

        return coloredPixels;
    }
}
