using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    public static void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        //Fazer função para parar o video manager =p
    }

    public void SceneLoaderForButtons(string sceneName)
    {
        SceneLoader(sceneName);
    }

    //public void SceneLoaderForGlossary(string sceneName)
    //{
    //    GameManager.instance.lastSceneName = SceneManager.GetActiveScene().name;
    //    SceneLoader(sceneName);
    //}

    //public void VoltarButtonInGlossary()
    //{
    //    SceneLoader(GameManager.instance.lastSceneName);
    //}

    //public void SaveBeforeLoad()
    //{
    //    SaveManager.instance.Save();
    //}
}
