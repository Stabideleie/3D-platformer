using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    private PlayerInput input;
    private Rigidbody rb;

    public float moveSpeed;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deAcceleration;
    [SerializeField] private float passiveDeAcceleration;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private AudioSource jumpSoundSource;

    [SerializeField] List <Transform> groundcheckTransforms = new List<Transform>();    

    private float maxDistanceForGroundCheck = 0.85f;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        if (IsGrounded())
        {

            move();
            Acceleration();
        }
    }
    private void Update()
    {
        Jump();
    }

    private void move()
    {
        if(moveSpeed != 0)
        {
            Vector3 velocity = (transform.forward * moveSpeed);
            velocity.y = rb.velocity.y;
            rb.velocity = velocity;
        }


        transform.Rotate(Vector3.up * input.SteerVector.x * rotateSpeed * Time.deltaTime);


    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Vector3 impulse = collision.impulse;
        impulse.y = 0;
        if (impulse.magnitude > 20000)
        {
            moveSpeed = 0;
        }
    }

    private void Jump()
    {
        if (IsGrounded() && input.JumpValue)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            jumpSoundSource.Play();
        }
    }

    private void Acceleration()
    {
        if(input.GassValue)
        {
            moveSpeed += acceleration * Time.deltaTime;
        }
        if(input.BrakeValue)
        {
            moveSpeed -= deAcceleration * Time.deltaTime;
        }

        if(moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }
        if(moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }

        if (moveSpeed > 0 && input.GassValue == false)
        {
            moveSpeed -= passiveDeAcceleration * Time.deltaTime;
        }
        if (moveSpeed < 0 && input.BrakeValue == false)
        {
            moveSpeed += passiveDeAcceleration * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        bool isGrounded = false;
        foreach (Transform t in groundcheckTransforms)
        {
            Debug.DrawRay(t.position, Vector3.down * maxDistanceForGroundCheck, Color.blue);
            if (Physics.Raycast(t.position, Vector3.down, maxDistanceForGroundCheck))
            {
                isGrounded = true; break;
            }
        }
        return isGrounded;
    }


}
