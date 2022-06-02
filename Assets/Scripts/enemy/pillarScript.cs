using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class pillarScript : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected bool moveForwed;
    protected bool moveBack;

    [SerializeField] protected GameObject OtherBlock;
    // [SerializeField] private Transform pointA;
    // [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 3;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (moveForwed)
        {
            MoveToMid();
        }
        else if (moveBack)
        {
            MoveBack();
        }
    }

    protected void MoveBack()
    {
        rb.velocity = Vector2.down * speed;
        // rb.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.fixedDeltaTime);
    }

    protected void MoveToMid()
    {
        rb.velocity = Vector2.up * speed;
        // rb.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.fixedDeltaTime);
    }

    //set the block to move 
    public abstract void GO();
    // {
    //     moveForwed = true;
    //     moveBack = false;
    // }
    
    // set the block to move back
    public abstract void Back();
    // {
        // moveForwed = false;
        // moveBack = true;
    // }

    // set the block to stop moving
    public abstract void StopMovement();

    public abstract void CollideWithOtherBlock(); 

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == OtherBlock)
        {
            CollideWithOtherBlock();
        }
    }
}