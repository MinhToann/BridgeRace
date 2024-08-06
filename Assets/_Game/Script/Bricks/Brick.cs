using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : GameUnit
{
    [SerializeField] ColorDataSO colorDataSO;
    public ColorType colorType { get; private set; }
    public Renderer rendererGU;

    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        rendererGU.material = colorDataSO.GetMaterials(colorType);
    }
   

}
