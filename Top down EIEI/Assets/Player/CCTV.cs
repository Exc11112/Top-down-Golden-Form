using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    
    public GameObject[] waypoints;
    int current = 0;
    [SerializeField] float Stoptime;
    public float Speed;
    float WPradius = 1;
    private bool isWaiting = false;

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
        {
            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
            {
                current = (current + 1) % waypoints.Length;
                StartCoroutine(WaitAndMove());
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * Speed);
        }
    }

    private IEnumerator WaitAndMove()
    {
        isWaiting = true;
        yield return new WaitForSecondsRealtime(Stoptime);
        isWaiting = false;
    }
}
