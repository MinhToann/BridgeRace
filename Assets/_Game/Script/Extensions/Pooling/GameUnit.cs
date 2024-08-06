using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    
    public PoolType poolType;
    private Transform tf;

    public Transform TF
    {
        get
        {
            if(tf == null)
            {
                tf = transform;
                //Debug.LogError("GU Error");
            }
            return tf;
        }
    }

}
