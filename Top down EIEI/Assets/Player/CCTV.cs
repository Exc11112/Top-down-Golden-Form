using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float Speed;
    float WPradius = 1;
    public int wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = 1;
        StartCoroutine(Timee());
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

    private IEnumerator Timee()
    {
        while (true)
        {
            wait = 0;
            yield return new WaitForSeconds(3);
            wait= 1;
            yield return new WaitForSeconds(3);
        }
    }
}
