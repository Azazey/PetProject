using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    
    public List<EnemyEnabler> ObjectsToActivate = new List<EnemyEnabler>();

    private void Update()
    {
        for (int i = 0; i < ObjectsToActivate.Count; i++)
        {
            ObjectsToActivate[i].CheckDistance(_playerTransform.position);
        }
    }
}
