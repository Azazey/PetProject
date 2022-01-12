using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightActivator : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _door.SetActive(true);
        }
    }
}
