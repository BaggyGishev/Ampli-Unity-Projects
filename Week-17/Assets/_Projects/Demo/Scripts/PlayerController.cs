using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;

    [Header("GroundCheck")]
    public Transform checkPoint;
    public float checkRadius;
    public LayerMask whatIsGround;

    float _hInput;
    bool _isGrounded = true;

    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _hInput = Input.GetAxis("Horizontal");

        CheckForGround();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_hInput * moveSpeed, _rb.velocity.y);
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckForGround()
    {
        Collider2D coll = Physics2D.OverlapCircle(checkPoint.position, checkRadius, whatIsGround);

        if (coll != null)
            _isGrounded = true;
        else
            _isGrounded = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkPoint.position, checkRadius);
    }
}
