using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float speedBooster = 20f;
    private const string HorizontalAxis = "Horizontal";
    [SerializeField] private float _speedX = 0.5f;
    private Rigidbody2D _rigidbody;
    private float direction;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        direction = Input.GetAxis(HorizontalAxis);
        Debug.Log(direction);
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speedX * direction * speedBooster * Time.fixedDeltaTime, _rigidbody.velocity.y);
        
    }
}
