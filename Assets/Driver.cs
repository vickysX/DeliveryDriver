using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 15f;
    //[SerializeField] float speedUp = 20f;
    //[SerializeField] float bumpDown = 10f;
    bool hasBumped;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed -= 5f;  
        hasBumped = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SpeedUp")
        {
            if (hasBumped)
            {
                moveSpeed += 5f;
                hasBumped = false;
            }
            else
            {
                moveSpeed++;
            }
        }
    }
}
