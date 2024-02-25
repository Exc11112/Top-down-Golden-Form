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
    public Image Box, Money, Jewelry, Skull, Gold;
    public int box, money, jewelry, skull, gold;

    private bool awalk;

    void Start()
    {
        initialPosition = transform.position;
        Box.gameObject.SetActive(false);
        Money.gameObject.SetActive(false);
        Jewelry.gameObject.SetActive(false);
        Skull.gameObject.SetActive(false);
        Gold.gameObject.SetActive(false);
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        movePlayer();
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(box);
            Debug.Log(money);
            Debug.Log(jewelry);
            Debug.Log(skull);
            Debug.Log(gold);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            box = 1; money = 1; jewelry = 1; skull = 1; gold = 1;
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

        if (collision.gameObject.CompareTag("EndDoor") && box == 1 && money == 1 && jewelry == 1 && skull == 1 && gold == 1)
        {
            SceneManager.LoadScene("End");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                collision.gameObject.SetActive(false);
                box = 1;
                Box.gameObject.SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("Money"))     
        {
            if (Input.GetKey(KeyCode.E))
            {
                collision.gameObject.SetActive(false);
                money = 1;
                Money.gameObject.SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("Jewelry"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                collision.gameObject.SetActive(false);
                jewelry = 1;
                Jewelry.gameObject.SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("Skull"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                collision.gameObject.SetActive(false);
                skull = 1;
                Skull.gameObject.SetActive(true);
            }
        }
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
        SceneManager.LoadScene("1");
    }


}