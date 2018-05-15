using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

    float counter = 0;

    // Use this for initialization
    IEnumerator Start () {

        yield return StartCoroutine(ReturnToMenu());
	}

    private IEnumerator ReturnToMenu()
    {

        while (counter < 5)
        {
            counter += Time.deltaTime;
            yield return null;

        }

        // UnityEngine.SceneManagement.SceneManager.UnloadScene("win");
        // UnityEngine.SceneManagement.SceneManager.LoadScene("mainMenu");

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("mainMenu");
    }
}
