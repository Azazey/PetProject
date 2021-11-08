using UnityEngine;

public class RayGizmos : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Gizmos.DrawRay(ray);
    }
}