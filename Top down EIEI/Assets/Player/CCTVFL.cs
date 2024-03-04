using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVFL : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float Speed;
    float WPradius = 1;
    private int wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (wait == 1)
        {
            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
            {
                current++;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * Speed);
        }
    }

}
