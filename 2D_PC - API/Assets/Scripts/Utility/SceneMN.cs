using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
  Load,
  MainMap1_1,
  MainMap2_1,
  Menu,
  LoginScene,
}
public class SceneMN : MonoBehaviour
{
    static Scene currScene, lastScene;
    public static void LoadScene(Scene scene)
    {
        if (scene == currScene) return;
        

        lastScene = currScene;
        currScene = scene;
        SceneManager.LoadScene(scene.ToString());
    }
}
