using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRotationSpeed;
    
    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(_velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed), 
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
            Random.Range(-_maxRotationSpeed, _maxRotationSpeed)
            );
    }
}
