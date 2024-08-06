using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    brick = 0,
    map = 1
}

public class PoolControl : MonoBehaviour
{

    private void Awake()
    {
        GameUnit[] prefabGameUnit = Resources.LoadAll<GameUnit>("Pool/");
        for (int i = 0; i < prefabGameUnit.Length; i++)
        {
            SimplePool.Preload(prefabGameUnit[i], 0, transform);   
        }
    }
}


