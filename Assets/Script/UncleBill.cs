using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UncleBill : MonoBehaviour
{
    public float UncleBill_Speed = 5.0f;
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
    }
}
