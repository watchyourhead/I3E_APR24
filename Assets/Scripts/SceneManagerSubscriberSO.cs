using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneChangeSO", menuName = "ScriptableObjects/SceneChangeScriptableObject", order = 1)]
public class SceneManagerSubscriberSO : ScriptableObject
{
    public UnityEvent SceneChangeEvent;
    public UnityEditor.SceneAsset targetScene;

    private void Awake()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.activeSceneChanged += SceneChangeCallback;
    }

    public void SceneChangeCallback(Scene currentScene, Scene nextScene)
    {
        if(nextScene.name == targetScene.name)
        {
            SceneChangeEvent.Invoke();
        }
    }
}
