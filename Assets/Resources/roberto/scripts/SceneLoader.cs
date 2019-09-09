using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    public string mainMenu;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            goToMainMenu();
        }
    }
    public void loadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
