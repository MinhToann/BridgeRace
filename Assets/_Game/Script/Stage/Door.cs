using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    [SerializeField] Stage stage;

    private void OnTriggerEnter(Collider other)
    {
        Bot bot = other.GetComponent<Bot>();
        if(bot != null)
        {
            bot.SetStage(stage);
        }
        
    }
}
