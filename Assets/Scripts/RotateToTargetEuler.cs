using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rightEuler;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _targetEuler;

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler),
            Time.deltaTime * _rotationSpeed);
    }

    public void RotateLeft()
    {
        _targetEuler = _leftEuler;
    }

    public void RotateRight()
    {
        _targetEuler = _rightEuler;
    }
}