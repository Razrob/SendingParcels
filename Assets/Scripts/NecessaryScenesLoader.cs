using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NecessaryScenesLoader : MonoBehaviour
{ 
    [SerializeField] private string[] scenes;

    private void Awake()
    {

        foreach (string scene in scenes) if (!SceneManager.GetSceneByName(scene).isLoaded) SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    } 
}
