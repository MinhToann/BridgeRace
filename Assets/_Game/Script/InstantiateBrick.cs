using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBrick : MonoBehaviour
{
    [SerializeField] Brick brickSpawn;
    private void Awake()
    {
        Instantiate(brickSpawn, transform);
    }
}
