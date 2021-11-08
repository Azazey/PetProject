using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class EnemyEnabler : MonoBehaviour
{
    [SerializeField] private float _distanceToActivate = 20f;

    private bool _isActive = true;
    private Activator _activator;

    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.ObjectsToActivate.Add(this);
    }
    
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (distance < _distanceToActivate && !_isActive)
        {
            Activate();
        }

        if (distance > _distanceToActivate + 2f && _isActive)
        {
            Deactivate();
        }
    }

    private void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _activator.ObjectsToActivate.Remove(this);
    }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, _distanceToActivate);
    }
    #endif
    
    
}
