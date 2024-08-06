using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBrick : MonoBehaviour
{
    public MeshRenderer mesh;
    public ColorType colorBackBrick;
    public ColorDataSO color;
  
    public void ChangeBackColor(ColorType colorBack)
    {
        colorBackBrick = colorBack;
        mesh.material = color.GetMaterials(colorBack);
    }   
}
