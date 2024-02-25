using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonForLaser : MonoBehaviour
{
    [SerializeField] GameObject laser;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                laser.GetComponent<ButtonForLaser>().CloseLaser();
            }
        }
    }

    public void CloseLaser()
    {
        gameObject.SetActive(false);
    }
}
