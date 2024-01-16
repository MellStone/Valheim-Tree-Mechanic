using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TreeDivideController : MonoBehaviour, ITreeDamageable
{
    [SerializeField] private Type treeType;

    [SerializeField] private GameObject treeLog;
    [SerializeField] private GameObject treeLogHalf;
    [SerializeField] private GameObject treeStump;

    private int healthAmount;
    [SerializeField] private int damageFromFallenTree = 999;

    public enum Type
    {
        Tree,
        Log,
        LogHalf,
        Stump
    }

    private void Awake()
    {
        switch (treeType)
        {
            default:
            case Type.Tree: healthAmount = 50; break;
            case Type.Log: healthAmount = 50; break;
            case Type.LogHalf: healthAmount = 50; break;
            case Type.Stump: healthAmount = 50; break;
        }
    }

    private void OnTreeDead()
    {
        switch (treeType)
        {
            default:
            case Type.Tree:
                // Spawn Log
                Vector3 treeLogOffset = transform.up * .8f;
                Instantiate(treeLog, transform.position + treeLogOffset, Quaternion.Euler(UnityEngine.Random.Range(-1.5f, +1.5f), 0, UnityEngine.Random.Range(-1.5f, +1.5f)));

                // Spawn Stump
                Instantiate(treeStump, transform.position, transform.rotation);
                break;

            case Type.Log:
                // Spawn Log Half
                float logYPositionAboveStump = .8f;
                treeLogOffset = transform.up * logYPositionAboveStump;
                Instantiate(treeLogHalf, transform.position + treeLogOffset, transform.rotation);

                // Spawn 2nd Log Half
                float logYPositionAboveFirstLogHalf = 5.1f;
                treeLogOffset = transform.up * logYPositionAboveFirstLogHalf;
                Instantiate(treeLogHalf, transform.position + treeLogOffset, transform.rotation);
                break;
            case Type.LogHalf:
                break;
            case Type.Stump:
                break;
        }

        Destroy(gameObject);
    }

    public void Damage(int amount)
    {
        healthAmount -= amount;
        if (healthAmount <= 0)
        {
            OnTreeDead();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ITreeDamageable>(out ITreeDamageable treeDamageable))
        {
            if (collision.relativeVelocity.magnitude > 1f)
            {
                int damageAmount = damageFromFallenTree;
                //int damageAmount = UnityEngine.Random.Range(5, 30);
                treeDamageable.Damage(damageAmount);
            }
        }
    }
}
