using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    public Animator anim;
    public float walkSpeed = 8.0f;
    public float runMultiplier = 1.5f;
    private float currentSpeed;
    public Vector2 move;
    private Vector3 initialPosition;
    private bool isRunning = false;
    //public Image Box, Money, Jewelry, Skull, Gold;

    private bool awalk;

    void Start()
    {
        initialPosition = transform.position;
        //Box.gameObject.SetActive(false);
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);

        awalk = movement.magnitude > 0;
        anim.SetBool("walkis", awalk);

        checkRunInput();
    }

    //public void movePlayer()
    //{
    //    Vector3 movement = new Vector3(move.x, 0f, move.y);

    //    if (movement != Vector3.zero)
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
    //    }

    //    //Vector3 smoothedMovement = Vector3.Lerp(transform.position, transform.position + movement, 0.1f);
    //    //transform.position = smoothedMovement;

    //    transform.Translate(movement * speed * Time.deltaTime, Space.World);
    //}

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    move = context.ReadValue<Vector2>();
    //    awalk = move.magnitude > 0;

    //    anim.SetBool("walkis", awalk);
    //}

    //public void OnRun(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        speed *= 1.5f; // Adjust the running speed as needed
    //        anim.SetBool("runis", true);
    //    }
    //    else if (context.canceled)
    //    {
    //        speed /= 1.5f; // Reset speed when Shift key is released
    //        anim.SetBool("runis", false);
    //    }
    //}

    public void checkRunInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            anim.SetBool("runis", true);
        }
        else
        {
            isRunning = false;
            anim.SetBool("runis", false);
        }

        // Adjust speed based on whether the player is running or not
        currentSpeed = isRunning ? walkSpeed * runMultiplier : walkSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a specific tag
        if (collision.gameObject.CompareTag("Laser"))
        {
            ResetStage();
        }
    }

    public void ResetStage()
    {
        transform.position = initialPosition;
        SceneManager.LoadScene("1");
    }

}