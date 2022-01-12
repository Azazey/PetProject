using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollisionOrTrigger : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody?.GetComponent<PlayerHealth>())
        {
            collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageValue);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collider.GetComponentInParent<PlayerHealth>().TakeDamage(_damageValue);
            collider.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageValue);
        }
    }
}