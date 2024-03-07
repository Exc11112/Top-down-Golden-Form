using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TimeLaserDoor : MonoBehaviour
{
    public GameObject laser1, laser2, laserL;
    [SerializeField] public float Downtimesmall;
    [SerializeField] public float Uptimesmall;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timeee());
        StartCoroutine(Timees());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Timeee()
    {
        while (true) 
        {
            laser1.SetActive(true);
            laser2.SetActive(true);
            yield return new WaitForSeconds(Uptimesmall);
            laser1.SetActive(false);
            laser2.SetActive(false);
            yield return new WaitForSeconds(Downtimesmall);
        }
    }

    private IEnumerator Timees() 
    {
        while (true)
        {
            laserL.SetActive(true);
            yield return new WaitForSeconds(3);
            laserL.SetActive(false);
            yield return new WaitForSeconds(3);
        }
    }

}
