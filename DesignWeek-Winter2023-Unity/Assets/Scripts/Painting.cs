using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Painting", menuName = "Painting")]
public class Painting : ScriptableObject
{
    public Texture paintingTexture;
    public List<Material> paintingColors = new List<Material>();
    //public Texture2D paintingMask;
    //public TextMeshProUGUI authorName;
}
