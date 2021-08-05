using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadController : MonoBehaviour
{

    [SerializeField] private GameObject loadPanel;
    [SerializeField] private Camera cam;


    public void LoadScene(string loadScene, string unloadScene)
    {
        loadPanel.SetActive(true);
        cam.gameObject.SetActive(true);
        StartCoroutine(UnloadSceneAsync(unloadScene, loadScene));
    }


    IEnumerator UnloadSceneAsync(string unloadScene, string loadScene)
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(unloadScene);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1);
        Resources.UnloadUnusedAssets();
        StartCoroutine(LoadSceneAsync(loadScene));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncOperation.isDone) yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

        loadPanel.SetActive(false);
        cam.gameObject.SetActive(false);
    }
}
