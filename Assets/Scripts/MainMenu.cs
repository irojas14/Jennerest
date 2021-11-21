using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("AlphaLevel"); //cargamos escena juego
    }
    public void QuitGame() 
    {
        Application.Quit ();
        Debug.Log("Game is exiting");
    }
 }

