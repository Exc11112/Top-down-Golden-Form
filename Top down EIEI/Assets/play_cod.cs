using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play_cod : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
    public void NextGame()
    {
        SceneManager.LoadScene(3);
    }
    public void TutorialGame()
    {
        SceneManager.LoadScene(4);
    }
    public void Quit()
    {
        Debug.Log("Exiting game..."); 
        Application.Quit(); 
    }
}
