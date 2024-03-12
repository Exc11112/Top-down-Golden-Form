using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonForLaser : MonoBehaviour
{
    [SerializeField] GameObject laser;
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    public Sprite newSprite; // The new sprite to assig

    void Start()
    {
        // Get references to the SpriteRenderer and Button components
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                laser.GetComponent<ButtonForLaser>().CloseLaser();
                ChangeSprite();
            }
        }
    }

    public void CloseLaser()
    {
        gameObject.SetActive(false);
    }

    void ChangeSprite()
    {
        // Change the sprite of the SpriteRenderer to the new sprite
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
