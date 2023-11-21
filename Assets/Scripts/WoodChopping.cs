using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WoodChopping : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField] private Transform positons;

    private void OnEnable()
    {
        Instantiate(prefabs, positons);
    }
}
