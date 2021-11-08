using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler = new Vector3(0,-180,0);
    [SerializeField] private Vector3 _rightEuler = Vector3.zero;
    [SerializeField] private float _rotationSpeed = 5f;

    private Transform _playerTransform;
    private Vector3 _targetEuler;

    private void Awake()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        if (transform.position.x < _playerTransform.position.x)
        {
            _targetEuler = _rightEuler;
        }
        else
        {
            _targetEuler = _leftEuler;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotationSpeed);
    }
}
