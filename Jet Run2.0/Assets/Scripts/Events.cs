using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }

}