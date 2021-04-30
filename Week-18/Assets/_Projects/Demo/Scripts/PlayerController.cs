using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundJumpForce;
    public float minX, maxX;
    [Header("Ground Raycast")]
    public Transform checkGroundPoint;
    public float checkGroundRadius;
    public LayerMask whatIsGround;
    [Header("Rope Raycast")]
    public Transform checkRopePoint;
    public float checkRopeRadius;
    public LayerMask whatIsRope;

    bool _isGrounded = true;
    bool _isRoped = true;
    float _hInput;
    Rigidbody _rb;
    FixedJoint _joint;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _hInput = Input.GetAxis("Horizontal");
        _isGrounded = CheckForGround();
        _isRoped = CheckForRope(out Rigidbody ropeSegment);

        if (Input.GetKeyDown(KeyCode.Space))
            if (_isGrounded)
                Jump(groundJumpForce);

        if (_isRoped && Input.GetKey(KeyCode.Space) && _joint == null)
        {
            _joint = gameObject.AddComponent<FixedJoint>();
            _joint.connectedBody = ropeSegment;
        }
        else
        {
            if (_joint != null)
                Destroy(_joint);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float xVel = _hInput * moveSpeed * Time.deltaTime;
        _rb.velocity = new Vector3(xVel, _rb.velocity.y, 0f);

        float xPos = Mathf.Clamp(_rb.position.x, minX, maxX);
        _rb.position = new Vector3(xPos, _rb.position.y, 0f);
    }

    private void Jump(float force)
    {
        _rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    private bool CheckForGround()
    {
        return Physics.OverlapSphere(checkGroundPoint.position, checkGroundRadius, whatIsGround).Length > 0;
    }

    private bool CheckForRope(out Rigidbody ropeSegment)
    {
        var colls = Physics.OverlapSphere(checkRopePoint.position, checkRopeRadius, whatIsRope);

        if (colls.Length > 0)
        {
            ropeSegment = colls[0].GetComponent<Rigidbody>();
            return true;
        }
        else
        {
            ropeSegment = null;
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkGroundPoint.position, checkGroundRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(checkRopePoint.position, checkRopeRadius);
    }
}
