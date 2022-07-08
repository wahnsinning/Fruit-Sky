using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject Pause_Screen;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Pause_Screen.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Game is exiting");
        //Just to make sure its working
    }
}