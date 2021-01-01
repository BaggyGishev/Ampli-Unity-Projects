using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public Sprite deathSprite;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody;
    bool isAlive = true;

    // Use this for initialization
    void Start () {
        rigidbody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0.5f, 1) * 50f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isAlive = false;
            spriteRenderer.sprite = deathSprite;
            rigidbody.velocity = Vector2.down;
        }
    }
}
