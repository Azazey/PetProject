using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootBullet : MonoBehaviour
{
    [SerializeField] private int _gunIndex;
    [SerializeField] private int _giveNumberOfBullets = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody?.GetComponent<PlayerArmory>())
        {
            other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(_gunIndex, _giveNumberOfBullets);
            other.attachedRigidbody.GetComponent<PlaySound>().PlaySoundEffect.Invoke();
            Destroy(gameObject);
        }
    }
}