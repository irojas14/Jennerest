using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    public bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        isPaused = false;      
    }

    
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();

            }

            else
            {
                PauseGame();
            }
        }
    }
    
    void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        
    }

    void ResumeGame()
    {   
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }


}


