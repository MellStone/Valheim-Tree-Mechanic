using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class WoodChoppingTool : MonoBehaviour
{
    [SerializeField, Range(0f, 3f)] private float maxDistance = 1.0f;
    [SerializeField, Range(0.15f, 1.2f)] private float radius = 0.3f;
    [SerializeField] private int damageAmount = 30;    
    
    
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private KeyCode attack = KeyCode.E;
    private void Update()
    {

        if (Input.GetKeyDown(attack))
        {
            Collider[] hitColliders = Physics.OverlapSphere
                (
                new Vector3(transform.position.x, transform.position.y, transform.position.z + maxDistance),
                radius,
                layerMask, 
                QueryTriggerInteraction.Collide
                );

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out ITreeDamageable treeDamageable) == false)
                    return;
                treeDamageable.Damage(damageAmount);
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
