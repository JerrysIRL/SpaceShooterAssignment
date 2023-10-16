using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 10f;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(transform.up * (projectileSpeed * Time.fixedDeltaTime));
    }

    // private void Update()
    // {
    //     
    //     transform.position += transform.up * (projectileSpeed * Time.fixedDeltaTime);
    // }
}
