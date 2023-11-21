using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 moveVector;
    [SerializeField, Range(0f, 30f)] private float speed = 10f;

    void Update()
    {
        moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += moveVector * speed * Time.deltaTime;
    }
}