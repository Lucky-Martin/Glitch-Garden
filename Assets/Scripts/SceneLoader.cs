using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool loadStartScene = false;
    public int loadStartSceneDelay = 3;

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if (loadStartScene)
        {
            StartCoroutine(LoadStartingSceneCoroutine());
        }
    }

    private IEnumerator LoadStartingSceneCoroutine()
    {
        yield return new WaitForSeconds(loadStartSceneDelay);
        LoadStartScene();
    }

    private void LoadStartScene()
    {
        SceneManager.LoadScene("Start Scene");
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
