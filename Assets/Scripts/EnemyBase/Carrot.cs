using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 3;

    private void Awake()
    {
        ThrowToPlayer();
    }

    private void ThrowToPlayer()
    {
        transform.rotation = Quaternion.identity;
        Transform playerTransform = FindObjectOfType<PlayerMovement>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        _rigidbody.velocity = toPlayer * _speed;
    }
}
