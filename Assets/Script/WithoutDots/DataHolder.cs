
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


public class DataHolder : MonoBehaviour
{ 
    public static DataHolder Instance { get; private set; }
    
    [SerializeField] private TMP_Text enemieAmountText;
    [SerializeField] private TMP_Text fpsCounterText;
   
    private Transform _playerTransform;
    public int enemyCounter;
    
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
            string fps = (1.0f / Time.deltaTime).ToString();
            enemieAmountText.text = $"Enemies Alive: {enemyCounter}";
            fpsCounterText.text = $"FPS: {fps}";
            
            _timeSinceLastUpdate = 0f;
        }

        
    }
}
