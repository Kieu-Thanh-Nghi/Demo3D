using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{
    [SerializeField] internal UnityEvent OnPlayerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            OnPlayerEnter?.Invoke();
        }
    }
}
