using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public string sceneName;

    public void LoadMinigame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
