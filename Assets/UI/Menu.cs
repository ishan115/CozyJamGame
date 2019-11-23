using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene("iansScene");
    }

    public void LoadMainManu()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void LoadCreditsMenu()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
