using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance { get; private set; }
    private Transform _playerTransform;
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    public Transform GetPlayerTransform() => _playerTransform;
}
