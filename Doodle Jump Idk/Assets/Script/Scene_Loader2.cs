using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_Loader2 : MonoBehaviour
{
   public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
