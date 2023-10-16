using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation, null);
        }
    }
}
