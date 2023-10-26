using System;
using Script.DOTS;
using TMPro;
using Unity.Entities;
using UnityEngine;

public class UIUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text FPSCounter;
    [SerializeField] private TMP_Text EnemyCounter;

    private EntityManager entityManager;

    private void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    private void FixedUpdate()
    {
        int enemies = entityManager.CreateEntityQuery(ComponentType.ReadOnly<EnemyTag>()).CalculateEntityCount();
        EnemyCounter.text = $"Enemies {enemies}";
        float fps = 1 / Time.smoothDeltaTime;
        FPSCounter.text = $"fps {fps}";
    }

    private void Update()
    {
        float fps =  MathF.Floor(1 / Time.smoothDeltaTime);
        FPSCounter.text = $"fps {fps}";
    }
}
