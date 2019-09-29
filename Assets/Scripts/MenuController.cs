using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas optionsMenu;

    public void Start()
    {
        if (optionsMenu != null)
        {
            optionsMenu.enabled = false;
        }
    }

    public void StartSinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    public void StartTwoPlayerMode()
    {
        SceneManager.LoadScene("TwoPlayers");
    }

    public void OpenOptions()
    {
        optionsMenu.enabled = true;
        mainMenu.enabled = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
        if (mainMenu != null && optionsMenu != null) {
            optionsMenu.enabled = true;
            mainMenu.enabled = true;
        }
    }
}
