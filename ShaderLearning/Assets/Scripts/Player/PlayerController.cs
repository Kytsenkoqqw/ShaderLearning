using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    [SerializeField] private float _speed = 12f;

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, z);

        Vector3 newPosition = transform.position + move * _speed * Time.deltaTime;

        transform.position = newPosition;
    }
}
