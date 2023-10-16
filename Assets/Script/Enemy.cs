using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    [SerializeField] private int health = 1; 
    [SerializeField] private float moveSpeed = 2.0f; 
    private Transform _player;
    private void Start()
    {
        // Find the player's transform by tag or other means.
        _player = DataHolder.Instance.GetPlayerTransform();
    }

    private void Update()
    {
        if (_player != null)
        {
            Vector3 direction = (_player.position - transform.position).normalized;
            transform.Translate(direction * (moveSpeed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        {
            Destroy(other.gameObject); // Destroy the projectile.
            TakeDamage(1); // Inflict damage to the enemy.
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}