using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _lerpValue;
    [SerializeField] private Transform _transform;
    [SerializeField] private Head _head;

    private bool _grounded;
    private Vector2 _input;
    private int _jumpFrameCounter;

    public bool Grounded => _grounded;

    private void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            Jump();
        }
        Sit();
    }

    private void FixedUpdate()
    {
        Moving();
        _jumpFrameCounter++;
        if (_jumpFrameCounter == 2)
        {
            _rigidbody.freezeRotation = false;
            _rigidbody.AddRelativeTorque(0f,0f,10f,ForceMode.VelocityChange);
            _head.Jumped();
        }
    }

    private void Sit()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || _grounded == false)
        {
            _transform.localScale =
                Vector3.Lerp(_transform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * _lerpValue);
        }
        else
        {
            _transform.localScale =
                Vector3.Lerp(_transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * _lerpValue);
        }
    }

    public void Jump()
    {
        _rigidbody.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }

    private void Moving()
    {
        float speedMultiplyer = 1f;

        if (!_grounded)
        {
            speedMultiplyer = 0.1f;
            if (_rigidbody.velocity.x > _maxSpeed && _input.x > 0)
            {
                speedMultiplyer = 0;
            }

            if (_rigidbody.velocity.x < -_maxSpeed && _input.x < 0)
            {
                speedMultiplyer = 0;
            }
        }

        if (_grounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
            _head.Grounded();
        }

        _rigidbody.AddForce(_input.x * _moveSpeed * speedMultiplyer, 0, 0, ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contacts.Length; i++)
        {
            float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
            if (angle < 45f)
            {
                _grounded = true;
                _rigidbody.freezeRotation = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }
}