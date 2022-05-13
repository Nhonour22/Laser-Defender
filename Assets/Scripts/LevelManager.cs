using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    
    [SerializeField] float sceneLoadDelay = 2f;
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuNew");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver1", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Game");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
    

}   
