using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UncleBill : MonoBehaviour
{
    public float UncleBill_Speed = 5.0f;
    public float UncleBill_Jump = 5.0f;
    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float HorizontalMovementInput = Input.GetAxisRaw("Horizontal");
        Vector3 movementDirection = Vector3.right * HorizontalMovementInput;
        transform.position += movementDirection * UncleBill_Speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, UncleBill_Jump);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            DoubleJumpCheck(collision);
        }
    }
    private void DoubleJumpCheck(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

}
