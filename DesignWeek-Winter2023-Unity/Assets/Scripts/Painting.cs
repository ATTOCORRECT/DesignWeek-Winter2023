using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Painting", menuName = "Painting")]
public class Painting : ScriptableObject
{
    public Material paintingMat;
    public List<Material> paintingColors;
    public Texture2D paintingMask;
    public TextMeshProUGUI authorName;
}
