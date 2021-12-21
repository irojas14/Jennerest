using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("Introduction"); //cargamos escena juego
    }
    public void QuitGame() 
    {
        Application.Quit ();
    }
 }

