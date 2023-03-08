using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UncleBill : MonoBehaviour
{
    [SerializeField]
    private float UncleBill_Speed = 5.0f;
    [SerializeField]
    private float UncleBill_Jump = 6.0f;
    private bool canJump = true;
    private bool canCollect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Collect();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(CollectCheckCoroutine(collision));
        JumpCheck(collision);
    }
    public void Movement()
    {
        float HorizontalMovementInput = Input.GetAxisRaw("Horizontal");
        Vector3 movementDirection = Vector3.right * HorizontalMovementInput;
        transform.position += movementDirection * UncleBill_Speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * UncleBill_Jump, ForceMode2D.Impulse);
            canJump = false;
        }
    }
    public void Collect()
    {
        if (Input.GetKeyDown(KeyCode.F) && canCollect)
        {
            Debug.Log("Collect!");
            canCollect = false;
        }
    }
    public void JumpCheck(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            canJump = true;
        }
    }
    public IEnumerator CollectCheckCoroutine(Collision2D collision)
    {
        while (true)
        {
            if (collision.gameObject.CompareTag("Item"))
            {
                Debug.Log("Can Collect!");
                canCollect = true;
                yield return new WaitForSeconds(1.0f);
            }
            Debug.Log("nonono");
            canCollect = false;
        }
    }
}
