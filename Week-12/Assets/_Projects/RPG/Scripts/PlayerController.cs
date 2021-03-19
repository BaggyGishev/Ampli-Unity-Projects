using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    public float sprintSpeed;
    public float rotateSpeed;
    [Space]
    public AnimatorController idleController;
    public AnimatorController walkController;
    public AnimatorController runController;

    bool _isSprint = false;
    Vector3 _rawInput;

    CharacterController _characterController;
    Animator _animator;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _rawInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift))
            _isSprint = true;
        else
            _isSprint = false;

        ChangeAnimation();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        if (_rawInput.magnitude > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_rawInput), rotateSpeed * Time.deltaTime);
    }

    private void MovePlayer()
    {
        float moveSpeed = _isSprint ? sprintSpeed : walkSpeed;
        _characterController.SimpleMove(_rawInput.normalized * moveSpeed * Time.deltaTime);
    }

    private void ChangeAnimation()
    {
        if (_rawInput.magnitude > 0)
        {
            if (_isSprint)
                _animator.runtimeAnimatorController = runController;
            else
                _animator.runtimeAnimatorController = walkController;
        }
        else
            _animator.runtimeAnimatorController = idleController;

    }
}
