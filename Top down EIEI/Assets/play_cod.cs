using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play_cod : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Debug.Log("Exiting game..."); // ให้ข้อความเดบั๊กว่ากำลังออกจากเกม
        Application.Quit(); // ออกจากเกม
    }
}
