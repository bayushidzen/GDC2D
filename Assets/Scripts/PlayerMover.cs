using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float speedBooster = 50f;
    private const string horizontalAxis = "Horizontal";
    private const string groundTag = "Ground";

    [SerializeField] private float _speedX = 1f;
    [SerializeField] private float _jumpForce = 500f;

    private Rigidbody2D _rigidbody;
    private float direction;
    private bool _isJump;
    private bool _isGround;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        direction = Input.GetAxis(horizontalAxis);
        if (_isGround && Input.GetKeyDown(KeyCode.W))
        {
            _isJump = true;
        }
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speedX * direction * speedBooster * Time.fixedDeltaTime, _rigidbody.velocity.y);

        if (_isJump)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
            _isJump = false;
            _isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            _isGround = true;
        }
    }
}
