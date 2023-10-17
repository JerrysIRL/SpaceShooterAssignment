
using TMPro;
using UnityEngine;


public class DataHolder : MonoBehaviour
{ 
    public static DataHolder Instance { get; private set; }
    
    [SerializeField] private TMP_Text enemieAmountText;
    [SerializeField] private TMP_Text fpsCounterText;
   
    private Transform _playerTransform;
    public int enemieCounter;
    
    public float updateInterval = 1.0f;
    private float _timeSinceLastUpdate = 0f;
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

    private void Update()
    {
        _timeSinceLastUpdate += Time.deltaTime;

        if (_timeSinceLastUpdate >= updateInterval)
        {
            float fps = 1.0f / Time.deltaTime;
            
            enemieAmountText.text = $"Enemies Alive: {enemieCounter}";
            fpsCounterText.text = $"FPS: {Mathf.Round(fps)}";
            
            _timeSinceLastUpdate = 0f;
        }

        
    }
}
