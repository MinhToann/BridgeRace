using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridges : MonoBehaviour
{
    [SerializeField] List<StairBrick> stairsBrick;
    
    public int GetListCount(int count)
    {
        return count = stairsBrick.Count;
    }    
      
    
    public bool CheckColorStairBrick(ColorType color)
    {
        for(int i = 0; i < stairsBrick.Count; i++)
        {
            if(color != stairsBrick[i].colorType)
            {
                return true;
            }    
        }
        return false;
    }    
}
