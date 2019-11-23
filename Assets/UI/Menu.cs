using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject creditsMenu;
    [SerializeField]
    private AudioSource menuAudioSource;
    [SerializeField]
    private AudioClip buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene("SamScene");
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

    public void HoverSound()
    {
        menuAudioSource.PlayOneShot(buttonSound);
    }
}
