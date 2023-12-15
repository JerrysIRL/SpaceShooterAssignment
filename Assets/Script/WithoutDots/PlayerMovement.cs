using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float rotationSpeed = 5;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        horizontal = vertical > -0.99 ? -horizontal : horizontal;

        _transform.Translate(new Vector3(0, vertical * movementSpeed * Time.deltaTime, 0));

        _transform.Rotate(Vector3.forward * (horizontal * rotationSpeed * Time.deltaTime));
    }
}