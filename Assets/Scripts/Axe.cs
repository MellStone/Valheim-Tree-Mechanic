using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField, Range(0f, 3f)] private float maxDistance = 1.0f;
    [SerializeField, Range(0.15f, 1.2f)] private float radius = 0.3f;

    [SerializeField] private LayerMask layer;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, maxDistance, layer))
            {
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 direction = transform.position + new Vector3(0, 0, maxDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(direction, radius);
    }
}
