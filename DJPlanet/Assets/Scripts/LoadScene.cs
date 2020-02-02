using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public string sceneName;

    public void LoadNewScene() { 
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}