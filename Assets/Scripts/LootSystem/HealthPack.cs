using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int _addHealthValue = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody?.GetComponent<PlayerHealth>())
        {
            other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(_addHealthValue);
            Destroy(gameObject);
        }
    }
}
