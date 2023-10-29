using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float canonFireRate = 0.3f;

    private float canonTimer;

    private void Start()
    {
        canonTimer = canonFireRate;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            canonTimer -= Time.deltaTime;
            if (canonTimer <= 0)
            {
                Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation, null);
                canonTimer = canonFireRate;
            }
        }
    }
}