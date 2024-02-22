using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerContoller : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public Vector2 move;
    private Vector3 initialPosition;


    private bool awalk;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        //Vector3 smoothedMovement = Vector3.Lerp(transform.position, transform.position + movement, 0.1f);
        //transform.position = smoothedMovement;

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        awalk = move.magnitude > 0;

        anim.SetBool("walkis", awalk);
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            speed *= 1.5f; // Adjust the running speed as needed
            anim.SetBool("runis", true);
        }
        else if (context.canceled)
        {
            speed /= 1.5f; // Reset speed when Shift key is released
            anim.SetBool("runis", false);
        }
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