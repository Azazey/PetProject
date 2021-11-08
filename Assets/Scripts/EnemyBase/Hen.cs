using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToReachSpeed = 1f;
    
    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (toPlayer * _speed - _rigidbody.velocity) / _timeToReachSpeed;
        _rigidbody.AddForce(force);
    }
}
