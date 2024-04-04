using UnityEngine;

public class ShowEIcon : MonoBehaviour
{
    public GameObject player;
    public GameObject eIcon;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 2.0f) // ระยะที่ player ต้องเข้าใกล้เพื่อให้แสดง eIcon
        {
            eIcon.SetActive(true);
        }
        else
        {
            eIcon.SetActive(false);
        }
    }
}
