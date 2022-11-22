
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   

    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    { 
        
        Application.Quit();
    }
}
