using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back_cod : MonoBehaviour
{
    public void backManu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Debug.Log("Exiting game..."); // ����ͤ���ഺ����ҡ��ѧ�͡�ҡ��
        Application.Quit(); // �͡�ҡ��
    }
}
