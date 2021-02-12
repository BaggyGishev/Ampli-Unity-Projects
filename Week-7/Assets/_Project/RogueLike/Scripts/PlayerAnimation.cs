using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _animator;
    Player _player;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _animator.SetBool("IsRunning", _player.input.magnitude > 0.25f);

        if (_player.input.x != 0 || _player.input.y != 0)
        {
            _animator.SetFloat("X", _player.input.x);
            _animator.SetFloat("Y", _player.input.y);
        }
    }
}
