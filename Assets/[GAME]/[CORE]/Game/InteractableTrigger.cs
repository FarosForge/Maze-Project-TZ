using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PLAYER;

public class InteractableTrigger : MonoBehaviour
{
    public UnityEvent trigger_event;
    private bool IsEntered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerView>())
        {
            if(!IsEntered)
            {
                trigger_event?.Invoke();
                IsEntered = true;
            }
        }
    }
}
