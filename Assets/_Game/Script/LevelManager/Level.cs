using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public PoolType poolType;
    [SerializeField] Stage[] stages;
    public List<Bot> listBots = new List<Bot>();
    public List<Transform> listFinishPoints = new List<Transform>();

    internal void OnInit()
    {
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].OnInit();
        }
    }

}
