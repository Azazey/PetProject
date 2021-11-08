using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _aim;
    [SerializeField] private float _lerp;
    [SerializeField] private float _angle;

    private bool _jumped;

    private void Update()
    {
        transform.position = _target.position;
        HeadTurning();
        if (_jumped)
        {
            RotateWhileJump();
        }
    }

    private void HeadTurning()
    {
        if ((_aim.position.x - transform.position.x) > 0)
        {
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -_angle, 0), Time.deltaTime * _lerp);
        }
        else
        {
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, _angle, 0), Time.deltaTime * _lerp);
        }
    }

    public void RotateWhileJump()
    {
        transform.rotation = _target.rotation;
    }

    public void Jumped()
    {
        _jumped = true;
    }

    public void Grounded()
    {
        _jumped = false;
    }
}