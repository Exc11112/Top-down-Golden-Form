using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLaserDoor : MonoBehaviour
{
    public GameObject laser1, laser2, laser3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timeee());
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
            laser3.SetActive(true);
            yield return new WaitForSeconds(3);
            laser1.SetActive(false);
            laser2.SetActive(false);
            laser3.SetActive(false);
            yield return new WaitForSeconds(3);
        }
    }

}
