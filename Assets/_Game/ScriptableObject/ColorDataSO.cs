using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum ColorType
{
    None = 0,
    Pink = 1,
    Black = 2,
    Blue = 3,
    Green = 4,
    Yellow = 5,
    Red = 6,
}
[CreateAssetMenu(menuName = "ColorDataSO")]
public class ColorDataSO : ScriptableObject
{
    [SerializeField] Material[] materials;

    public Material GetMaterials(ColorType Color)
    {
        return materials[(int)Color];
    }
    
}
