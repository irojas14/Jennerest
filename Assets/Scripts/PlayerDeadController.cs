using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeadController : MonoBehaviour
{
    public void sceneLoader(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
