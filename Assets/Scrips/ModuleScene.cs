using UnityEngine;

public class ModuleScene : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
