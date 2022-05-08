using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileMovimentation : MonoBehaviour
{

    private Touch touch;
    private Vector2 touchStartPosition, touchEndPosition;
    private string directionX;
    private string directionY;

    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began) {
                touchStartPosition = touch.position;
            } else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended) {
                touchEndPosition = touch.position;

                Vector2 dir = Vector2.ClampMagnitude(touchEndPosition - touchStartPosition, speed);
                rb.velocity = dir;
                anim.SetBool("Run", true);
            }
        } else {
            rb.velocity = new Vector2(0,0);
            anim.SetBool("Run", false);
        }

        if(rb.velocity.x > 0) {
            spriteRenderer.flipX = false;
        } else if(rb.velocity.x < 0) {
            spriteRenderer.flipX = true;
        }
    }
}
