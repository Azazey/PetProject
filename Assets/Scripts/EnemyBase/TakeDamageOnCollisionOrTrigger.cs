using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeDamageOnCollisionOrTrigger : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;
    [SerializeField] private bool _dieOnAnyCollision;

    private EnemyHealth _enemyHealth;
    private int _instaDeathValue;

    private void Awake()
    {
        _enemyHealth = gameObject.GetComponent<EnemyHealth>();
        _instaDeathValue = _enemyHealth.Health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody?.GetComponent<Bullet>())
        {
            _enemyHealth.TakeDamage(_damageValue);
        }

        if (_dieOnAnyCollision)
        {
            _enemyHealth.TakeDamage(_instaDeathValue);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider?.GetComponent<Bullet>())
        {
            _enemyHealth.TakeDamage(_damageValue);
        }

        if (_dieOnAnyCollision && !collider.isTrigger)
        {
            _enemyHealth.TakeDamage(_instaDeathValue);
        }
    }
}