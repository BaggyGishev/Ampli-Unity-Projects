using UnityEngine;

public class Chest : MonoBehaviour
{
    bool _isCollected = false;

    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dwarf") && !_isCollected)
        {
            _animator.SetTrigger("Open");
            other.GetComponent<Dwarf>().GetMoney(100);

            _isCollected = true;
        }
    }
}
