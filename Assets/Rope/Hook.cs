using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Collider _playerCollider;
    
    public Rigidbody Rigidbody;
    public RopeGun RopeGun;
    
    private FixedJoint _fixedJoint;

    private void Start()
    {
        Physics.IgnoreCollision(_collider, _playerCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            RopeGun.CreateSpring();
        }
    }

    public void StopFix()
    {
        if (_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }
}
