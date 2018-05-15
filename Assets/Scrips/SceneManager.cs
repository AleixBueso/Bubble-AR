using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

   public void LoadScene(string scene)
   {
        LoadScene(scene);
   }

    public void QuitGame()
    {
        Application.Quit();
    }
}
