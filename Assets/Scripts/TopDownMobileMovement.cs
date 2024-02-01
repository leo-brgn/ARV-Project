using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMobileMovement : MonoBehaviour
{
    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Animator playerAnimator;

    public float moveSpeed;
    public float rotationSpeed;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetBool("Grounded", true);
    }
    
    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        playerRigidbody.MovePosition(transform.position + moveDirection * (moveSpeed * Time.deltaTime));

        if (moveDirection != Vector3.zero)
        {
            Quaternion playerRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, rotationSpeed * Time.deltaTime);
        }
        
        float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);
        playerAnimator.SetFloat("MoveSpeed", inputMagnitude);
    }
}
