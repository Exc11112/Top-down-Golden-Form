using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContollerFT : MonoBehaviour
{
    public Animator anim;
    public float walkSpeed = 8.0f;
    public float runMultiplier = 1.5f;
    private float currentSpeed;
    public Vector2 move;
    private Vector3 initialPosition;
    private bool isRunning = false;
    public Image Gold;
    public int gold;

    private bool awalk;

    void Start()
    {
        initialPosition = transform.position;

        Gold.gameObject.SetActive(false);
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        movePlayer();
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(gold);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gold = 1;
        }
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

        if (collision.gameObject.CompareTag("EndDoor") && gold == 1)
        {
            SceneManager.LoadScene("1");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                collision.gameObject.SetActive(false);
                gold = 1;
                Gold.gameObject.SetActive(true);
            }
        }
    }

    public void ResetStage()
    {
        transform.position = initialPosition;
        SceneManager.LoadScene("0");
    }


}