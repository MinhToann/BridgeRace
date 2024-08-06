using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBrick : MonoBehaviour
{
    [field: SerializeField] public ColorType colorType { get; private set; }
    [SerializeField] Renderer rendererGU;
    [SerializeField] ColorDataSO colorData;

    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        rendererGU.material = colorData.GetMaterials(colorType);
    }
}
