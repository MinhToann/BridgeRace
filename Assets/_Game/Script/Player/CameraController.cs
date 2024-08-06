using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    private Vector3 offset;
    [SerializeField] JoystickMovement player;
    private float lerpSpeed = 5f;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, lerpSpeed * Time.deltaTime);
    }
}
