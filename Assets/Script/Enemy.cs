using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float moveSpeed = 2.0f;
    private Transform _player;

    private void Start()
    {
        _player = DataHolder.Instance.GetPlayerTransform();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TakeDamage(1); // Inflict damage to the enemy.
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DataHolder.Instance.enemieCounter--;
            EnemySpawner.Instance.ReturnToPool(gameObject);
        }
    }
}