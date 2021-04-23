using UnityEngine;

public class Lever : MonoBehaviour
{
    public SpriteRenderer levelSR;
    public Sprite rightTurnSprite;

    public Animator gateAnimator;

    bool _isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isTriggered)
            return;

        if (other.CompareTag("Player"))
        {
            levelSR.sprite = rightTurnSprite;
            gateAnimator.SetTrigger("Open");

            _isTriggered = true;
        }
    }
}
